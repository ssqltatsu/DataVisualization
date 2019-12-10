using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Connector:MonoBehaviour
{
	public static List<GameObject> localPositionObjectList = new List<GameObject>();
	public static List<GameObject> worldPositionObjectList = new List<GameObject>();
	void Start ()
	{

	}

	void Update ()
	{
	}

	public static GameObject MakeObject (XmlElement element)
	{
		float space = 0;
		float margin = 1.1f;
		GameObject connector = new GameObject ("Connector");
		GameObject wrapper = CreateObject.CreateWrapper();
		TimeGrouper tG = null;
		GameObject o = null;

		if (element.GetAttribute("type").Equals("C4"))
		{
			float timeRange = 3f;
			if (!element.GetAttribute("timerange").Equals(""))
			{
				timeRange = float.Parse(element.GetAttribute("timerange"));
			}
			tG = connector.AddComponent<TimeGrouper>();
			tG.SetTiming(timeRange);
		}

		foreach (XmlElement child in element) {
			o = CreateObject.MakeObject (child);
			o.transform.parent = connector.transform;
			if (!o.GetComponent<DecidePosition>())
			{
				switch (element.GetAttribute("type"))
				{
					case "C1":
						o.transform.position = new Vector3(GetSize.Size(o).x / 2 + space, 0, 0);
						space += GetSize.Size(o).x * margin;
						break;

					case "C2":
						o.transform.position = new Vector3(0, GetSize.Size(o).y / 2 + space, 0);
						space += GetSize.Size(o).y * margin;
						break;

					case "C3":
						o.transform.position = new Vector3(0, 0, GetSize.Size(o).z / 2 + space);
						space += GetSize.Size(o).z * margin;
						break;

					case "C4":
						tG.AddChangeObject(o);
						break;
				}
			}
			else
			{
				DecidePosition dP = o.GetComponent<DecidePosition>();
				if (dP.GetPosFlag().Equals(true))
				{
					//localpostionを持つ時
					localPositionObjectList.Add(o);
				}
				else if (dP.GetWorldPosFlag().Equals(true))
				{
					//worldpositionを持つ時
					worldPositionObjectList.Add(o);
				}
			}

		}

		connector.transform.parent = wrapper.transform;
		switch (element.GetAttribute("type")){
		case "C1":
			connector.transform.position = Vector3.right * (-GetSize.Size (connector).x / 2); //wrapperに対するconnectorの相対的な位置 pivotを中心になるように
			break;

		case "C2":
			connector.transform.position = Vector3.up * (-GetSize.Size (connector).y / 2);
			break;

		case "C3":
			connector.transform.position = Vector3.forward * (-GetSize.Size (connector).z / 2);
			break;
		// case C4はその場にできるからそのまま
		}

		return wrapper;

	}

}
