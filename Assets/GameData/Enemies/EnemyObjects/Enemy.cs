using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;

[System.Serializable]
public class Enemy : MonoBehaviour
{
    Player player;

    [Header("Stats")]
    public float currentHealth = 10;
    public float baseHealth = 10;
    public float laughAward = 10;

    [Header("Other")]
    [HideInInspector] public EnemyObject enemyObject;

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
            //Debug.Log("Damage dealt: " + player.playerStats.damagePerSecond.getModValue());
        }

    }

    public void TakeDamage()
    {
        bool isCrit = Random.Range(0,100) <= Player.Instance.playerStats.critChance.getModValue();
        print(isCrit);
        var playerStats = player.playerStats;
        currentHealth -= playerStats.damage.getModValue() * (isCrit ? playerStats.critMultilier.getModValue() : 1);
        Player.Instance.SetFunmeter(1 - (currentHealth / baseHealth));
        //print($"currH: {currentHealth}, baseH: {enemyObject.baseHealth}");
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            //Debug.Log("Enemy dead");
            ZoneController.instance.isEnemyAlive = false;
            player.playerStats.laughs += laughAward;
            ZoneController.instance.AutoNextStage();
            Destroy(gameObject);
        }
        if(!runTick) StartCoroutine(TickDamage());
        
    }

    public void SetStats(float difficulty, int stage)
    {
        currentHealth = enemyObject.baseHealth + difficulty * stage * enemyObject.difficultyScaling * 1.75f;
        baseHealth = currentHealth;
        laughAward = enemyObject.LaughsDropped + difficulty * stage * enemyObject.difficultyScaling * 1.5f;
    }

    void Start()
    {
        player = Player.Instance;

        //currentHealth = enemyObject.baseHealth;
        //laughAward = enemyObject.LaughsDropped;
    }
}
