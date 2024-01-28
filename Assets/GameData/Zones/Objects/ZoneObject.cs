
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Zone/ZoneObject")]
public class ZoneObject : ScriptableObject
{
    [Header("Main")]
    public string zoneName;

    [Header("Enemies")]
    public List<EnemyObject> enemies;
    public List<BossObject> bosses;

    [Header("Other")]
    public Sprite zoneSprite;
}
