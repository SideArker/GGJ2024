using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PlayerObjects/Perk")]
public class PerkObject : ScriptableObject
{
    [Header("Main")]
    public string perkName;

    [Header("Stats")]
    public float damageMultiplier;
    public float dpsMultiplier;

    [Header("Cost")]
    public float Cost;

    [Header("Other")]
    public Sprite icon;
}
