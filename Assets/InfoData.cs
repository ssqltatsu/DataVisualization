using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoData : MonoBehaviour
{
    public string s_name;
    public float size;
    private string popupText = "";
    
    public static Dictionary<string, float> attributelist;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InputData(string str, float num, object obj){
        s_name = str;
        size = num;
        attributelist = new Dictionary<string, float>();
        attributelist.Add(s_name, size);
    }

    public void InputData(float num, object obj){
        size = num;
    }

    public void CreatePanelText(string attribute, string value)
    {
        //全てのvalueをここに足して入れていく。
        popupText += attribute + ": " + value + "\n";
    }

    public string GetPopupText()
    {
        return popupText;
    }
}
