using UnityEngine;


[CreateAssetMenu(menuName = "PlayerObjects/Perk")]
public class PerkObject : ScriptableObject
{
    [Header("Main")]
    public string perkName;
    public string perkDescription;

    [Header("Unlock")]
    public UpgradeType upgradeType;
    public UpgradeObject upgradeNeeded;
    public int amountNeeded;

    [Header("Stats")]
    public float damageMultiplier;
    public float dpsMultiplier;

    [Header("Cost")]
    public float Cost;

    [Header("Other")]
    public Sprite icon;
}
