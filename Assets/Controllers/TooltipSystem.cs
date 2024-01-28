using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem instance;
    
    public Tooltip tooltip;

    public void Awake()
    {
        instance = this;
    }

    public static void Show(string content, string header = "", string special = "")
    {
        instance.tooltip.SetText(content, header, special);
        instance.tooltip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        instance.tooltip.gameObject.SetActive(false);
    }

    
}
