using System.Collections;
using System.Collections.Generic;
using IBM.Watson.DeveloperCloud.Logging;
using UnityEngine;

public class NumericAttribute : FilterAttribute
{
    public double minValue;
    public double maxValue;
    public double firstValue;
    public static GameObject sFilterGUI;
    public static GameObject iFFilterGUI;
    public static GameObject cBFilterGUI;
    private NumericText slidNT;
    private CreateCheckBoxList cBL;
    public HashSet<string> valueSet = new HashSet<string>();
    
    public NumericAttribute(string aName, double fValue, string pattern) : base(aName, pattern)
    {
        //属性名が同じ時同じ
        firstValue = fValue;
        minValue = fValue;
        maxValue = fValue;
    }
    
    public override void ShowSFilter()
    {
        ResetGUI();
        sFilterGUI.GetComponentInChildren<NumericFilterUI>().SetAttribute(this);
        sFilterGUI.SetActive(true);
        slidNT = sFilterGUI.transform.Find("Slider").gameObject.GetComponent<NumericText>();
        slidNT.SetSliderMaxMin(this.GetMinValue(), this.GetMaxValue());
        slidNT.SetStartValue();
    }
    
    public override void ShowIFFilter()
    {
        ResetGUI();
        iFFilterGUI.GetComponentInChildren<NumericFilterUI>().SetAttribute(this);
        iFFilterGUI.SetActive(true);
    }
    
    public override void ShowCBFilter()
    {
        ResetGUI();
        cBFilterGUI.GetComponentInChildren<NumericFilterUI>().SetAttribute(this);
        cBFilterGUI.SetActive(true);
        cBL = cBFilterGUI.transform.Find("Scroll View").Find("Viewport").Find("NContent").gameObject.GetComponent<CreateCheckBoxList>();
        cBL.CreateNumericCheckBox(valueSet);
    }
    
    
    public override void AddValue(object newValue)
    {
        if (newValue is double)
        {
            double doubleValue = (double)newValue;
            if( doubleValue < minValue) {
                minValue = doubleValue;
            }
            if (maxValue < doubleValue) {
                maxValue = doubleValue;
            }
        }
        else
        {
            Debug.LogError("Couldn't add Value: " + newValue + "to: " + this);
        }
    }
    
    public override double GetMinValue()
    {
        return minValue;
    }

    public override double GetMaxValue()
    {
        return maxValue;
    }

    public override void CreateValueList(string value)
    {
        valueSet.Add(value);
    }

    public override void SetFirstValue(object fValue)
    {
        firstValue = (double)fValue;
    }

    public void CloseSGUI()
    {
        sFilterGUI.SetActive(false);
    }
    
    public void CloseIFGUI()
    {
        iFFilterGUI.SetActive(false);
    }
    
    public void CloseCBGUI()
    {
        cBFilterGUI.SetActive(false);
    }

    public double GetValue()
    {
        return firstValue;
    }
}
