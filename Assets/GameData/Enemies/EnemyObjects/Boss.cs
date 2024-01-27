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
            currentHealth -= player.playerStats.damagePerSecond.getModValue();
            yield return new WaitForSeconds(1);
        }

    }

    public void SetStats(float difficulty, int stage)
    {
        currentHealth = bossObject.baseHealth + difficulty * stage * bossObject.difficultyScaling * 1.35f;
        laughAward = bossObject.LaughsDropped + difficulty * stage * bossObject.difficultyScaling * 1.25f;
        baseHealth = currentHealth;
        Debug.Log(currentHealth);
    }


    public void TakeDamage()
    {
        currentHealth -= player.playerStats.damage.getModValue();
        var playerStats = player.playerStats;
        currentHealth -= playerStats.damage.getModValue();
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
            ZoneController.instance.ChangeZone();
            timer.Stop();
            Destroy(gameObject);
        }
        if (!runTick) StartCoroutine(TickDamage());

    }

    void ResetBoss(object source, ElapsedEventArgs e)
    {
        //Debug.Log("Regen boss");
        currentHealth = bossObject.baseHealth;
    }

    void Start()
    {
        player = Player.Instance;

        currentHealth = bossObject.baseHealth;
        laughAward = bossObject.LaughsDropped;

        timer.Elapsed += new ElapsedEventHandler(ResetBoss);
        timer.Interval = bossObject.regenTime * 1000;
        timer.Start();
    }
}
