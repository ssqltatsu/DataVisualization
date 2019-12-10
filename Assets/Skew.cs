using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skew : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject SetSkew (string matij, float value, GameObject obj){
		Camera cam;
		cam = obj.AddComponent<Camera> ();

		Matrix4x4 mat;

		mat = Matrix4x4.identity;
		print ("mat:" + mat);
		switch(matij){
		case "01":
			mat.m01 = Mathf.Atan (value);
			break;

		case "02":
			mat.m02 = Mathf.Atan(value);
			break;

		case "10":
			mat.m10 = Mathf.Atan(value);
			break;

		case "12":
			mat.m12 = Mathf.Atan(value);
			break;

		case "20":
			mat.m20 = Mathf.Atan(value);
			break;

		case "21":
			mat.m21 = Mathf.Atan(value);
			break;

		default:
			break;

		}
		print ("new mat:" + mat);
		print ("sizex:" + GetSize.Size (obj).x / transform.localScale.x);
		print ("sizey:" + GetSize.Size (obj).y / transform.localScale.y);
		print ("sizez:" + GetSize.Size (obj).z / transform.localScale.z);
		obj.transform.localScale = mat.MultiplyPoint3x4(new Vector3(GetSize.Size (obj).x / transform.localScale.x, GetSize.Size (obj).y / transform.localScale.y, GetSize.Size (obj).z / transform.localScale.z));
		cam.projectionMatrix = mat;
		return obj;
	}
}
