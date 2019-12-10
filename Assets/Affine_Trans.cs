using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Affine_Trans : MonoBehaviour {
	Matrix4x4 mat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	public GameObject Affine_transform (String m00, String m01,  String m02, int m03, int m10, int m11, int m12, int m13, int m21, int m22, int m23, GameObject obj){
//		mat = Matrix4x4.identity;
//
//		mat.m01 = m01;
//		mat.m02 = m02;
//		mat.m03 = m03;
//		mat.m11 = m11;
//		mat.m12 = m12;
//		mat.m13 = m13;
//		mat.m21 = m21;
//		mat.m22 = m22;
//		mat.m23 = m23;
//
//		obj.transform.position = mat.MultiplyPoint3x4(new Vector3(1,2,3));
//		return obj;
//	}

}
