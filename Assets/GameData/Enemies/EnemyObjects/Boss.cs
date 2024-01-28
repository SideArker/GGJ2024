using System.Collections;
using System.Timers;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Player player;

    [Header("Stats")]
    public float currentHealth = 10;
    public float baseHealth = 10;
    float laughAward;

    [Header("Other")]
    public BossObject bossObject;

    bool runTick = false;
    Timer timer = new Timer();

    public void SetBossObject(BossObject bossObject)
    {
        this.bossObject = bossObject;
    }

    IEnumerator TickDamage()
    {
        runTick = true;
        while (currentHealth > 0)
        {
            yield return new WaitForSeconds(1);
            currentHealth -= player.playerStats.damagePerSecond.getModValue();
            Player.Instance.SetFunmeter(1 - (currentHealth / baseHealth));
            Debug.Log("a");
        }

    }

    IEnumerator BossRegen()
    {
        while(currentHealth > 0)
        {
            yield return new WaitForSeconds(bossObject.regenTime);
            currentHealth = baseHealth;
            Debug.Log(baseHealth);
        }
    }

    public void SetStats(float difficulty, int stage)
    {
        currentHealth = bossObject.baseHealth + difficulty * stage * bossObject.difficultyScaling * ((stage + 20) / 10);
        laughAward = bossObject.LaughsDropped + difficulty * stage * bossObject.difficultyScaling * 2f;
        baseHealth = currentHealth;
        Debug.Log(currentHealth);
    }


    public void TakeDamage()
    {
        bool isCrit = Random.Range(0, 100) <= Player.Instance.playerStats.critChance.getModValue();
        var playerStats = player.playerStats;
        currentHealth -= playerStats.damage.getModValue() * (isCrit ? playerStats.critMultiplier.getModValue() : 1);
        Player.Instance.SetFunmeter(1 - (currentHealth / baseHealth));
        //print($"currH: {currentHealth}, baseH: {enemyObject.baseHealth}");

    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Boss dead");
            ZoneController.instance.isEnemyAlive = false;
            player.playerStats.laughs += laughAward;
            Player.Instance.SetLaughs();
            timer.Stop();
            ZoneController.instance.ChangeEnemy();
            Destroy(gameObject);
        }
        if (!runTick)
        {
            StartCoroutine(TickDamage());
            StartCoroutine(BossRegen());
        }


    }

    void Start()
    {
        player = Player.Instance;

        if(currentHealth == 0)
        {
            currentHealth = bossObject.baseHealth;
            laughAward = bossObject.LaughsDropped;
        }
    }
}
