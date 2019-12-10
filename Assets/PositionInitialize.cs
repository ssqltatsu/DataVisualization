using System;
using System.Collections;
using System.Collections.Generic;
using IBM.Watson.DeveloperCloud.Logging;
using UnityEngine;

public class PositionInitialize : MonoBehaviour
{
    public Camera camera;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        camera = transform.GetComponent<Camera>();
        target = Challenge.root;
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void LeftUpFront()
    {
        float xloc = GetSize.Size(target).x;
        float yloc = GetSize.Size(target).y;
        float zloc = GetSize.Size(target).z;
        float distance = Mathf.Sqrt(xloc * xloc + zloc * zloc) / camera.aspect;
        distance /= (2.0f * Mathf.Tan(0.5f * camera.fieldOfView * Mathf.Deg2Rad));
        float angle = Mathf.Atan(xloc / zloc);
        transform.position = new Vector3(-distance * Mathf.Sin(angle), distance/Mathf.Tan(60 * Mathf.Deg2Rad), -distance * Mathf.Cos(angle));
        transform.LookAt(target.transform);
    }

    public void LeftUpBack()
    {
        float xloc = GetSize.Size(target).x;
        float yloc = GetSize.Size(target).y;
        float zloc = GetSize.Size(target).z;
        float distance = Mathf.Sqrt(xloc * xloc + zloc * zloc) / camera.aspect;
        distance /= (2.0f * Mathf.Tan(0.5f * camera.fieldOfView * Mathf.Deg2Rad));
        float angle = Mathf.Atan(xloc / zloc);
        transform.position = new Vector3(-distance * Mathf.Sin(angle), distance/Mathf.Tan(60 * Mathf.Deg2Rad), distance * Mathf.Cos(angle));
        transform.LookAt(target.transform);
    }

    public void RightUpFront()
    {
        float xloc = GetSize.Size(target).x;
        float yloc = GetSize.Size(target).y;
        float zloc = GetSize.Size(target).z;
        float distance = Mathf.Sqrt(xloc * xloc + zloc * zloc) / camera.aspect;
        distance /= (2.0f * Mathf.Tan(0.5f * camera.fieldOfView * Mathf.Deg2Rad));
        float angle = Mathf.Atan(xloc / zloc);
        transform.position = new Vector3(distance * Mathf.Sin(angle), distance/Mathf.Tan(60 * Mathf.Deg2Rad), -distance * Mathf.Cos(angle));
        transform.LookAt(target.transform);
    }

    public void RightUpBack()
    {
        float xloc = GetSize.Size(target).x;
        float yloc = GetSize.Size(target).y;
        float zloc = GetSize.Size(target).z;
        Debug.Log("xloc "+ xloc);
        Debug.Log("zloc "+ zloc);
        float distance = Mathf.Sqrt(xloc * xloc + zloc * zloc) / camera.aspect;
        distance /= (2.0f * Mathf.Tan(0.5f * camera.fieldOfView * Mathf.Deg2Rad));
        distance *= 1.15f;
        float angle = Mathf.Atan(xloc / zloc);
        Debug.Log("atan(xloc/zloc) "+ Mathf.Atan(xloc / zloc));
        transform.position = new Vector3(distance * Mathf.Sin(angle), distance/Mathf.Tan(60 * Mathf.Deg2Rad), distance * Mathf.Cos(angle));
        transform.LookAt(target.transform);
    }

    public void Center()
    {
        float xloc = GetSize.Size(target).x / 2; 
        float yloc = GetSize.Size(target).y / 2; 
        float zloc = GetSize.Size(target).z / 2;
        float distance = Mathf.Max(xloc * 2, yloc * 2, zloc * 2) / camera.aspect;
        distance /= (2.0f * Mathf.Tan(0.5f * camera.fieldOfView * Mathf.Deg2Rad));
        transform.position = new Vector3(0, distance/Mathf.Tan(60 * Mathf.Deg2Rad), -distance * Mathf.Sin(60 * Mathf.Deg2Rad) - zloc);
        transform.LookAt(target.transform);
    }
}
