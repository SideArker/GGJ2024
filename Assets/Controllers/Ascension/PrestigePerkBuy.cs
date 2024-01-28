using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrestigePerkBuy : MonoBehaviour
{
    [SerializeField] PrestigePerkObject prestigePerkObject;
    [SerializeField] PrestigePerkObject unlockCondition;
    private void OnMouseDown()
    {


        Player player = Player.Instance;

        if(unlockCondition == null)
        {
            player.GetComponent<PrestigePerkController>().BuyPerk(prestigePerkObject);
            return;
        } 
        else if(player.playerStats.prestigePerks.Find(x => x.perkObject == unlockCondition) != null)
        {
            player.GetComponent<PrestigePerkController>().BuyPerk(prestigePerkObject);
            return;
        }
        Debug.Log("Perk locked");


    }


    private void Start()
    {
        TooltipTrigger trigger = GetComponent<TooltipTrigger>();
        if (trigger != null)
        {
            trigger.header = prestigePerkObject.perkName;
            trigger.content = prestigePerkObject.perkDescription;
            trigger.special = $"{prestigePerkObject.cost} Heavenly laughs";
        }
    }
}
