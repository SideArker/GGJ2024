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
    [Button]
    public void Presige()
    {
        playerStats.damage.reset();
        playerStats.damagePerSecond.reset();
        playerStats.laughs = 0;
        playerStats.upgrades = new List<Upgrade>();
        playerStats.perks = new List<Perk>();
    }

}
