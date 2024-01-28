using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem instance;

    public Canvas canvasMain;
    public Canvas canvasPrestige;
    public Tooltip tooltip;

    public void Awake()
    {
        instance = this;
    }

    public void Show(string content, string header = "", string special = "")
    {
        if (UIController.Instance.currentCam == Camera.main) instance.tooltip.transform.SetParent(canvasMain.transform);
        else instance.tooltip.transform.SetParent(canvasPrestige.transform);
        instance.tooltip.SetText(content, header, special);
        instance.tooltip.gameObject.SetActive(true);
    }

    public void Hide()
    {
        instance.tooltip.gameObject.SetActive(false);
    }

    
}
