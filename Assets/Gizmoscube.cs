using System;
using UnityEngine;

public class GizmosCube:MonoBehaviour
{
	void Start(){
	}

	void Update(){
	}

	void OnDrawGizmosSelected(){
		Gizmos.DrawWireCube(transform.position, new Vector3(1,1,1));
			}
}


