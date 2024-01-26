using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    public Stat Damage;
    public Stat DamagePerSecond;
    [Header("Currency")]
    public Stat Laughs;

    [Header("Upgrades")]
    public List<Upgrade> Upgrades;

    [Header("Perks")]
    public List<Perk> Perks;
}
