using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NumericFilterUI : MonoBehaviour
{
    private double iValue;
    private int filterType;
    private double minValueOnCheckBoxList;
    private double maxValueOnCheckBoxList;
    private HashSet<double> iCBValue = new HashSet<double>();
    private NumericAttribute nA;
    

    public void SetValue(string uiValue)
    {
        //for inputfield
        iValue = double.Parse(uiValue);
    }

    public void SetDValue(Single uiValue)
    {
        //for slider
        iValue = double.Parse(uiValue.ToString());
    }
    
    public void AddCBValue(string iValue)
    {
        this.iValue = double.Parse(iValue);
        iCBValue.Add(this.iValue);
    }

    public void RemoveCBValue(string iValue)
    {
        this.iValue = double.Parse(iValue);
        iCBValue.Remove(this.iValue);
    }
    
    public double GetMaxOnCheckBoxList()
    {
        maxValueOnCheckBoxList = iCBValue.Max();
        return maxValueOnCheckBoxList;
    }
    
    public double GetMinOnCheckBoxList()
    {
        minValueOnCheckBoxList = iCBValue.Min();
        return minValueOnCheckBoxList;
    }
    
    public void SetAttribute(NumericAttribute nA)
    {
        this.nA = nA;
    }

    public void SetFilterType(int type)
    {
        filterType = type;
    }

    

    public void ApplyFilter()
    {
        Filter fil = new NumericFilter(nA, iValue, filterType);
        Filter.filters.Add(fil);
        Filter.ApplyFilter(Challenge.root);
    }

    public void ApplyCBFilter()
    {
        Filter fil = new NumericFilter(nA, new HashSet<double>(iCBValue), filterType);
        Filter.filters.Add(fil);
        Filter.ApplyFilter(Challenge.root);
        iCBValue.Clear();
    }

    public void CloseSGUI()
    {
        nA.CloseSGUI();
    }
    
    public void CloseIFGUI()
    {
        nA.CloseIFGUI();
    }

    public void CloseCBGUI()
    {
        nA.CloseCBGUI();
    }

}
