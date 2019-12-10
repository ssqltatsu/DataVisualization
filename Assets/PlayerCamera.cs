using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
	private Transform target;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player").transform;
		offset = GetComponent<Transform> ().position - target.position;

	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Transform> ().position = target.position + offset;
	}
}
