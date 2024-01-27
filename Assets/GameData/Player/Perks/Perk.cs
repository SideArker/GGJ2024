using NaughtyAttributes;
using UnityEngine;

[System.Serializable]
public class Perk
{
    [Header("Main")]
    public string perkName;
    public string perkDescription;

    [Header("Object")]
    [Expandable] public PerkObject PerkObject;
}
