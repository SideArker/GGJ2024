using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkController : MonoBehaviour
{

    Player player;
    public void BuyPerk(PerkObject perkObject)
    {
        Perk result = player.playerStats.perks.Find(x => x.perkObject == perkObject);
        if (result != null) return;

            if (player.playerStats.laughs < perkObject.Cost) return;
            result = new Perk(perkObject.name, perkObject.perkDescription, perkObject);

            player.playerStats.perks.Add(result);

        player.playerStats.laughs -= result.perkObject.Cost;

        Upgrade upg = player.playerStats.upgrades.Find(x => x.upgradeObject == perkObject.upgradeNeeded);
        upg.modifier += perkObject.upgradeGainMultiplier;

        player.playerStats.damage.remBaseValue(upg.scaledDamage);
        player.playerStats.damagePerSecond.remBaseValue(upg.scaledDPS);

        upg.scaledDamage = upg.Level * upg.upgradeObject.damage * upg.modifier;
        upg.scaledDPS = upg.Level * upg.upgradeObject.dps * upg.modifier;

        player.playerStats.damage.addBaseValue(upg.scaledDamage);
        player.playerStats.damagePerSecond.addBaseValue(upg. scaledDPS);

        player.playerStats.damage.addModifier(result.perkObject.damageMultiplier);
        player.playerStats.damagePerSecond.addModifier(result.perkObject.dpsMultiplier);
    }

    private void Start()
    {
        player = Player.Instance;
    }
}
