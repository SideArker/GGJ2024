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
            result = new Upgrade(upgradeObject.name, 1, upgradeObject.baseCost, upgradeObject);
            player.playerStats.upgrades.Add(result);
        }
        player.playerStats.laughs -= result.currentCost;
        
        result.currentCost += Mathf.RoundToInt(result.currentCost * result.upgradeObject.multiPerLevel);

        player.playerStats.damage.remBaseValue(result.scaledDamage);
        player.playerStats.damagePerSecond.remBaseValue(result.scaledDPS);

        result.scaledDamage = result.Level * result.upgradeObject.damage * result.modifier;
        result.scaledDPS = result.Level * result.upgradeObject.dps * result.modifier;

        player.playerStats.damage.addBaseValue(result.scaledDamage);
        player.playerStats.damagePerSecond.addBaseValue(result.scaledDPS);

        PerkUnlocker.Instance.UnlockPerks(result.upgradeObject.upgradeType);

    }

    private void Start()
    {
        player = Player.Instance;
    }
}
