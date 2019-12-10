using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    private InformationPanel ip;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        ip = InformationPanel.panel.GetComponent<InformationPanel>();
        obj = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnMouseOver()
    {
        // cont.CreateContour(); 
        if (Input.GetKey(KeyCode.LeftCommand))
        {
            ip.SetPanel(obj);
        }
    }
}
