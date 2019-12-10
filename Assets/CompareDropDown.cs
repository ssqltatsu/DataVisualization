using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompareDropDown : MonoBehaviour
{
    [SerializeField] private Dropdown dropdown;
    OpenCameraButton ocb;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GameObject.Find("Compare").GetComponent<Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Select(int value)
    {
        switch (value)
        {
            case 0 : 
                // Filter Function
                break;
            
            case 1 :
                break;
            
            case 2 :
                break;
            
            case 3 :
                break;
            
            case 4 :
                break;
            
            case 5 :
                break;
            
            case 6 :
                break;
        }
    }
}