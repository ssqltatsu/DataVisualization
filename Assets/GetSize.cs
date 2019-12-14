
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetSize : MonoBehaviour
{
	public static Vector3 Size(GameObject gameObject)
	{
		Size size = gameObject.GetComponent<Size>();
		Vector3 result;
		if (size == null && gameObject.transform.childCount == 0) {
                        result = new Vector3(0, 0, 0);
                }
                else if (size == null && gameObject.transform.childCount == 1) {
                        result = Size(gameObject.transform.GetChild(0).gameObject);
                }
                else if (size == null)
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
			else
			{
				result = new Vector3(GetSizeXParent(gameObject), GetSizeYParent(gameObject), 
					GetSizeZParent(gameObject));
				result = size.vectors;
			}
			size = gameObject.AddComponent<Size>();
                        size.vectors = result;
		}
		else
		{
			result = size.vectors;
		}

		return result;
	}

	static float GetSizeXParent (GameObject gameObjectParent)
	{
		Transform firstObject = null, lastObject = null;
		firstObject = gameObjectParent.transform.GetChild (0);
		lastObject = gameObjectParent.transform.GetChild (1);
		float sizeX = 0;
		foreach (Transform child in gameObjectParent.transform) {
			if (child.position.x < firstObject.position.x) {
				firstObject = child;
				continue;
			}

			if (child.position.x > lastObject.position.x) {
				lastObject = child;
				continue;
			}

			if (child.position.x == firstObject.position.x && Size (child.gameObject).x > Size (firstObject.gameObject).x) {
				firstObject = child;
				continue;
			}

			if (child.position.x == lastObject.position.x && Size (child.gameObject).x > Size (lastObject.gameObject).x) {
				lastObject = child;
				continue;
			} 
		}

		sizeX = (lastObject.position.x - firstObject.position.x) + Size (lastObject.gameObject).x / 2 + Size (firstObject.gameObject).x / 2;

		return sizeX;
	}

	static float GetSizeYParent (GameObject gameObjectParent)
	{
		Transform firstObject = null, lastObject = null;
		firstObject = gameObjectParent.transform.GetChild (0);
		lastObject = gameObjectParent.transform.GetChild (1);
		float sizeY = 0;
		foreach (Transform child in gameObjectParent.transform) {
			if (child.position.y < firstObject.position.y) {
				firstObject = child;
				continue;
			}

			if (child.position.y > lastObject.position.y) {
				lastObject = child;
				continue;
			}

			if (child.position.y == firstObject.position.y && Size (child.gameObject).y > Size (firstObject.gameObject).y) {
				firstObject = child;
				continue;
			}

			if (child.position.y == lastObject.position.y && Size (child.gameObject).y > Size (lastObject.gameObject).y) {
				lastObject = child;
				continue;
			} 
		}

		sizeY = (lastObject.position.y - firstObject.position.y) + Size (lastObject.gameObject).y / 2 + Size (firstObject.gameObject).y / 2;

		return sizeY;
	}

	static float GetSizeZParent (GameObject gameObjectParent)
	{
		Transform firstObject = null, lastObject = null;
		firstObject = gameObjectParent.transform.GetChild (0);
		lastObject = gameObjectParent.transform.GetChild (1);
		float sizeZ = 0;
		foreach (Transform child in gameObjectParent.transform) {
			if (child.position.z < firstObject.position.z) {
				firstObject = child;
				continue;
			}

			if (child.position.z > lastObject.position.z) {
				lastObject = child;
				continue;
			}

			if (child.position.z == firstObject.position.z && Size (child.gameObject).z > Size (firstObject.gameObject).z) {
				firstObject = child;
				continue;
			}

			if (child.position.z == lastObject.position.z && Size (child.gameObject).z > Size (lastObject.gameObject).z) {
				lastObject = child;
				continue;
			} 
		}

		sizeZ = (lastObject.position.z - firstObject.position.z) + Size (lastObject.gameObject).z / 2 + Size (firstObject.gameObject).z / 2;

		return sizeZ;
	}
}


