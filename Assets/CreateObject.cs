using System;
using System.Collections.Generic;
using System.Xml;
using DefaultNamespace;
using TMPro;
using UnityEditor.Compilation;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public static InfoData info;
    public static bool createButtonFlag = false;
    public static int objectNumber = 0;

    public static GameObject MakeObject(XmlElement element)
    {
	    GameObject obj = null;
	    GameObject targetObject = null;
	    Boolean falistFlag = false;
	    bool fType = false;
	    
	    if (Challenge.aF.Equals(true))
	    {
		    //anchorscene関数からこのシーンに遷移
		    if (createButtonFlag.Equals(false))
		    {
			    CreateGUI.CreateASceneBackButton("Back");
			    createButtonFlag = true;
		    }
	    } else
	    {
		    //scene関数からこのシーンに遷移
		    if (Challenge.aFlag.Count > 0)
		    {
			    //最初のシーンではボタンを作らない
			    if (createButtonFlag.Equals(false))
			    {
				    //ボタンは一度だけしか作らない
				    CreateGUI.CreateSceneBackButton("Back");
				    createButtonFlag = true;
			    }
			    
		    }
	    }

	    if (element.Name.Equals("plane"))
	    {
		    float attribute = float.Parse(element.GetAttribute("size"));
		    obj = GameObject.CreatePrimitive(PrimitiveType.Plane);
		    obj.transform.position = new Vector3(0, 0, 0);
		    obj.transform.localScale = new Vector3(attribute, 1, attribute); // オブジェクトのサイズ変更
		    if (!element.GetAttribute("size_name").Equals(""))
		    {
			    if (!obj.GetComponent<MouseOver>())
			    {
				    obj.AddComponent<MouseOver>();
			    }

			    if (!obj.GetComponent<InfoData>())
			    {
				    info = obj.AddComponent<InfoData>();
			    }
			    else
			    {
				    info = obj.GetComponent<InfoData>();
			    }

			    string s_name = element.GetAttribute("size_name");
			    string size = element.GetAttribute("size");
			    info.CreatePanelText(s_name, size);
		    }
	    }
	    else if (element.Name.Equals("cube"))
	    {
		    float attribute = float.Parse(element.GetAttribute("size"));
		    obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		    obj.transform.position = new Vector3(0, 0, 0);
		    obj.transform.localScale = new Vector3(1, 1, 1) * attribute; // オブジェクトのサイズ変更

		    if (!element.GetAttribute("csize_name").Equals(""))
		    {
			    if (!obj.GetComponent<MouseOver>())
			    {
				    obj.AddComponent<MouseOver>();
			    }

			    if (!obj.GetComponent<InfoData>())
			    {
				    info = obj.AddComponent<InfoData>();
			    }
			    else
			    {
				    info = obj.GetComponent<InfoData>();
			    }

			    string s_name = element.GetAttribute("csize_name");
			    string size = element.GetAttribute("size");
			    info.CreatePanelText(s_name, size);
		    }
	    }
	    else if (element.Name.Equals("torus"))
	    {
		    float r1 = float.Parse(element.GetAttribute("rOut"));
		    float r2 = float.Parse(element.GetAttribute("rIn"));
		    obj = Torus.Maketorus(r1, r2);
		    obj.transform.position = new Vector3(0, 0, 0);

		    if (!element.GetAttribute("rOutsize_name").Equals("") || !element.GetAttribute("rInsize_name").Equals(""))
		    {
			    if (!obj.GetComponent<MouseOver>())
			    {
				    obj.AddComponent<MouseOver>();
			    }

			    if (!obj.GetComponent<InfoData>())
			    {
				    info = obj.AddComponent<InfoData>();
			    }
			    else
			    {
				    info = obj.GetComponent<InfoData>();
			    }

			    string rOut_name = element.GetAttribute("rOutsize_name");
			    string rIn_name = element.GetAttribute("rInsize_name");
			    string rOut_size = element.GetAttribute("rOut");
			    string rIn_size = element.GetAttribute("rIn");
			    info.CreatePanelText(rOut_name, rOut_size);
			    info.CreatePanelText(rIn_name, rIn_size);
		    }
	    }
	    else if (element.Name.Equals("cuboid"))
	    {
		    float l_size = float.Parse(element.GetAttribute("l_size"));
		    float w_size = float.Parse(element.GetAttribute("w_size"));
		    float d_size = float.Parse(element.GetAttribute("d_size"));
		    obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		    obj.transform.position = new Vector3(0, 0, 0);
		    obj.transform.localScale = new Vector3(l_size, w_size, d_size);

		    if (!element.GetAttribute("lsize_name").Equals("") || !element.GetAttribute("wsize_name").Equals("") ||
		        !element.GetAttribute("dsize_name").Equals(""))
		    {
			    if (!obj.GetComponent<MouseOver>())
			    {
				    obj.AddComponent<MouseOver>();
			    }

			    if (!obj.GetComponent<InfoData>())
			    {
				    info = obj.AddComponent<InfoData>();
			    }
			    else
			    {
				    info = obj.GetComponent<InfoData>();
			    }

			    string lSize_name = element.GetAttribute("lsize_name");
			    string wSize_name = element.GetAttribute("wsize_name");
			    string dSize_name = element.GetAttribute("dsize_name");
			    string lSize = element.GetAttribute("lsize");
			    string wSize = element.GetAttribute("wsize");
			    string dSize = element.GetAttribute("dsize");
			    info.CreatePanelText(lSize_name, lSize);
			    info.CreatePanelText(wSize_name, wSize);
			    info.CreatePanelText(dSize_name, dSize);
		    }
	    }
	    else if (element.Name.Equals("pyramid"))
	    {
		    float height = float.Parse(element.GetAttribute("height"));
		    float size = float.Parse(element.GetAttribute("size"));
		    obj = Pyramid.MakePyramid(size, height);
		    obj.transform.position = new Vector3(0, 0, 0);

		    if (!element.GetAttribute("height_name").Equals("") || !element.GetAttribute("size_name").Equals(""))
		    {
			    if (!obj.GetComponent<MouseOver>())
			    {
				    obj.AddComponent<MouseOver>();
			    }

			    if (!obj.GetComponent<InfoData>())
			    {
				    info = obj.AddComponent<InfoData>();
			    }
			    else
			    {
				    info = obj.GetComponent<InfoData>();
			    }

			    string height_name = element.GetAttribute("height_name");
			    string size_name = element.GetAttribute("size_name");
			    string h = element.GetAttribute("height");
			    string s = element.GetAttribute("size");
			    info.CreatePanelText(height_name, h);
			    info.CreatePanelText(size_name, s);
		    }
	    }
	    else if (element.Name.Equals("sphere"))
	    {
		    float attribute = float.Parse(element.GetAttribute("size"));
		    obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		    obj.transform.position = new Vector3(0, 0, 0);
		    obj.transform.localScale = new Vector3(1, 1, 1) * attribute;
		    if (!element.GetAttribute("spsize_name").Equals(""))
		    {
			    if (!obj.GetComponent<MouseOver>())
			    {
				    obj.AddComponent<MouseOver>();
			    }

			    if (!obj.GetComponent<InfoData>())
			    {
				    info = obj.AddComponent<InfoData>();
			    }
			    else
			    {
				    info = obj.GetComponent<InfoData>();
			    }

			    string s_name = element.GetAttribute("spsize_name");
			    string size = element.GetAttribute("size");
			    info.CreatePanelText(s_name, size);
		    }

//			if (element.GetAttribute("filter").Equals("on"))
//            {
//	            f.SetValue(attribute);
//	            FilterAttribute fa;
//	            fa = new NumericAttribute(element.GetAttribute("size_name"), attribute);
//	            f.SetAttribute(fa);
//
//	            if (SelectDropDown.faSet.Contains(fa))
//	            {
//		            foreach (var mainFA in SelectDropDown.faSet)
//		            {
//			            if (mainFA.Equals(fa))
//			            {
//				            mainFA.AddValue((double)attribute);
//				            break;
//			            }
//		            }
//	            }
//	            else
//	            {
//		            SelectDropDown.faSet.Add(fa);
//	            }
//            }
	    }
	    else if (element.Name.Equals("text"))
	    {
		    float size = float.Parse(element.GetAttribute("size"));
		    obj = Instantiate(Resources.Load("Text")) as GameObject;
		    obj.GetComponent<TextMesh>().text = element.GetAttribute("contents");
		    obj.name = "Text";
		    obj.transform.localScale *= size;
		    obj.transform.position = new Vector3(0, 0, 0);
		    Determinetype dt = new Determinetype();

		    if (!element.GetAttribute("size_name").Equals("") || !element.GetAttribute("contents_name").Equals(""))
		    {
			    if (!obj.GetComponent<MouseOver>())
			    {
				    obj.AddComponent<MouseOver>();
			    }

			    if (!obj.GetComponent<InfoData>())
			    {
				    info = obj.AddComponent<InfoData>();
			    }
			    else
			    {
				    info = obj.GetComponent<InfoData>();
			    }

			    string s_name = element.GetAttribute("size_name");
			    string s = element.GetAttribute("size");
			    string c_name = element.GetAttribute("contents_name");
			    string c = element.GetAttribute("contents");

			    info.CreatePanelText(s_name, s);
			    info.CreatePanelText(c_name, c);
		    }

		    //Todo
//			bool b = dt.TypeIsNumeric(element.GetAttribute("contents"));

//			if (element.GetAttribute("filter").Equals("on"))
//			{
//				f.SetValue(element.GetAttribute("contents"));
//				FilterAttribute fa;
//				fa = new StringAttribute(element.GetAttribute("contents_name"), element.GetAttribute("contents"));
//				f.SetAttribute(fa);
//
//				if (SelectDropDown.faSet.Contains(fa))
//				{
//					foreach (var mainFA in SelectDropDown.faSet)
//					{
//						if (mainFA.Equals(fa))
//						{
////							mainFA.AddValue((double)attribute);
//							break;
//						}
//					}
//				}
//				else
//				{
//					SelectDropDown.faSet.Add(fa);
//				}
//			}
	    }
	    else if (element.Name.Equals("element"))
	    {
		    //kotani's stuff	
		    obj = Instantiate(Resources.Load(element.SelectNodes("id")[0].InnerText)) as GameObject;
	    }
	    else if (element.Name.StartsWith("Connector"))
	    {
		    obj = Connector.MakeObject(element);
	    }
	    else if (element.Name.StartsWith("Grouper"))
	    {
		    obj = Grouper.MakeObject(element);
	    }
	    else if (element.Name.Equals("Asset"))
	    {
		    //Use Asset
		    string name = element.GetAttribute("name");
		    float attribute = float.Parse(element.GetAttribute("size"));
		    string s_name = element.GetAttribute("asize_name");
		    obj = Instantiate(Resources.Load(name)) as GameObject;
		    obj.transform.position = new Vector3(0, 0, 0);
		    obj.transform.localScale = new Vector3(1, 1, 1) * attribute / GetSize.Size(obj).y;
		    CapsuleCollider capC = obj.AddComponent<CapsuleCollider>();
		    capC.radius = obj.transform.localScale.y * attribute;
		    capC.height = obj.transform.localScale.y;

		    if (!element.GetAttribute("asize_name").Equals(""))
		    {
			    if (!obj.GetComponent<MouseOver>())
			    {
				    obj.AddComponent<MouseOver>();
			    }

			    if (!obj.GetComponent<InfoData>())
			    {
				    info = obj.AddComponent<InfoData>();
			    }
			    else
			    {
				    info = obj.GetComponent<InfoData>();
			    }

			    string size = element.GetAttribute("size");
			    info.CreatePanelText(s_name, size);
		    }

		    //
//			if (element.GetAttribute("filter").Equals("on"))
//			{
//				f.SetValue(attribute);
//				FilterAttribute fa;
//				fa = new NumericAttribute(s_name, attribute);	
//				f.SetAttribute(fa);
//				
//				if (SelectDropDown.faSet.Contains(fa))
//				{
//					foreach (var mainFA in SelectDropDown.faSet)
//					{
//						if (mainFA.Equals(fa))
//						{
//							mainFA.AddValue((double)attribute);
//							break;
//						}
//					}
//				}
//				else
//				{
//					SelectDropDown.faSet.Add(fa);
//				}
//			}
	    }
	    else if (element.Name.Equals("foreach"))
	    {
		    if (createButtonFlag.Equals(false))
		    {
			    CreateGUI.CreateSceneBackButton("Back");
			    createButtonFlag = true;
		    }

		    string f_id = element.GetAttribute("id");
		    if (f_id == Challenge.id)
		    {
			    foreach (XmlElement f_child in element)
			    {
				    obj = MakeObject(f_child);
			    }
		    }
		    else
		    {
			    return null;
		    }
	    }

	    if (targetObject == null)
	    {
		    targetObject = obj;
	    }

	    obj = CreateOption(element, obj, targetObject);
	    
	    CreateFilter(element, obj);
	    objectNumber++;
	    return obj;
    }

    private static GameObject CreateOption(XmlElement element, GameObject obj, GameObject targetObject)
    {
	    foreach (XmlElement child in element)
	    {
		    GameObject oldTargetObject = targetObject;
		    string targetName = child.GetAttribute("target");

		    if (!targetName.Equals(""))
		    {
			    targetObject = FindInHierarchy(targetName, obj);
		    }

		    if (child.Name.Equals("color"))
		    {
			    ChangeColor(child.InnerText, targetObject);
		    }
		    else if (child.Name.Equals("gradient"))
		    {
			    string min_c = child.GetAttribute("min_c");
			    string max_c = child.GetAttribute("max_c");
			    float value = float.Parse(child.InnerText);
			    GradientColor gradient = targetObject.AddComponent<GradientColor>();
			    var att = element.InnerText.ToString();
			    double dValue = double.Parse(att);
			    Filterable f = obj.GetComponent<Filterable>();
			    if (!child.GetAttribute("gradient_name").Equals(""))
			    {
				    if (!obj.GetComponent<MouseOver>())
				    {
					    obj.AddComponent<MouseOver>();
				    }

				    if (!obj.GetComponent<InfoData>())
				    {
					    info = obj.AddComponent<InfoData>();
				    }
				    else
				    {
					    info = obj.GetComponent<InfoData>();
				    }

				    string g_name = child.GetAttribute("gradient_name");
				    string g_value = child.InnerText;
				    info.CreatePanelText(g_name, g_value);
			    }
//				if (child.GetAttribute("filter").Equals("on"))
//				{
//					f.SetValue(dValue);
//					FilterAttribute fa;
//					fa = new NumericAttribute(child.GetAttribute("gradient_name"), dValue);
//					f.SetAttribute(fa);
//					Debug.Log("outer: dValue = "+dValue);
//					if (SelectDropDown.faSet.Contains(fa))
//					{
//						Debug.Log("where?");
//						foreach (var mainFA in SelectDropDown.faSet)
//						{
//							if (mainFA.Equals(fa))
//							{
//								Debug.Log("I'm in last. + dValue = "+dValue);
//								mainFA.AddValue(dValue);
//								break;
//							}
//						}
//					}
//					else
//					{
//						SelectDropDown.faSet.Add(fa);
//					}
//				}

			    gradient.SetGradient(min_c, max_c, value);


		    }
		    else if (child.Name.Equals("image"))
		    {
			    string imageName = "Texture/" + child.GetAttribute("name");
			    MeshRenderer mesh = obj.GetComponent<MeshRenderer>();
			    if (element.Name.Equals("plane"))
			    {
				    //planeはy軸正方向をデフォルトで向いている
				    obj.transform.rotation = Quaternion.Euler(90, 180, 0);
			    }
			    else
			    {
				    obj.transform.rotation = Quaternion.Euler(0, 180, 0);
			    }

			    Material material = Resources.Load<Material>(imageName);
			    mesh.material = material;
		    }
		    else if (child.Name.Equals("rotate"))
		    {
			    float r_x = float.Parse(child.GetAttribute("x"));
			    float r_y = float.Parse(child.GetAttribute("y"));
			    float r_z = float.Parse(child.GetAttribute("z"));
			    Rotate rot = targetObject.AddComponent<Rotate>();
			    rot.SetRotation(r_x, r_y, r_z);
			    if (!child.GetAttribute("x_name").Equals("") || !child.GetAttribute("y_name").Equals("") ||
			        !child.GetAttribute("z_name").Equals(""))
			    {
				    if (!obj.GetComponent<MouseOver>())
				    {
					    obj.AddComponent<MouseOver>();
				    }

				    if (!obj.GetComponent<InfoData>())
				    {
					    info = obj.AddComponent<InfoData>();
				    }
				    else
				    {
					    info = obj.GetComponent<InfoData>();
				    }

				    string x_name = child.GetAttribute("x_name");
				    string x_value = child.GetAttribute("x");
				    string y_name = child.GetAttribute("y_name");
				    string y_value = child.GetAttribute("y");
				    string z_name = child.GetAttribute("z_name");
				    string z_value = child.GetAttribute("z");
				    info.CreatePanelText(x_name, x_value);
				    info.CreatePanelText(y_name, y_value);
				    info.CreatePanelText(z_name, z_value);
			    }
		    }
		    else if (child.Name.Equals("pulse"))
		    {
			    float p_speed = float.Parse(child.GetAttribute("speed"));
			    float p_scale = float.Parse(child.GetAttribute("scale"));
			    Pulse pul = targetObject.AddComponent<Pulse>();
			    pul.SetPulse(p_scale, p_speed);

			    if (!child.GetAttribute("speed_name").Equals("") || !child.GetAttribute("scale_name").Equals(""))
			    {
				    if (!obj.GetComponent<MouseOver>())
				    {
					    obj.AddComponent<MouseOver>();
				    }

				    if (!obj.GetComponent<InfoData>())
				    {
					    info = obj.AddComponent<InfoData>();
				    }
				    else
				    {
					    info = obj.GetComponent<InfoData>();
				    }

				    string speed_name = child.GetAttribute("speed_name");
				    string speed_value = child.GetAttribute("speed");
				    string scale_name = child.GetAttribute("scale_name");
				    string scale_value = child.GetAttribute("scale");
				    info.CreatePanelText(speed_name, speed_value);
				    info.CreatePanelText(scale_name, scale_value);
			    }
		    }
		    else if (child.Name.Equals("hop"))
		    {
			    float h_speed = float.Parse(child.GetAttribute("speed"));
			    float h_top = float.Parse(child.GetAttribute("top"));
			    string h_axis = child.GetAttribute("axis");
			    Hopping hop = targetObject.AddComponent<Hopping>();
			    hop.SetHopping(h_top, h_speed, h_axis);
			    if (!child.GetAttribute("speed_name").Equals("") || !child.GetAttribute("top_name").Equals(""))
			    {
				    if (!obj.GetComponent<MouseOver>())
				    {
					    obj.AddComponent<MouseOver>();
				    }

				    if (!obj.GetComponent<InfoData>())
				    {
					    info = obj.AddComponent<InfoData>();
				    }
				    else
				    {
					    info = obj.GetComponent<InfoData>();
				    }

				    string speed_name = child.GetAttribute("speed_name");
				    string speed_value = child.GetAttribute("speed");
				    string top_name = child.GetAttribute("top_name");
				    string top_value = child.GetAttribute("top");
				    info.CreatePanelText(speed_name, speed_value);
				    info.CreatePanelText(top_name, top_value);
			    }
		    }
		    else if (child.Name.Equals("localposition"))
		    {
			    DecidePosition dPos;
			    if(!targetObject.GetComponent<DecidePosition>())
			    {
				    dPos = targetObject.AddComponent<DecidePosition>();
			    }
			    else
			    {
				    dPos = targetObject.GetComponent<DecidePosition>();
			    }

			    float l_x = float.Parse(child.GetAttribute("x"));
			    float l_y = float.Parse(child.GetAttribute("y"));
			    float l_z = float.Parse(child.GetAttribute("z"));
			    if (element.Name.Equals("worldposition"))
			    {
				    dPos.PositionPlus(l_x, l_y, l_z);
			    }
			    else
			    {
				    dPos.SetPosition(l_x, l_y, l_z);
			    }

			    //localPosition, worldPositionを持つobjectはflagが立つ これをconnector, grouperで判別し異なる操作を行う
		    }
		    else if (child.Name.Equals("worldposition"))
		    {
			    DecidePosition dPos = targetObject.AddComponent<DecidePosition>();
			    float l_x = float.Parse(child.GetAttribute("x"));
			    float l_y = float.Parse(child.GetAttribute("y")); 
			    float l_z = float.Parse(child.GetAttribute("z"));
			    dPos.SetWorldPosition(l_x, l_y, l_z);
			    
			    if (child.HasChildNodes)
			    {
				    if (child.FirstChild.Name.Equals("localposition"))
				    {
					    CreateOption(child, obj, targetObject);
				    }
			    }
		    }
		    else if (child.Name.Equals("reverse"))
		    {
			    string direction = child.GetAttribute("direction");
			    Reverse rev = targetObject.AddComponent<Reverse>();
			    rev.SetReverse(direction, targetObject);
		    }
		    else if (child.Name.Equals("link"))
		    {
			    if (!child.GetAttribute("destination").Equals("") && !child.GetAttribute("id").Equals(""))
			    {
				    //オブジェクトにリンク先の情報と、クリックの操作をするスクリプトを付与
				    if (!targetObject.GetComponent<MouseClick>())
				    {
					    targetObject.AddComponent<MouseClick>();
				    }

				    string dest = child.GetAttribute("destination");
				    string ident = child.GetAttribute("id");
				    DestinationInfo di;
				    if (!targetObject.GetComponent<DestinationInfo>())
				    {
					    di = targetObject.AddComponent<DestinationInfo>();
					    di.InputDestination(dest, ident);
				    }
				    else
				    {
					    di = targetObject.GetComponent<DestinationInfo>();
					    di.InputDestination(dest, ident);
				    }
				    
				    if (!obj.GetComponent<MouseOver>()) 
				    { 
					    obj.AddComponent<MouseOver>();
				    }
				    
				    if (!obj.GetComponent<InfoData>()) 
				    { 
					    info = obj.AddComponent<InfoData>();
				    }else
				    { 
					    info = obj.GetComponent<InfoData>();
				    }
				    
				    if (dest.Contains(".xml")) 
				    { 
					    dest = dest.Replace(".xml", "");
				    } 
				    info.CreatePanelText("Destination", dest);
				    
			    }
		    }
		    else if (child.Name.Equals("alink"))
		    {
			    if (!child.GetAttribute("destination").Equals(""))
			    {
				    //オブジェクトにリンク先の情報と、クリックの操作をするスクリプトを付与
				    if (!targetObject.GetComponent<MouseClick>())
				    {
					    targetObject.AddComponent<MouseClick>();
				    }

				    string dest = child.GetAttribute("destination");

				    DestinationInfo di;
				    if (!targetObject.GetComponent<MouseClick>())
				    {
					    di = targetObject.AddComponent<DestinationInfo>();
					    di.InputADestination(dest);
				    }
				    else
				    {
					    di = targetObject.GetComponent<DestinationInfo>();
					    di.InputADestination(dest);   
				    }
				    
				    if (!obj.GetComponent<MouseOver>())
				    { 
					    obj.AddComponent<MouseOver>();
				    }

				    if (!obj.GetComponent<InfoData>()) 
				    { 
					    info = obj.AddComponent<InfoData>();
				    }else
				    { 
					    info = obj.GetComponent<InfoData>();
				    }
				    
				    if (dest.Contains(".xml"))
				    {
					    dest = dest.Replace(".xml", "");
				    }
				    
				    info.CreatePanelText("Anchor Destination", dest);
				    
				    
				   
			    }
		    } 
		    targetObject = oldTargetObject;
	    }
	    return obj;
    }

    private static void CreateFilter(XmlElement element, GameObject obj)
    {
	    bool fType = false;
	    foreach (XmlElement child in element)
	    {
		    if (child.Name.Contains("filter"))
		    {
			    if (child.HasAttribute("f_value") && child.HasAttribute("f_target") &&
			        child.HasAttribute("f_pattern"))
			    {
				    Filterable f;
				    if (!obj.GetComponent<Filterable>())
				    {
					    f = obj.AddComponent<Filterable>();
				    }
				    else
				    {
					    f = obj.GetComponent<Filterable>();
				    }
				    obj.tag = "filterable";
				    //ToDo フィルターの属性を一つ以上持つ時 
				    string filterPattern = child.GetAttribute("f_pattern");
				    if (child.HasAttribute("f_type"))
				    {
					    string oFType = child.GetAttribute("f_type");
					    if (oFType.Equals("numeric"))
					    {
						    fType = true;
					    }
					    else if (oFType.Equals("string"))
					    {	
						    fType = false;
					    }
					    else
					    {
						    Debug.LogError("You can't use this filterType.");
					    }
				    }
				    else
				    {
					    //f_typeがない時、f_typeを決める。数値か文字列か
					    fType = Determinetype.TypeIsNumeric(child.GetAttribute("f_value"));
				    }

				    if (fType)
				    {
					    // fAttribute is numeric
					    double fAtt = Double.Parse(child.GetAttribute("f_value"));
					    f.SetValue(fAtt);
					    FilterAttribute fa;
					    fa = new NumericAttribute(child.GetAttribute("f_target"), fAtt, filterPattern);
					    f.SetAttribute(fa);
					    
					    if (SelectDropDown.faSet.Contains(fa))
					    {
						    foreach (var mainFA in SelectDropDown.faSet)
						    {
							    if (mainFA.Equals(fa))
							    {
								    mainFA.CreateValueList(child.GetAttribute("f_value"));
								    mainFA.AddValue(fAtt);
								    break;
							    }
						    }
					    }
					    else
					    {
						    Debug.Log("faSetAdd: " + fa);
						    fa.CreateValueList(child.GetAttribute("f_value"));
						    SelectDropDown.faSet.Add(fa);
					    }
				    }
				    else
				    {
					    //fAttribute is string
					    Debug.Log("???");
					    string fAtt = child.GetAttribute("f_value");
					    f.SetValue(fAtt);
					    FilterAttribute fa;
					    fa = new StringAttribute(child.GetAttribute("f_target"), fAtt, filterPattern);
					    f.SetAttribute(fa);

					    if (SelectDropDown.faSet.Contains(fa))
					    {
						    foreach (var mainFA in SelectDropDown.faSet)
						    {
							    if (mainFA.Equals(fa))
							    {
								    mainFA.CreateValueList(child.GetAttribute("f_value"));
								    mainFA.AddValue(fAtt);
								    break;
							    }
						    }
					    }
					    else
					    {
						    fa.CreateValueList(fAtt);
						    SelectDropDown.faSet.Add(fa);
					    }
				    }
			    }
		    }
	    }
    }

    public static GameObject CreateWrapper ()
	{
		GameObject wrapper = new GameObject ("Wrapper");
		wrapper.transform.position = new Vector3 (0, 0, 0);
		return wrapper;
		//重要
		//子オブジェクトのUI上のPositionは親オブジェクトに対する位置、世界に対する絶対位置ではない！！
		//UI上のScaleは倍率、実際のオブジェクトの大きさではない！！
	}

	public static void ChangeColor (string color, GameObject obj)
	{
		if (System.Text.RegularExpressions.Regex.IsMatch (color, @"(\d+\.?\d*,){3}(\d+\.?\d*)")) {
			char[] delimiterChar = { ',' };
			string[] words = color.Split (delimiterChar);

			float r = float.Parse (words [0]); 
			float g = float.Parse (words [1]); 
			float b = float.Parse (words [2]); 
			float a = float.Parse (words [3]); 
			obj.GetComponent<MeshRenderer> ().material.color = new Color (r, g, b, a);
			//Regex usefull
		} else {
			switch (color) {
			case "red":
				obj.GetComponent<MeshRenderer> ().material.color = Color.red;
				break;
			case "blue":
				obj.GetComponent<MeshRenderer> ().material.color = Color.blue;
				break;
			case "green":
				obj.GetComponent<MeshRenderer> ().material.color = Color.green;
				break;
			case "black":
				obj.GetComponent<MeshRenderer> ().material.color = Color.black;
				break;
			case "clear":
				obj.GetComponent<MeshRenderer> ().material.color = Color.clear;
				break;
			case "cyan":
				obj.GetComponent<MeshRenderer> ().material.color = Color.cyan;
				break;
			case "gray":
				obj.GetComponent<MeshRenderer> ().material.color = Color.gray;
				break;
			case "grey":
				obj.GetComponent<MeshRenderer> ().material.color = Color.grey;
				break;
			case "yellow":
				obj.GetComponent<MeshRenderer> ().material.color = Color.yellow;
				break;
			case "white":
				obj.GetComponent<MeshRenderer> ().material.color = Color.white;
				break;
			case "magenta":
				obj.GetComponent<MeshRenderer> ().material.color = Color.magenta;
				break;
			default:
				obj.GetComponent<MeshRenderer> ().material.color = Color.white;
				break;
			}
		}
	}

	public static GameObject FindInHierarchy(string name, GameObject parent){
		GameObject result = null;

		if (parent.transform.Find(name) == null) {
			foreach (Transform child in parent.transform) {
				result = FindInHierarchy (name, child.gameObject);
				if (result != null) {
					break;
				}
			}
		} else {
			result = parent.transform.Find(name).gameObject;
		}
		return result;
	}

}

