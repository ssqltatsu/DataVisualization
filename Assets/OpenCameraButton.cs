using System;
using System.Collections.Generic;
using System.Collections;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class OpenCameraButton : UnityEngine.MonoBehaviour
{
    private GameObject pButton;
    private GameObject fButton;
    public void Start()
    {
        foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if (obj.name.Equals("PButton"))
            {
                pButton = obj;
            }

            if (obj.name.Equals("AttributeDropdown"))
            {
                fButton = obj;
            }
        }
    }

    public void Update()
    {
        
    }

    public void OnCameraButton()
    {
      pButton.SetActive(true);
    }
    
    public void OffCameraButton()
    { 
        pButton.SetActive(false);
    }

    public void OnFilterButton()
    {
        fButton.SetActive(true);
    }

    public void OffFilterButton()
    {
        fButton.SetActive(false);
    }
}