
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetSize : MonoBehaviour
{
	public static Vector3 Size(GameObject gameObject)
	{
		Size size = gameObject.GetComponent<Size>();
		Vector3 result;
		if (size == null)
		{
			if (gameObject.GetComponent<Renderer>())
			{
				result = gameObject.GetComponent<Renderer>().bounds.size;
			}
			else if (gameObject.GetComponent<Collider>())
			{
				result = gameObject.GetComponent<Collider>().bounds.size;
			}
			else if (gameObject.GetComponent<Mesh>())
			{
				result = gameObject.GetComponent<Mesh>().bounds.size;
			}
			else if (gameObject.transform.childCount == 1)
			{
				result = Size(gameObject.transform.GetChild(0).gameObject);
			}
			else if (gameObject.transform.childCount == 0)
			{
				result = new Vector3(0, 0, 0);
			}
			else
			{
				size = gameObject.AddComponent<Size>();
				size.vectors = new Vector3(GetSizeXParent(gameObject), GetSizeYParent(gameObject), 
					GetSizeZParent(gameObject));
				result = size.vectors;
			}
		}
		else
		{
			result = size.vectors;
		}

		return result;
	}

	static float GetSizeXParent (GameObject gameObjectParent)
	{
		//GameObject[] childrenGameObjects = gameObjectTemp.
		GameObject firstGameObject = null, lastGameObject = null;
		firstGameObject = gameObjectParent.transform.GetChild (0).gameObject;
		lastGameObject = gameObjectParent.transform.GetChild (1).gameObject;
		float sizeX = 0;
		foreach (Transform child in gameObjectParent.transform) {
			if (child.transform.position.x < firstGameObject.transform.position.x) {
				firstGameObject = child.gameObject;
				continue;
			}

			if (child.transform.position.x > lastGameObject.transform.position.x) {
				lastGameObject = child.gameObject;
				continue;
			}

			if (child.transform.position.x == firstGameObject.transform.position.x && Size (child.gameObject).x > Size (firstGameObject).x) {
				firstGameObject = child.gameObject;
				continue;
			}

			if (child.transform.position.x == lastGameObject.transform.position.x && Size (child.gameObject).x > Size (lastGameObject).x) {
				lastGameObject = child.gameObject;
				continue;
			} 
		}

		if ((firstGameObject != null) && (lastGameObject != null)) {
			sizeX = (lastGameObject.transform.position.x - firstGameObject.transform.position.x) + Size (lastGameObject).x / 2 + Size (firstGameObject).x / 2;
		}

		return sizeX;
	}

	static float GetSizeYParent (GameObject gameObjectParent)
	{
		//GameObject[] childrenGameObjects = gameObjectTemp.
		GameObject firstGameObject = null, lastGameObject = null;
		firstGameObject = gameObjectParent.transform.GetChild (0).gameObject;
		lastGameObject = gameObjectParent.transform.GetChild (1).gameObject;
		float sizeY = 0;
		foreach (Transform child in gameObjectParent.transform) {
			if (child.transform.position.y < firstGameObject.transform.position.y) {
				firstGameObject = child.gameObject;
				continue;
			}

			if (child.transform.position.y > lastGameObject.transform.position.y) {
				lastGameObject = child.gameObject;
				continue;
			}

			if (child.transform.position.y == firstGameObject.transform.position.y && Size (child.gameObject).y > Size (firstGameObject).y) {
				firstGameObject = child.gameObject;
				continue;
			}

			if (child.transform.position.y == lastGameObject.transform.position.y && Size (child.gameObject).y > Size (lastGameObject).y) {
				lastGameObject = child.gameObject;
				continue;
			} 
		}

		if ((firstGameObject != null) && (lastGameObject != null)) {
			sizeY = (lastGameObject.transform.position.y - firstGameObject.transform.position.y) + Size (lastGameObject).y / 2 + Size (firstGameObject).y / 2;
		}

		return sizeY;
	}

	static float GetSizeZParent (GameObject gameObjectParent)
	{
		//GameObject[] childrenGameObjects = gameObjectTemp.
		GameObject firstGameObject = null, lastGameObject = null;
		firstGameObject = gameObjectParent.transform.GetChild (0).gameObject;
		lastGameObject = gameObjectParent.transform.GetChild (1).gameObject;
		float sizeZ = 0;
		foreach (Transform child in gameObjectParent.transform) {
			if (child.transform.position.z < firstGameObject.transform.position.z) {
				firstGameObject = child.gameObject;
				continue;
			}

			if (child.transform.position.z > lastGameObject.transform.position.z) {
				lastGameObject = child.gameObject;
				continue;
			}

			if (child.transform.position.z == firstGameObject.transform.position.z && Size (child.gameObject).z > Size (firstGameObject).z) {
				firstGameObject = child.gameObject;
				continue;
			}

			if (child.transform.position.z == lastGameObject.transform.position.z && Size (child.gameObject).z > Size (lastGameObject).z) {
				lastGameObject = child.gameObject;
				continue;
			} 
		}

		if ((firstGameObject != null) && (lastGameObject != null)) {
			sizeZ = (lastGameObject.transform.position.z - firstGameObject.transform.position.z) + Size (lastGameObject).z / 2 + Size (firstGameObject).z / 2;
		}

		return sizeZ;
	}
}


