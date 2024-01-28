using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class Prestige : MonoBehaviour
{
    PlayerStats playerStats;
    private void Start()
    {
        playerStats = Player.Instance.playerStats;
    }
    public void OnPrestige(float prestigePoints)
    {
        playerStats.damage.reset();
        playerStats.damagePerSecond.reset();
        playerStats.critChance.reset();
        playerStats.critChance.setBaseValue(0);
        playerStats.critMultiplier.reset();
        playerStats.laughs = 0;
        Player.Instance.SetLaughs();
        playerStats.upgrades.Clear();
        playerStats.perks.Clear();

        playerStats.prestigePoints += prestigePoints;
        UIController.Instance.UpdateEntries();

        Player.Instance.GetComponent<PerkUnlocker>().unlockedPerks.Clear();
    }

}
