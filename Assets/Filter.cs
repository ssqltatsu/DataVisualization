using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;

public abstract class Filter
{
   [SerializeField] private FilterAttribute property;
   [SerializeField] private object value;
   public static List<Filter> filters = new List<Filter>();
   public static List<Filter> filtersToRemove = new List<Filter>();
   public static List<GameObject> nonActiveObject = new List<GameObject>();
   public static List<GameObject> activeFromNonActiveObject = new List<GameObject>();
   

   public Filter(FilterAttribute property, object value)
    {
        this.property = property;
        this.value = value;
    }

    public FilterAttribute GetProperty()
    {
        return this.property;
    }

    public object GetValue()
    {
        return this.value;
    }
    
    public static void ApplyFilter(GameObject obj)
    {//For activeObject
//        filters.ForEach(Debug.Log);
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("filterable"))
        {
            //フィルターの数ではなく、オブジェクトの個数回しかみない・・・
            Filterable f = g.GetComponent<Filterable>();
            if (filters?.Count > 0)
            {
                foreach (Filter fil in Filter.filters)
                {
                    foreach (FilterAttribute fA in f.fAList)
                    {
                        if (f != null && fA.Equals(fil.GetProperty()))
                        {
                            if (fil.Blocks(fA))
                            {
                                nonActiveObject.Add(g);
                                g.SetActive(false);
                                break;
                            }
                            else
                            {
                                g.SetActive(true);
                            }
                        }
                    }
                }
            }
            else
            {
                g.SetActive(true);
            }
        }
    }

    public static void ApplyFilterForNonActive(GameObject obj)
    {
        //For nonActiveObject
        if (nonActiveObject?.Count > 0)
        {
            //nonActiveObjectは他のフィルターのnonActiveObjectも含んでいる
            foreach (GameObject g in nonActiveObject)
            {
                if (filtersToRemove?.Count > 0)
                {
                    Filterable f = g.GetComponent<Filterable>();
                    foreach (Filter fil in Filter.filtersToRemove)
                    {
                        foreach (FilterAttribute fA in f.fAList)
                        {
                            if (f != null && fA.Equals(fil.GetProperty()))
                            {
                                //filtersToRemoveのフィルターをもつオブジェクトは全てアクティブに
                                g.SetActive(true);
                                activeFromNonActiveObject.Add(g);
                            }
                        }
                    }
                }
                else
                {
                    g.SetActive(true);
                }
            }
            foreach (GameObject activeObject in activeFromNonActiveObject)
            {
                nonActiveObject.Remove(activeObject);
            }
            activeFromNonActiveObject.Clear();
        }
    }

    protected abstract bool Blocks(FilterAttribute f);
} 
