using NaughtyAttributes;
using UnityEngine;

[System.Serializable]
public class Upgrade
{
    [Header("Main")]
    public string Name;
    public int Level;

    [Header("Cost")]
    public float currentCost;

    [Header("Object")]
    [Expandable]  public UpgradeObject UpgradeObject;
}
