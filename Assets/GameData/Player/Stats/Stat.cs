
using NaughtyAttributes;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] float baseValue;
    [ReadOnly] float modValue;
    [Tooltip("multiplier 2x = double the base value")]
    [SerializeField] float modifier = 1f;

    /// <summary>
    /// Adds a value to base value
    /// </summary>
    /// <param name="value">Value to add</param>
    public void addBaseValue(float value)
    {
        value += value;
    }

    /// <summary>
    /// Removes a value from base value
    /// </summary>
    /// <param name="value">Value to remove</param>
    public void remBaseValue(float value) 
    {
        value -= value; 
    }

    /// <summary>
    /// Adds a value to modifier
    /// </summary>
    /// <param name="modifier">the value to add</param>
    public void addModifier (float modifier)
    {
        modifier += modifier;
    }

    /// <summary>
    /// Removes a value from a modifier
    /// </summary>
    /// <param name="modifier">the value to remove</param>
    public void remModifier(float modifier)
    {
        modifier -= modifier;
    }

    /// <summary>
    /// Returns modded value
    /// </summary>
    /// <returns>Base value multiplied by the modifier</returns>
    public float getModValue()
    {
        return baseValue * modifier;
    }

    /// <summary>
    /// Returns base value
    /// </summary>
    /// <returns>Base value</returns>
    public float getBaseValue()
    {
        return baseValue;
    }

    /// <summary>
    /// Resets mods
    /// </summary>
    public void reset()
    {
        modifier = 1f;
    }
}
