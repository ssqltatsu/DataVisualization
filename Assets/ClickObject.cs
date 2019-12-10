using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Linq;
using IBM.Watson.DeveloperCloud.Logging;


public class ClickObject
    {
        public void ReloadSceneOnClick(GameObject obj)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                //sceneとanchorscene両方を持つ時、LeftShiftを押しながらクリックすると、anchorsceneの方へ, ただのクリックはsceneの方へ遷移
                //片方のみを持つ時はどちらであってもクリックで遷移
                if (!obj.GetComponent<DestinationInfo>().GetIdentification().Equals(""))
                {
                    //scene foreach
                    Challenge.aFlag.Push(Challenge.aF);
                    Challenge.idInfo.Push(Challenge.id);
                    Challenge.destInfo.Push(Challenge.xml_name);
                    Challenge.aF = false;
                    Challenge.xml_name = obj.GetComponent<DestinationInfo>().GetDestination();
                    Challenge.id = obj.GetComponent<DestinationInfo>().GetIdentification();
                    SceneManager.LoadScene("Challenge");
                }
                else
                {
                    //anchor scene
                    Challenge.aFlag.Push(Challenge.aF);
                    Challenge.aDestInfo.Push(Challenge.xml_name);
                    Challenge.aF = true;
                    Challenge.xml_name = obj.GetComponent<DestinationInfo>().GetADestination();
                    SceneManager.LoadScene("Challenge");
                }
            }
            else
            {
                //anchor scene
                if (obj.GetComponent<DestinationInfo>())
                {
                    if (obj.GetComponent<DestinationInfo>().GetADestination() != null)
                    {
                        if (!obj.GetComponent<DestinationInfo>().GetADestination().Equals(""))
                        {
                            Challenge.aFlag.Push(Challenge.aF);
                            Challenge.aDestInfo.Push(Challenge.xml_name);
                            Challenge.aF = true;
                            Challenge.xml_name = obj.GetComponent<DestinationInfo>().GetADestination();
                            SceneManager.LoadScene("Challenge");
                        }
                    }
                }
            }
        }
        
        public static void BackSceneOnClick()
        {
            Challenge.xml_name = Challenge.destInfo.Pop();
            Challenge.id = Challenge.idInfo.Pop();
            Challenge.aF = Challenge.aFlag.Pop();
            SceneManager.LoadScene("Challenge");
        }

        public static void BackASceneOnClick()
        {
            Challenge.xml_name = Challenge.aDestInfo.Pop();
            Challenge.aF = Challenge.aFlag.Pop();
            SceneManager.LoadScene("Challenge");
        }
    }
    