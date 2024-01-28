using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    public string header;
    public string content;
    public string special;


    public void OnPointerEnter(PointerEventData eventData)
   {
        TooltipSystem.instance.Show(content, header, special);
   }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.instance.Hide();
    }

    public void OnMouseOver()
    {
        TooltipSystem.instance.Show(content, header, special);
    }

    public void OnMouseExit()
    {
        TooltipSystem.instance.Hide();
    }
}
