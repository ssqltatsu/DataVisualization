using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.LeftCommand))
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				if (transform.eulerAngles.x >= -45)
				{
					transform.Rotate(-1, 0, 0);
				}
			}

			if (Input.GetKey(KeyCode.DownArrow))
			{
				if (transform.eulerAngles.x <= 45)
				{
					transform.Rotate(1, 0, 0);
				}
			}

			if (Input.GetKey(KeyCode.LeftArrow))
			{
				transform.Rotate(0, -1, 0);
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.Rotate(0, 1, 0);
			}
		}else if (Input.GetKey(KeyCode.RightCommand))
		{
			if (!Input.GetKey(KeyCode.RightShift))
			{
				if (Input.GetKey(KeyCode.DownArrow))
				{
					transform.position =
						new Vector3(transform.position.x, transform.position.y, transform.position.z - 10.0f);
				}

				if (Input.GetKey(KeyCode.UpArrow))
				{
					transform.position =
						new Vector3(transform.position.x, transform.position.y, transform.position.z + 10.0f);
				}

			}
			else
			{
				if (Input.GetKey(KeyCode.DownArrow))
				{
					transform.position =
						new Vector3(transform.position.x, transform.position.y, transform.position.z - 50.0f);
				}

				if (Input.GetKey(KeyCode.UpArrow))
				{
					transform.position =
						new Vector3(transform.position.x, transform.position.y, transform.position.z + 50.0f);
				}
			}

		}else
		{
			if (!Input.GetKey(KeyCode.RightShift))
			{
				if (Input.GetKey(KeyCode.UpArrow))
				{
					transform.position =
						new Vector3(transform.position.x, transform.position.y + 10.0f, transform.position.z);
				}

				if (Input.GetKey(KeyCode.DownArrow))
				{
					transform.position =
						new Vector3(transform.position.x, transform.position.y - 10.0f, transform.position.z);
				}

				if (Input.GetKey(KeyCode.LeftArrow))
				{
					transform.position =
						new Vector3(transform.position.x - 10.0f, transform.position.y, transform.position.z);
				}

				if (Input.GetKey(KeyCode.RightArrow))
				{
					transform.position =
						new Vector3(transform.position.x + 10.0f, transform.position.y, transform.position.z);
				}
			}
			else
			{
				if (Input.GetKey(KeyCode.UpArrow))
				{
					transform.position =
						new Vector3(transform.position.x, transform.position.y + 50.0f, transform.position.z);
				}

				if (Input.GetKey(KeyCode.DownArrow))
				{
					transform.position =
						new Vector3(transform.position.x, transform.position.y - 50.0f, transform.position.z);
				}

				if (Input.GetKey(KeyCode.LeftArrow))
				{
					transform.position =
						new Vector3(transform.position.x - 50.0f, transform.position.y, transform.position.z);
				}

				if (Input.GetKey(KeyCode.RightArrow))
				{
					transform.position =
						new Vector3(transform.position.x + 50.0f, transform.position.y, transform.position.z);
				}
			}
		}

	}
}
