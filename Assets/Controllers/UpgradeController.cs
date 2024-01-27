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
        }
        else
        {
            if (player.playerStats.laughs < upgradeObject.baseCost) return;
            result = new Upgrade(upgradeObject.name, 1, upgradeObject.baseCost, upgradeObject); ;
            player.playerStats.upgrades.Add(result);
        }
        player.playerStats.laughs -= result.currentCost;
        
        result.currentCost += Mathf.RoundToInt(result.currentCost * result.upgradeObject.multiPerLevel);
        player.playerStats.damage.addBaseValue(result.upgradeObject.damage);
        player.playerStats.damagePerSecond.addBaseValue(result.upgradeObject.dps);

        PerkUnlocker.Instance.UnlockPerks(result.upgradeObject.upgradeType);

    }

    private void Start()
    {
        player = Player.Instance;
    }
}
