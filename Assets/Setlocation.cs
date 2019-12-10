using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setlocation : MonoBehaviour {
	Vector3 newPosition;
	Vector3 positionStart;
	// Use this for initialization
	void Start () {
		transform.position = newPosition;
	}


	
	// Update is called once per frame
	void Update () {
		Debug.Log (transform.position);
	}

	public void SetLocate(float x, float y, float z){
		newPosition = new Vector3(x,y,z);
	}
}
//	EvenlySpace(){
//		if () {
			
//	}

