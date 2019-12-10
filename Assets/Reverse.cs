using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetReverse(string direction, GameObject obj) {
		
		switch (direction) {
		case "100":
			obj.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z); 
			break;

		case "010":
			obj.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z); 
			break;

		case "001":
			obj.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * -1); 
			break;

		case "110":
			obj.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y * -1, transform.localScale.z); 
			break;

		case "101":
			obj.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z * -1); 
			break;

		case "011":
			obj.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z * -1); 
			break;

		case "111":
			obj.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y * -1, transform.localScale.z * -1); 
			break;

		default:
			
			break;
		}
	}



}
