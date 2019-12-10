using System.Xml;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Linq;
using IBM.Watson.DeveloperCloud.Logging;
using Debug = UnityEngine.Debug;

public class Challenge : MonoBehaviour {
	XmlDocument document = new XmlDocument();
	public static string xml_name;
	public static string id;
	public static bool aF = false;
	public static GameObject root;
	public static Stack<string> idInfo = new Stack<string>();
	public static Stack<string> destInfo = new Stack<string>();
	public static Stack<bool> aFlag = new Stack<bool>();
	public static Stack<string> aDestInfo = new Stack<string>();
	// Use this for initialization

	/*[SerializeField, Range(0, 5)]
	int[] counts;   GUI*/
	
	void Start ()
	{
		//レンダリングが完了するまでの時間計測 5~8secかかってる……
		
		System.Diagnostics.Stopwatch sW = new System.Diagnostics.Stopwatch();
		sW.Start();
		
		if (NumericAttribute.sFilterGUI == null && NumericAttribute.iFFilterGUI == null && NumericAttribute.cBFilterGUI == null &&
		    StringAttribute.iFFilterGUI == null && StringAttribute.cBFilterGUI == null)
		{
			NumericAttribute.iFFilterGUI = GameObject.Find("NFilterSet_InputField").gameObject;
			NumericAttribute.iFFilterGUI.SetActive(false);
			StringAttribute.iFFilterGUI = GameObject.Find("SFilterSet_InputField").gameObject;
			StringAttribute.iFFilterGUI.SetActive(false);
			NumericAttribute.sFilterGUI = GameObject.Find("NFilterSet_SlideBar").gameObject;
			NumericAttribute.sFilterGUI.SetActive(false);
			NumericAttribute.cBFilterGUI = GameObject.Find("NFilterSet_CheckBox").gameObject;
			NumericAttribute.cBFilterGUI.SetActive(false);
			StringAttribute.cBFilterGUI = GameObject.Find("SFilterSet_CheckBox").gameObject;
			StringAttribute.cBFilterGUI.SetActive(false);
		}

		if (CreateCheckBoxList.filterList == null && CreateCheckBoxList.listParent == null && CreateCheckBoxList.lPRect == null)
		{
			CreateCheckBoxList.filterList = GameObject.Find("FilterListGUI").gameObject;
			CreateCheckBoxList.listParent = CreateCheckBoxList.filterList.transform.Find("Scroll View").Find("Viewport").Find("ListContent").gameObject;
			CreateCheckBoxList.lPRect = CreateCheckBoxList.listParent.GetComponent<RectTransform>();
			CreateCheckBoxList.filterList.SetActive(false);
		}

		if (SelectDropDown.faSet.Count > 0)
		{
			SelectDropDown.faSet.Clear();
			SelectDropDown.faSet.TrimExcess();
		}

		if (xml_name == null)
		{
			StreamReader sr = new StreamReader("ssql.properties");
			xml_name = sr.ReadLine();
			sr.Close();
		}

		if (id == null)
		{
			id = "0";
		}
		
		document.Load (xml_name);
		
		XmlElement element = document.DocumentElement;

		CreateObject.createButtonFlag = false;
		
		root = CreateObject.MakeObject(element);
		
		if (Grouper.localPositionObjectList.Count > 0)
		{
			foreach (GameObject lPObject in Grouper.localPositionObjectList)
			{
				lPObject.transform.localPosition = lPObject.GetComponent<DecidePosition>().GetPosition();
			}
			Grouper.localPositionObjectList.Clear();
		} 
		
		if (Grouper.worldPositionObjectList.Count > 0)
		{
			foreach (GameObject wPObject in Grouper.worldPositionObjectList)
			{
				wPObject.transform.position = wPObject.GetComponent<DecidePosition>().GetPosition();
			}
			Grouper.worldPositionObjectList.Clear();
		}
		
		if (Connector.localPositionObjectList.Count > 0)
		{
			foreach (GameObject lPObject in Connector.localPositionObjectList)
			{
				lPObject.transform.localPosition = lPObject.GetComponent<DecidePosition>().GetPosition();
			}
			Connector.localPositionObjectList.Clear();
		} 
		
		if (Connector.worldPositionObjectList.Count > 0)
		{
			foreach (GameObject wPObject in Connector.worldPositionObjectList)
			{
				wPObject.transform.position = wPObject.GetComponent<DecidePosition>().GetPosition();
				Debug.Log("position" + wPObject.transform.position);
			}
			Connector.worldPositionObjectList.Clear();
		}
		
		sW.Stop();
		Debug.Log("The sum number of object " + CreateObject.objectNumber);
		CreateObject.objectNumber = 0;
		Debug.Log("Elapsed Time: " + sW.ElapsedMilliseconds + "ms");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
