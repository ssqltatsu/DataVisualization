using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateCheckBoxList : MonoBehaviour
{
    //Content in CheckBox has this.
    private GameObject cBT;
    private GameObject checkBox;
    private GameObject parentN;
    private GameObject parentS;
    private RectTransform pNRect;
    private Text text;
    private NumericFilterUI nFUI;
    private StringFilterUI sFUI;
    private Toggle textToggle;
    private HashSet<string> textList;
    public static GameObject filterList;
    public static GameObject listParent;
    public static RectTransform lPRect;
    public static GameObject filterCheckBox;
    public static List<GameObject> filtercheckBoxList = new List<GameObject>(); 
    
    // Start is called before the first frame update
    void Start()
    {
        parentN = this.gameObject;
        pNRect = parentN.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateNumericCheckBox(HashSet<string> valueList)
    {
        float startPoint = 0;
        pNRect.sizeDelta = new Vector2(0, 30 * valueList.Count);
        nFUI = NumericAttribute.cBFilterGUI.transform.Find("NumericFilterUI").GetComponent<NumericFilterUI>();

        foreach (var content in valueList)
        {
            checkBox = Instantiate((GameObject) Resources.Load("CheckBoxText"), parentN.transform);
            checkBox.name = "CheckBoxText";
            checkBox.GetComponentInChildren<Text>().text = content;
            checkBox.transform.localPosition = new Vector3(checkBox.transform.localPosition.x,
                    startPoint - pNRect.sizeDelta.y, checkBox.transform.localPosition.z);
            GameObject tempCheckBox = checkBox;
            checkBox.GetComponent<Toggle>().onValueChanged.AddListener((bool b) =>
            { 
                tempCheckBox.GetComponent<CheckBoxText>().OnToggleNumeric(b, nFUI);
            });
            startPoint += 30;
        }
    }
    
    public void CreateStringCheckBox(HashSet<string> valueList)
    {
        float startPoint = 0;
        
        pNRect.sizeDelta = new Vector2(0, 30 * valueList.Count);
        sFUI = StringAttribute.cBFilterGUI.transform.Find("StringFilterUI").GetComponent<StringFilterUI>();
        foreach (var content in valueList)
        {
            checkBox = Instantiate((GameObject)Resources.Load("CheckBoxText"), parentN.transform);
            checkBox.name = "CheckBoxText";
            checkBox.GetComponentInChildren<Text>().text = content;
            checkBox.transform.localPosition = new Vector3(checkBox.transform.localPosition.x, startPoint - pNRect.sizeDelta.y, checkBox.transform.localPosition.z);
            GameObject tempCheckBox = checkBox;
            checkBox.GetComponent<Toggle>().onValueChanged.AddListener((bool b) => {tempCheckBox.GetComponent<CheckBoxText>().OnToggleString(b, sFUI);});
            startPoint += 30;
        }
    }

    public static void CreateFilterList(List<Filter> filterList)
    {
        if (filtercheckBoxList?.Count > 0)
        {
            //filterlistを一度リセット
            foreach (GameObject removeFilterCheckBox in filtercheckBoxList)
            {
                Destroy(removeFilterCheckBox);
            }
        }
        float startPoint = 0;
        lPRect.sizeDelta = new Vector2(0, 30 * filterList.Count);

        foreach (var filter in filterList)
        {
            filterCheckBox = Instantiate((GameObject) Resources.Load("CheckBoxText"), listParent.transform);
            filterCheckBox.name = "CheckBoxText";
            //text is Attribute ??? >= value
            filterCheckBox.GetComponentInChildren<Text>().text = filter.ToString();
            filterCheckBox.transform.localPosition = new Vector3(filterCheckBox.transform.localPosition.x - 130,
                startPoint - lPRect.sizeDelta.y, filterCheckBox.transform.localPosition.z);
            GameObject tempCheckBox = filterCheckBox;
            filterCheckBox.GetComponent<Toggle>().onValueChanged.AddListener((bool b) =>
            {
                tempCheckBox.GetComponent<CheckBoxText>().OnToggleFilter(b, filter);
            });
            filtercheckBoxList.Add(tempCheckBox);
            startPoint += 30;
        }
    }

    public void ConcernTextList()
    {
        foreach (string s in textList)
        {
            Debug.Log(s);
        }
    }

    public int ContentsNumber(HashSet<string> valueList)
    {
        int number = 0;

        foreach (var s in valueList)
        {
            number += 1;
        }
        return number;
    }

    public static void OnFilterList()
    {
        filterList.SetActive(true);
    }
    
    public void CloseFilterGUI()
    {
        filterList.SetActive(false);
    }
    
    public void RemoveFilter()
    {
        foreach (Filter remove in Filter.filtersToRemove)
        {
            Filter.filters.Remove(remove);  
        }
        Filter.ApplyFilterForNonActive(Challenge.root);
        Filter.ApplyFilter(Challenge.root);
        Filter.filtersToRemove.Clear();
        CreateFilterList(Filter.filters);
        //filterのlistはハッシュセットの方がいい? 
        //filterの対象を輝かせてわかりやすくする
    }

}