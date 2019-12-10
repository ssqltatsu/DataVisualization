using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringFilterUI : MonoBehaviour
{
    private string iString;
    private int filterType;
    private StringAttribute sA;
    private HashSet<string> iCBValue = new HashSet<string>();

    public void SetValue(string uiString)
    {
        iString = uiString;
    }

    public void SetAttribute(StringAttribute sA)
    {
        this.sA = sA;
    }

    public StringAttribute GetAttribute()
    {
        return this.sA;
    }
    
    public void AddCBValue(string iValue)
    {
        iCBValue.Add(iValue);
    }

    public void RemoveCBValue(string iValue)
    {
        iCBValue.Remove(iValue);
    }

    public void SetFilterType(int type)
    {
        filterType = type;
    }

    public void ApplyFilter()
    {
        Filter fil = new StringFilter(sA, iString, filterType);
        Filter.filters.Add(fil);
        Filter.ApplyFilter(Challenge.root);
    }

    public void ApplyCBFilter()
    {
        //iCBValueはチェックボックス内で選択されている値
        Filter fil = new StringFilter(sA, new HashSet<string>(iCBValue), filterType);
        Filter.filters.Add(fil);
        Filter.ApplyFilter(Challenge.root);
        iCBValue.Clear();
    }

    public void CloseIFGUI()
    {
        sA.CloseIFGUI();
    }
    
    public void CloseCBGUI()
    {
        sA.CloseCBGUI();
    }
}
