using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.Serialization;

public class Filterable : MonoBehaviour
{ 
    public List<FilterAttribute> fAList = new List<FilterAttribute>();
   [SerializeField] private object inputValue;
   [SerializeField] private double attributeValue;
   [SerializeField] private double filterValue;
   [SerializeField] private string attributeSValue;
   [SerializeField] private string filterSValue;
   public void SetValue(object value)
    {
        //ゲームオブジェクトが持つフィルターをかける値
        inputValue = value;
    }

    public object getValue()
    {
        return inputValue;
    }
    
    public void SetAttribute(FilterAttribute fA)
    {
        fAList.Add(fA);
    }
}
