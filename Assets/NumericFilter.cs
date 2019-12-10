using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NumericFilter : Filter
{
    private int type;
    public NumericFilter(FilterAttribute property, object value, int type) : base(property, value)
    {
        this.type = type;
    }

    public int GetFilterType()
    {
        return this.type;
    }
    
    public override string ToString()
    {
        string result = this.GetProperty().GetName();
        switch (this.type)
        {
            case 1:
                result += " = ";
                break; 
            case 2:
                result += " ≠ ";
                break;
            case 3:
                result += " > ";
                break;
            case 4:
                result += " >= ";
                break;
            case 5:
                result += " < ";
                break;
            case 6:
                result += " <= ";
                break;
        }
        
        if (GetValue() is string || GetValue() is double)
        {
            result += this.GetValue().ToString();
        } else if (GetValue() is HashSet<string>)
        {
            foreach (string value in (HashSet<string>) GetValue())
            {
                result += value + " ";
            }
        } else if (GetValue() is HashSet<double>)
        {
            foreach (double value in (HashSet<double>) GetValue())
            {
                result += value + " ";
            }
        }

        return result;
    }

    protected override bool Blocks(FilterAttribute fA)
    {
        //filterableは複数のfilterAttributeを持つ.
        double attributeValue;
        attributeValue = ((NumericAttribute) fA).GetValue();

        if (!this.GetProperty().GetPattern().Equals("checkbox"))
        {
            double filterValue;
            double.TryParse(this.GetValue().ToString(), out filterValue);
            switch (this.type)
            {
                case 1:
                    //Equal
                    return !(attributeValue.Equals(filterValue));

                case 2:
                    //Not Equal
                    return attributeValue.Equals(filterValue);

                case 3:
                    //Above
                    return attributeValue <= filterValue;

                case 4:
                    //More than
                    return attributeValue < filterValue;

                case 5:
                    //Below
                    return attributeValue >= filterValue;

                case 6:
                    //Less than
                    return attributeValue > filterValue;
            }
            return false;
        }
        else
        {
            //filterがselectの時でも保存してしまう。 checkboxのtextをapplyした後にクリック前に戻す
            //when checkbox
            //fil.GetValue()はHashSet<numeric>
            bool existFlag = false;
            HashSet<double> doubleSet = (HashSet<double>)this.GetValue();
            
            double max = 0;
            double min = 0;

            if (doubleSet.Count > 0)
            {
                max = doubleSet.Max();
                min = doubleSet.Min();
            }

            switch (this.GetFilterType())
            {
                case 1:
                    //Equal
                    foreach (double d in doubleSet)
                    {
                        if (attributeValue.Equals(d))
                        {
                            //一つでも当てはまればOK
                            existFlag = true;
                        }
                    }
                    return !existFlag;

                case 2:
                    //Not Equal
                    foreach (double d in doubleSet)
                    {
                        Debug.Log("filtervalue "+ d);
                        if (attributeValue.Equals(d))
                        {
                            existFlag = true;
                        }
                    }
                    return existFlag;

                case 3:
                    //Above
                    return attributeValue <= max;

                case 4:
                    //More than
                    return attributeValue < max;

                case 5:
                    //Below
                    return attributeValue >= min;

                case 6:
                    //Less than
                    return attributeValue > min;
            }
            return false;
        }
    }
    
}
