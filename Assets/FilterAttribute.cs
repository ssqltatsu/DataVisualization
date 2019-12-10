using UnityEngine;

public abstract class FilterAttribute
{
    private readonly string attName;

    private readonly string filterPattern;
    
    public abstract void ShowSFilter();
    public abstract void ShowIFFilter();
    public abstract void ShowCBFilter();

    public abstract void CreateValueList(string value);
    
    public abstract void AddValue(object newValue);
    public abstract void SetFirstValue(object fValue);
    
    public virtual double GetMinValue()
    {
        return 0;
    }

    public virtual double GetMaxValue()
    {
        return 0;
    }

    public virtual string GetStartValue()
    {
        return "";
    }
    
    public virtual string GetEndValue()
    {
        return "";
    }
    
    public FilterAttribute(string faName, string pattern)
    {
        this.attName = faName;
        this.filterPattern = pattern;
    }
    
    public override bool Equals(object other)
    {
        if (other == null)
        {
            return false;
        }
        else if (!(other is FilterAttribute))
        {
            return false;
        }
        else
        {
            FilterAttribute otherFilter = other as FilterAttribute;
            return this.attName.Equals(otherFilter.GetName());
        }
    }

    public override int GetHashCode()
    {
        return this.attName.GetHashCode();
    }

    public string GetName()
    {
        return attName;
    }

    public string GetPattern()
    {
        return filterPattern;
    }

    public void ResetGUI()
    {
        StringAttribute.cBFilterGUI.SetActive(false);
        StringAttribute.iFFilterGUI.SetActive(false);
        NumericAttribute.cBFilterGUI.SetActive(false);
        NumericAttribute.sFilterGUI.SetActive(false);
        NumericAttribute.iFFilterGUI.SetActive(false);
        CreateCheckBoxList.filterList.SetActive(false);
        foreach (Transform child in NumericAttribute.cBFilterGUI.transform.Find("Scroll View").Find("Viewport")
            .Find("NContent").transform)
        {
            GameObject.Destroy(child.gameObject);
        } 
        
        foreach (Transform child in StringAttribute.cBFilterGUI.transform.Find("Scroll View").Find("Viewport")
            .Find("SContent").transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
