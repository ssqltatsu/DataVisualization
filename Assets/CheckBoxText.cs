using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBoxText : MonoBehaviour
{
    private string cBText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string CheckText()
    {
        return cBText;
    }

    public void OnToggleNumeric(bool b, NumericFilterUI nFUI)
    {
        cBText = this.gameObject.transform.GetChild(1).GetComponent<Text>().text;
        if (b)
        {
            nFUI.AddCBValue(cBText);
        }
        else
        {
            nFUI.RemoveCBValue(cBText);
        }
    }
    
    public void OnToggleString(bool b, StringFilterUI sFUI)
    {
        cBText = this.gameObject.transform.GetChild(1).GetComponent<Text>().text;
        if (b)
        {
            sFUI.AddCBValue(cBText);
        }
        else
        {
            sFUI.RemoveCBValue(cBText);
        }
    }

    public void OnToggleFilter(bool b, Filter fil)
    {
        if (b)
        {
            Filter.filtersToRemove.Add(fil);
        }
        else
        {
            Filter.filtersToRemove.Remove(fil);
        }
    }
}
