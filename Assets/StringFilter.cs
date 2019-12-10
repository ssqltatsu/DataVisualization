using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringFilter : Filter
{
    private int type;

    public StringFilter(FilterAttribute fA, object value, int type) : base(fA, value)
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
                result += " equal ";
                break; 
            case 2:
                result += " not equal ";
                break;
            case 3:
                result += " include ";
                break;
            case 4:
                result += " not include ";
                break;
            case 5:
                result += " start with ";
                break;
            case 6:
                result += " end with ";
                break;
        }

        if (GetValue() is string || GetValue() is double)
        {
            result += this.GetValue().ToString();
        } else if (GetValue() is HashSet<string>)
        {
            foreach (string value in (HashSet<string>)GetValue())
            {
                result += value + " ";
            }
        }

        return result;
    }

    protected override bool Blocks(FilterAttribute fA)
    {
        //Equal判定でEqualなら0を返す(アクティブにする)
        string attributeSValue = ((StringAttribute)fA).GetEndValue();

        if (!this.GetProperty().GetPattern().Equals("checkbox"))
        {
            string filterSValue = this.GetValue().ToString();
            switch (this.type)
            {
                case 1:
                    //Equal
                    return !(attributeSValue.Equals(filterSValue));

                case 2:
                    //Not Equal
                    return attributeSValue.Equals(filterSValue);

                case 3:
                    //Include
                    return !(attributeSValue.Contains(filterSValue));

                case 4:
                    //Not Include
                    return attributeSValue.Contains(filterSValue);

                case 5:
                    //Start
                    return !(attributeSValue.StartsWith(filterSValue));

                case 6:
                    //End
                    return !(attributeSValue.EndsWith(filterSValue));
            }

            return false;
        }
        else
        {
            // when checkbox
            bool existFlag = false;
            HashSet<string> stringSet = (HashSet<string>) this.GetValue();
            switch (this.GetFilterType())
            {
                case 1:
                    //Equal
                    foreach (string s in stringSet)
                    {
                        if (attributeSValue.Equals(s))
                        {
                            existFlag = true;
                        }
                    }
                    return !existFlag;

                case 2:
                    //Not Equal
                    foreach (string s in stringSet)
                    {
                        if (attributeSValue.Equals(s))
                        {
                            existFlag = true;
                        }
                    }
                    return existFlag;

                case 3:
                    //Include
                    foreach (string s in stringSet)
                    {
                        if (attributeSValue.Contains(s))
                        {
                            existFlag = true;
                        }
                    }
                    return !existFlag;

                case 4:
                    //Not Include
                    foreach (string s in stringSet)
                    {
                        if (attributeSValue.Contains(s))
                        {
                            existFlag = true;
                        }
                    }
                    return existFlag;

                case 5:
                    //Start
                    foreach (string s in stringSet)
                    {
                        if (attributeSValue.StartsWith(s))
                        {
                            existFlag = true;
                        }
                    }
                    return !existFlag;

                case 6:
                    //End
                    foreach (string s in stringSet)
                    {
                        if (attributeSValue.EndsWith(s))
                        {
                            existFlag = true;
                        }
                    }
                    return !existFlag;
            }
            return false;
        }
    }
}
