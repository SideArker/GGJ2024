using UnityEngine;

[CreateAssetMenu(menuName = "PlayerObjects/PrestigePerk")]
public class PrestigePerkObject : ScriptableObject
{
    [Header("Main")]
    public string perkName;
    public string perkDescription;

    [Header("Stats")]
    float overallMultiplier;
    float clickPowerMultiplier;
    float ppGainMultiplier;

    [Header("Cost")]
    public float cost;

    [Header("Other")]
    public Sprite sprite;
}
