using System.Linq;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{

    Player player;
    public void BuyUpgrade(UpgradeObject upgradeObject)
    {
        Upgrade result = player.playerStats.upgrades.Find(x => x.upgradeObject == upgradeObject);
        if (result != null)
        {
            if (player.playerStats.laughs < result.currentCost) return;
            result.Level++;
            player.playerStats.laughs -= result.currentCost;
            result.currentCost += Mathf.RoundToInt(result.currentCost * result.upgradeObject.multiPerLevel);
        }
        else
        {
            if (player.playerStats.laughs < upgradeObject.baseCost) return;
            Upgrade upgrade = new Upgrade(upgradeObject.name, 1, upgradeObject.baseCost, upgradeObject); ;
            player.playerStats.upgrades.Add(upgrade);
            player.playerStats.laughs -= upgrade.currentCost;
            upgrade.currentCost += Mathf.RoundToInt(upgrade.currentCost * upgrade.upgradeObject.multiPerLevel);
        }
    }

    private void Start()
    {
        player = Player.Instance;
    }
}
