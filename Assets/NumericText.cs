using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumericText : MonoBehaviour
{
    //Slider has this.
    
    private Text min;
    private Text max;
    private Text present;
    private Slider slid;
    private NumericAttribute nA;

    public void Start()
    {
        slid = this.gameObject.GetComponent<Slider>();
        min = this.transform.GetChild(3).GetComponent<Text>();
        max = this.transform.GetChild(4).GetComponent<Text>();
        present = this.transform.GetChild(5).GetComponent<Text>();
    }

    public void SetStartValue()
    {
        min.text = slid.minValue.ToString();
        Debug.Log("min.text: "+min.text);
        max.text = slid.maxValue.ToString();
        Debug.Log("min.text after max: "+min.text);
    }
    
    public void setPresentValueOnSlider(Single iValue)
    {
        present.text = iValue.ToString();
    }

    public void SetSliderMaxMin(double minValue, double maxValue)
    {
        slid.minValue = (float)minValue;
        slid.maxValue = (float)maxValue;
        slid.value = slid.minValue;
    }
}
