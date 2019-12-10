using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Grouper : MonoBehaviour
{
	public static List<GameObject> localPositionObjectList = new List<GameObject>();
	public static List<GameObject> worldPositionObjectList = new List<GameObject>();

	public static GameObject MakeObject(XmlElement element)
	{
		float space = 0;
		float margin = 10;

		if (!element.GetAttribute("margin").Equals(""))
		{
			margin = float.Parse(element.GetAttribute("margin"));
		}

		GameObject grouper = new GameObject("Grouper");
//		GizmosCube cube = grouper.AddComponent<GizmosCube> () as GizmosCube;
//		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		GameObject wrapper = CreateObject.CreateWrapper();
		List<GameObject> circleObjectList = new List<GameObject>();
		TimeGrouper tG = null;
		GameObject o = null;

		if (element.GetAttribute("type").Equals("G4"))
		{
			float timeRange = 3f;
			if (!element.GetAttribute("timerange").Equals(""))
			{
				timeRange = float.Parse(element.GetAttribute("timerange"));
			}
			tG = grouper.AddComponent<TimeGrouper>();
			tG.SetTiming(timeRange);
		}
		
		foreach (XmlElement child in element)
		{
			o = CreateObject.MakeObject(child);
			if (o == null)
			{
				continue;
			}

			o.transform.parent = grouper.transform;

			if (!o.GetComponent<DecidePosition>())
			{
				switch (element.GetAttribute("type"))
				{
					case "G1":
						o.transform.position = new Vector3(GetSize.Size(o).x / 2 + space, GetSize.Size(o).y / 2,
							GetSize.Size(o).z / 2);
						space += GetSize.Size(o).x + margin;
						break;

					case "G2":
						o.transform.position = new Vector3(GetSize.Size(o).x / 2, GetSize.Size(o).y / 2 + space,
							GetSize.Size(o).z / 2);
						space += GetSize.Size(o).y + margin;
						break;

					case "G3":
						o.transform.position = new Vector3(GetSize.Size(o).x / 2, GetSize.Size(o).y / 2,
							GetSize.Size(o).z / 2 + space);
						space += GetSize.Size(o).z + margin;
						break;

					case "G4":
						//time axis
						tG.AddChangeObject(o);
						break;

					case "G5":
						//circle axis
						//Search max of radius 
						circleObjectList.Add(o);
						break;
				}
			}
			else
			{
				DecidePosition dP = o.GetComponent<DecidePosition>();
				if (dP.GetPosFlag().Equals(true))
				{
					//localpositionを持つ時
					localPositionObjectList.Add(o);
				} else if (dP.GetWorldPosFlag().Equals(true))
				{
					//worldpositionを持つ時
					worldPositionObjectList.Add(o);
				}
			}
		}

		if (element.GetAttribute("type").Equals("G5"))
		{
			float theta = 2.0f * Mathf.PI / circleObjectList.Count;
			double radius = 0;
			float dMax = 0;
			
			foreach (GameObject obj in circleObjectList)
			{
				float d = 0;
				if (element.GetAttribute("axis").Equals("y"))
				{
					d = Mathf.Pow(GetSize.Size(obj).x, 2) + Mathf.Pow(GetSize.Size(obj).z, 2);
				}
				else if (element.GetAttribute("axis").Equals("x"))
				{
					d = Mathf.Pow(GetSize.Size(obj).y, 2) + Mathf.Pow(GetSize.Size(obj).z, 2);
				}
				else if (element.GetAttribute("axis").Equals("z"))
				{
					d = Mathf.Pow(GetSize.Size(obj).x, 2) + Mathf.Pow(GetSize.Size(obj).y, 2);
				}

				if (dMax < d)
				{
					dMax = d;
				}
			}

			dMax = Mathf.Sqrt(dMax) / 2;
			radius = (2 * dMax + margin) /
			         (Math.Sqrt(Mathf.Pow(1 - Mathf.Cos(theta), 2) + Mathf.Pow(Mathf.Sin(theta), 2)));

			for (int i = 0; i < circleObjectList.Count; i++)
			{
				if (element.GetAttribute("axis").Equals("y"))
				{
					circleObjectList[i].transform.position = new Vector3((float) radius + (float) radius * Mathf.Cos(i * theta), 0,
						(float) radius + (float) radius * Mathf.Sin(i * theta));
				}
				else if (element.GetAttribute("axis").Equals("x"))
				{
					circleObjectList[i].transform.position = new Vector3(0, (float) radius + (float) radius * Mathf.Sin(i * theta),
						(float) radius + (float) radius * Mathf.Cos(i * theta));
				}
				else if (element.GetAttribute("axis").Equals("z"))
				{
					circleObjectList[i].transform.position = new Vector3((float) radius + (float) radius * Mathf.Cos(i * theta),
						(float) radius +(float) radius * Mathf.Sin(i * theta), 0);
				}
			}
		}
		grouper.transform.parent = wrapper.transform;
		grouper.transform.position = -GetSize.Size(grouper) / 2;
		
//		if (localPositionObjectList.Count > 0)
//		{
//			foreach (GameObject lPObject in localPositionObjectList)
//			{
//				lPObject.transform.localPosition = lPObject.GetComponent<DecidePosition>().GetPosition();
//				lPObject.transform.SetParent(null, true);
//			}
//		} else if (worldPositionObjectList.Count > 0)
//		{
//			foreach (GameObject wPObject in worldPositionObjectList)
//			{
//				wPObject.transform.position = wPObject.GetComponent<DecidePosition>().GetPosition();
//				wPObject.transform.SetParent(null, true);
//			}
//		}
//		
		return wrapper;
	}
}


