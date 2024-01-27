using System.Collections;
using UnityEngine;

[System.Serializable]
public class Enemy : MonoBehaviour
{
    Player player;

    [Header("Stats")]
    float currentHealth;

    [Header("Other")]
    EnemyObject enemyObject;

    bool runTick = false;


    public void SetEnemyObject(EnemyObject enemyObject)
    {
        this.enemyObject = enemyObject;
    }

    IEnumerator TickDamage()
    {
        runTick = true;
        while (currentHealth > 0)
        {
            yield return new WaitForSeconds(1);
            currentHealth -= player.playerStats.damagePerSecond.getModValue();
        }

    }

    public void TakeDamage()
    {
        currentHealth -= player.playerStats.damage.getModValue();
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Enemy dead");
            player.playerStats.laughs += enemyObject.LaughsDropped;
            ZoneController.instance.ChangeEnemy();
            Destroy(gameObject);
        }
        if(!runTick) StartCoroutine(TickDamage());
        
    }

    void Start()
    {
        player = Player.Instance;

        currentHealth = enemyObject.baseHealth;
    }
}
