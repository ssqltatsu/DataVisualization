using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject text;
    public Text ctext;

    private InformationPanel infoPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeletePanel()
    {
        infoPanel = transform.parent.GetComponent<InformationPanel>();
        panel = infoPanel.GetPanel();
        text = panel.transform.GetChild(0).gameObject;
        ctext = text.GetComponent<Text>();
        ctext.text = "";
        panel.SetActive(false);
    }
}
