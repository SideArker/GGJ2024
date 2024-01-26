using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    Player player;

    [Header("Stats")]
    float currentHealth;

    [Header("Other")]
    EnemyObject enemyObject;
    ZoneObject currentZone;


    IEnumerator TickDamage()
    {
        while(currentHealth > 0)
        {
            yield return new WaitForSeconds(1);
            currentHealth -= player.playerStats.damagePerSecond.getModValue();
        }

    }
    
    void changeEnemy()
    {
        player.playerStats.laughs += enemyObject.LaughsDropped;


    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Debug.Log("Enemy dead");

        }
    }

    void Start()
    {
        player = Player.Instance;
        currentZone = player.playerStats.currentZone;
    }
}
