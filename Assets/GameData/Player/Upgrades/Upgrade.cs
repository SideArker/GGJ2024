using NaughtyAttributes;
using UnityEngine;

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


    [Header("Main")]
    public string Name;
    public int Level;

    [Header("Cost")]
    public int currentCost;

    [Header("Object")]
    [Expandable] public UpgradeObject upgradeObject;
}
