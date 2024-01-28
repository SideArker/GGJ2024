using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PrestigePerk
{
    public PrestigePerk(string perkName, string perkDescription, PrestigePerkObject perkObject, float level)
    {
        this.perkName = perkName;
        this.perkDescription = perkDescription;
        this.perkObject = perkObject;
        Level = level;
    }

    [Header("Main")]
    public string perkName;
    public string perkDescription;

    [Header("Level")]
    public float Level;

    [Header("Object")]
    [Expandable] public PrestigePerkObject perkObject;
}
