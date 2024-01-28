using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeBtnUpdater : MonoBehaviour
{
    [Header("Fields")]
    [SerializeField] GameObject CostText;
    [SerializeField] GameObject UpgradeAmount;
    [SerializeField] UpgradeObject defaultObject;
    public void UpdateData(UpgradeObject upgradeObject)
    {
        Upgrade result = Player.Instance.playerStats.upgrades.Find(x => x.upgradeObject == upgradeObject);
        TooltipTrigger tooltipTrigger = GetComponent<TooltipTrigger>();
        if(result != null)
        {
            CostText.GetComponent<TMP_Text>().text = result.currentCost.ToString();
            UpgradeAmount.GetComponent<TMP_Text>().text = result.Level.ToString();
            tooltipTrigger.header = result.Name;
            tooltipTrigger.content = result.upgradeObject.description;
        }
        else
        {
            CostText.GetComponent<TMP_Text>().text = defaultObject.baseCost.ToString();
            UpgradeAmount.GetComponent<TMP_Text>().text = "0";

            tooltipTrigger.header = defaultObject.upgradeName;
            tooltipTrigger.content = defaultObject.description;
        }
    }

    private void Start()
    {
        UpdateData(defaultObject);
    }
}
