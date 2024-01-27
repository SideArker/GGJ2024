using System.Collections;
using UnityEngine;

[System.Serializable]
public class Enemy : MonoBehaviour
{
    Player player;

    [Header("Stats")]
    float currentHealth;
    float laughAward;

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
            Debug.Log("Damage dealt: " + player.playerStats.damagePerSecond.getModValue());
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
            player.playerStats.laughs += laughAward;
            ZoneController.instance.AutoNextStage();
            Destroy(gameObject);
        }
        if(!runTick) StartCoroutine(TickDamage());
        
    }

    public void SetStats(float difficulty, int stage)
    {
        currentHealth = enemyObject.baseHealth + difficulty * stage * enemyObject.difficultyScaling * 1.75f;
        laughAward = enemyObject.LaughsDropped + difficulty * stage * enemyObject.difficultyScaling * 1.5f;
    }

    void Start()
    {
        player = Player.Instance;

        currentHealth = enemyObject.baseHealth;
        laughAward = enemyObject.LaughsDropped;
    }
}
