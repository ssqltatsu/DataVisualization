using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public GameObject obj;
    public PositionInitialize pi;
    public ClosePanel cp;

    public void Start()
    {
        obj = GameObject.Find("Main Camera");
        pi = obj.GetComponent<PositionInitialize>();
    }

    public void OnClickLUF()  
    {
        pi.LeftUpFront();
    }

    public void OnClickLUB()  
    {
        pi.LeftUpBack();
    }

    public void OnClickRUF()  
    {
        pi.RightUpFront();
    }

    public void OnClickRUB()  
    {
        pi.RightUpBack();
    }

    public void OnClickCenter()  
    {
        pi.Center();
    }

    public void OnClickClose()
    {
        cp = GetComponent<ClosePanel>();
        cp.DeletePanel();
    }

    public void SetMinValue()
    {
        
    }

    public void SetMaxValue()
    {
        
    }
}
