using UnityEngine;


[CreateAssetMenu(menuName = "PlayerObjects/Perk")]
public class PerkObject : ScriptableObject
{
    [Header("Main")]
    public string perkName;
    [TextArea(5, 10)]
    public string perkDescription;

    [Header("Unlock")]
    public UpgradeType upgradeType;
    public UpgradeObject upgradeNeeded;
    public int amountNeeded;

    [Header("Stats")]
    public float upgradeGainMultiplier;
    public float damageMultiplier;
    public float dpsMultiplier;

    [Header("Crit")]
    public float critChance;
    public float critDamageMultiplier;

    [Header("Cost")]
    public float Cost;

    [Header("Other")]
    public Sprite icon;
}
