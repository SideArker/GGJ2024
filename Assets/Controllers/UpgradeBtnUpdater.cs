using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeBtnUpdater : MonoBehaviour
{
    [Header("Fields")]
    [SerializeField] GameObject CostText;
    [SerializeField] GameObject UpgradeAmount;
    public UpgradeObject defaultObject;
    public void UpdateData(UpgradeObject upgradeObject)
    {
        Upgrade result = Player.Instance.playerStats.upgrades.Find(x => x.upgradeObject == upgradeObject);
        TooltipTrigger tooltipTrigger = GetComponent<TooltipTrigger>();
        if(result != null)
        {
            CostText.GetComponent<TMP_Text>().text = NumShortener.Shorten(result.currentCost);
            UpgradeAmount.GetComponent<TMP_Text>().text = result.Level.ToString();
            tooltipTrigger.header = result.Name;

            string contentText = "";

            if (defaultObject.damage > 0) contentText += $"Your clicks do <b><color=#00FF00>{defaultObject.damage}</color></b> more fun";
            if (defaultObject.dps > 0)
            {
                if (contentText != "") contentText += "\n";
                contentText += $"Generates <b><color=#00FF00>{defaultObject.dps}</color></b> per second";
            }
            tooltipTrigger.content = contentText;
        }
        else
        {
            CostText.GetComponent<TMP_Text>().text = NumShortener.Shorten(defaultObject.baseCost);
            UpgradeAmount.GetComponent<TMP_Text>().text = "0";

            tooltipTrigger.header = defaultObject.upgradeName;
            string contentText = "";

            if (defaultObject.damage > 0) contentText += $"Your clicks do <color=#00FF00>{defaultObject.damage}</color> more fun";
            if (defaultObject.dps > 0)
            {
                if (contentText != "") contentText += "\n";
                contentText += $"Generates <color=#00FF00>{defaultObject.dps}</color> fun per second"; 
            }
            tooltipTrigger.content = contentText;
        }
    }

    private void Start()
    {
        UpdateData(defaultObject);
    }
}
