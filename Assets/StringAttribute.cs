using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StringAttribute : FilterAttribute
{
    public static GameObject iFFilterGUI;
    public static GameObject cBFilterGUI;
    [SerializeField] private string firstValue;
    [SerializeField] private string lastValue;
    private string filterPattern;
    private CreateCheckBoxList cBL;
    public HashSet<string> valueSet = new HashSet<string>();
    
    public StringAttribute(string aName, string str, string pattern) : base(aName, pattern)
    {
        lastValue = str;
    }

    public override void ShowSFilter()
    {
    }
    
    public override void ShowIFFilter()
    {
        ResetGUI();
        iFFilterGUI.GetComponentInChildren<StringFilterUI>().SetAttribute(this);
        iFFilterGUI.SetActive(true);
    }

    public override void ShowCBFilter()
    {
        ResetGUI();
        cBFilterGUI.GetComponentInChildren<StringFilterUI>().SetAttribute(this);
        cBFilterGUI.SetActive(true);
        cBL = cBFilterGUI.transform.Find("Scroll View").Find("Viewport").Find("SContent").gameObject.GetComponent<CreateCheckBoxList>();
        cBL.CreateStringCheckBox(valueSet);
    }

    public override void AddValue(object newValue)
    {
        if (newValue is string)
        {
            lastValue = (string)newValue;
        }
    }

    public override string GetStartValue()
    {
        return firstValue;
    }
    
    public override string GetEndValue()
    {
        return lastValue;
    }
    
    public override void CreateValueList(string value)
    {
        valueSet.Add(value);
    }

    public override void SetFirstValue(object fValue)
    {
        firstValue = fValue.ToString();
    }

    public void CloseIFGUI()
    {
        iFFilterGUI.SetActive(false);
    }
    
    public void CloseCBGUI()
    {
        cBFilterGUI.SetActive(false);
    }
    
}
