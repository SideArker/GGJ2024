using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    public Stat damage;
    public Stat damagePerSecond;
    [Header("Currency")]
    public Stat laughs;

    [Header("Upgrades")]
    public List<Upgrade> upgrades;

    [Header("Perks")]
    public List<Perk> perks;

    [Header("HighScores")]
    public HighScores highScores;

    [Header("Difficulty")]
    public float currentDifficulty = 1f;
    public int prestige = 0;

}
