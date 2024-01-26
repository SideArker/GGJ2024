using UnityEngine;

[CreateAssetMenu(menuName = "EnemyObjects/Boss")]

public class BossObject : ScriptableObject
{
    [Header("Stats")]
    public float baseHealth;
    public float LaughsDropped;

    [Header("Boss")]
    public float regenTime;

    [Header("Scaling")]
    [Tooltip("Means how hard enemies scale off of current difficulty")]
    public float difficultyScaling;
}
