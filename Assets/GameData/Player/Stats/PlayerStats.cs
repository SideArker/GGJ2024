using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    public Stat damage;
    public Stat damagePerSecond;

    [Header("Currency")]
    public float laughs;
    public float prestigePoints;
    public float prestigePointMultiplier;

    [Header("Zone")]
    public int currentStage = 1;
    public int highestStage = 1;
    public ZoneObject currentZone;

    [Header("Upgrades")]
    public List<Upgrade> upgrades;

    [Header("Perks")]
    public List<Perk> perks;

    [Header("PrestigePerks")]
    public List<PrestigePerk> prestigePerks;

    [Header("HighScores")]
    public HighScores highScores;

    [Header("Difficulty")]
    public float currentDifficulty = 1f;

}
