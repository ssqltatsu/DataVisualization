using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera cam;
	private float zoom;
	private float view;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera> ();
		view = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {   
        cam.fieldOfView = view + zoom;
		if (cam.fieldOfView < 10f) {
			cam.fieldOfView = 10f;

		}

		if(cam.fieldOfView > 60f){
			cam.fieldOfView = 60f;
		}

		if (Input.GetKey(KeyCode.Z)) {
			zoom -= 0.3f;
		} else if (Input.GetKey(KeyCode.O)){
			zoom += 0.3f;
		}
    }
}
