using UnityEngine;


[CreateAssetMenu(menuName = "PlayerObjects/Upgrade")]
public class UpgradeObject : ScriptableObject
{
    [Header("Main")]
    public string perkName;

    [Header("Stats")]
    public float damage;
    public float dps;

    [Header("Cost")]
    public float baseCost;
    [Tooltip("Increase per level ex: 0.5 will be a 50% increase per level")]
    public float multiPerLevel;

    [Header("Other")]
    public Sprite icon;
}
