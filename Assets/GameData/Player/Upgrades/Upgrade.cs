using NaughtyAttributes;
using UnityEngine;


public enum UpgradeType
{
    Costume,
    Jokes,
    SoundEffects,
    SlipFall,
    Pranks,
    Tickle,
    Potion,
    BrainChip
}

[System.Serializable]

public class Upgrade
{
    public Upgrade(string Name, int Level, int currentCost, UpgradeObject upgradeObject)
    {
        this.Name= Name;
        this.Level= Level;  
        this.currentCost= currentCost;
        this.upgradeObject= upgradeObject;
    }

    [Header("Debug")]
    [ReadOnly] public float scaledDamage;
    [ReadOnly] public float scaledDPS;

    [Header("Main")]
    public string Name;
    public int Level;
    public float modifier = 1f;

    [Header("Cost")]
    public int currentCost;

    [Header("Object")]
    [Expandable] public UpgradeObject upgradeObject;

}
