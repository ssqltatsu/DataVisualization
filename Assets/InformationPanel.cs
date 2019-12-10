using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
{   
    private GameObject canv;
    public static GameObject panel;
    private GameObject text;
    private Text ctext;
    private InfoData iD;
    // Start is called before the first frame update
    void Start()
    {
        canv = GameObject.Find("Canvas");
        panel = canv.transform.GetChild(1).gameObject;
        text = panel.transform.GetChild(0).gameObject;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPanel(GameObject obj)
    {
        iD = obj.GetComponent<InfoData>();
        ctext = text.GetComponent<Text>();
        ctext.text = iD.GetPopupText();
        panel.SetActive(true);
    }

    public GameObject GetPanel()
    {
        return panel;
    }
}
