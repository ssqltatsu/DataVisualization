using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGrouper : MonoBehaviour
{
    private List<GameObject> changingObjectList = new List<GameObject>();
    private float timing;
    private float interval = 0f;
    private int objectNumber = 1;

    private int lastObjectNumber = 1;
    //interactiveな操作でobjectが変化する状態を止められるようにする次のオブジェクトや前のオブジェクトに変更もできるとよい
    public static bool changeObjectFlag = true;
    private bool changeRoopFlag = false;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < changingObjectList.Count; i++)
        {
            changingObjectList[i].SetActive(false);
            
            if (i == 0)
            {
                changingObjectList[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        interval += Time.deltaTime;
        if (changeObjectFlag)
        {
            if (interval >= timing)
            {
                if (!changeRoopFlag)
                {
                    changingObjectList[objectNumber - 1].SetActive(false);
                    objectNumber++;
                    changingObjectList[objectNumber - 1].SetActive(true);
                }else
                {
                    changingObjectList[lastObjectNumber - 1].SetActive(false);
                    changingObjectList[objectNumber - 1].SetActive(true);
                    changeRoopFlag = false;
                }

                if (objectNumber >= changingObjectList.Count)
                    {
                        lastObjectNumber = objectNumber;
                        objectNumber = 1;
                        changeRoopFlag = true;
                    }

                    interval = 0f;
            }
        }
    }

    public void AddChangeObject(GameObject obj)
    {
        changingObjectList.Add(obj);
    }

    public void SetTiming(float timing)
    {
        this.timing = timing;
    }
    
}
