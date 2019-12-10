using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SelectDropDown : MonoBehaviour
{
    public static HashSet<FilterAttribute> faSet = new HashSet<FilterAttribute>();
    private Dropdown fDropdown;
    OpenCameraButton ocb;
    private GameObject fObject;
    private NumericText slidNT;

    // Start is called before the first frame update
    void Start()
    {
        GameObject dObject = GameObject.Find("Dropdown");
        ocb = dObject.GetComponent<OpenCameraButton>();
        fObject = dObject.transform.Find("AttributeDropdown").gameObject;
        fDropdown = fObject.GetComponent<Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   public void Select(int value)
   {
       switch (value)
        {
            case 0 : 
                fObject.SetActive(false);
                ocb.OffFilterButton();
                ocb.OffCameraButton();
                break;
            
            case 1 : 
                //Camera
                fObject.SetActive(false);
                ocb.OffFilterButton();
                ocb.OnCameraButton();
                break;
            
            case 2 :
                //Filtering
                ocb.OffCameraButton();
                fDropdown.ClearOptions();
                List<string> sList = new List<string>();
                sList.Add("");
                sList.Add("Show List Of Filter");
                foreach (var attribute in faSet)
                {
                    sList.Add(attribute.GetName());
                }
                
                fDropdown.AddOptions(sList);
                fObject.SetActive(true);
//                ocb.OnFilterButton();
                break;
        }
    }

   public void OnFilterSet(int value)
   {
       if (value > 1)
       {
           HashSet<FilterAttribute>.Enumerator faE = faSet.GetEnumerator();

           for (int i = 1; i < value; i++)
           {
               faE.MoveNext();
           }
           
           if (faE.Current.GetPattern().Equals("slider"))
           {
               faE.Current.ShowSFilter();
           }
           else if (faE.Current.GetPattern().Equals("checkbox"))
           {
               faE.Current.ShowCBFilter();
           }
           else if (faE.Current.GetPattern().Equals("inputfield"))
           {
               faE.Current.ShowIFFilter();
           }
               
           faE.Dispose();
       }  else if (value == 1)
       {
           CreateCheckBoxList.CreateFilterList(Filter.filters);
           CreateCheckBoxList.OnFilterList();
       }
   }
}
