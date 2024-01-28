using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumShortener : MonoBehaviour
{
    static Dictionary<decimal, string> shortenNums = new Dictionary<decimal, string>()
    {
        {1000000000000000, "Qd" },
        {1000000000000, "T" },
        {1000000000, "B" },
        {1000000, "M" },
        {1000, "K"}
    };


    public static string Shorten(decimal num)
    {
        string output = "";

        foreach(KeyValuePair<decimal, string> item in shortenNums)
        {
            if(num >= item.Key && output == "")
            {
                output = (num / item.Key).ToString().Replace(',', '.');
                int index = output.IndexOf('.');
                if(index > 0)
                {
                    if (index + 3 > output.Length - 1) index--;
                    output = output.Substring(0, index + 3);
                }
                output += $"{item.Value}+";
            }
        }

        if(output == "") output = num.ToString();

        return output;
    }
}
