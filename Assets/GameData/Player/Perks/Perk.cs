using NaughtyAttributes;
using UnityEngine;

[System.Serializable]
public class Perk
{

    public Perk(string perkName, string perkDescription, PerkObject perkObject)
    {
        this.perkName = perkName;
        this.perkDescription = perkDescription;
        this.perkObject = perkObject; 
    }

    [Header("Main")]
    public string perkName;
    public string perkDescription;

    [Header("Object")]
    [Expandable] public PerkObject perkObject;
}
