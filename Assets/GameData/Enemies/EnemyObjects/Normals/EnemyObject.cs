using UnityEngine;

[CreateAssetMenu(menuName = "EnemyObjects/Enemy")]

public class EnemyObject : ScriptableObject
{
    [Header("Stats")]
    public float baseHealth;
    public float LaughsDropped;

    [Header("Scaling")]
    [Tooltip("Means how hard enemies scale off of current difficulty")]
    public float difficultyScaling;

}
