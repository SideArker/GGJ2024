using System.Collections;
using System.Timers;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Player player;

    [Header("Stats")]
    float currentHealth;

    [Header("Other")]
    BossObject bossObject;

    bool runTick = false;


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
            Debug.Log("Boss dead");
            player.playerStats.laughs += bossObject.LaughsDropped;
            ZoneController.instance.ChangeEnemy();
            Destroy(gameObject);
        }
        if (!runTick) StartCoroutine(TickDamage());

    }

    void ResetBoss(object source, ElapsedEventArgs e)
    {
        Debug.Log("Regen boss");
        currentHealth = bossObject.baseHealth;
    }

    void Start()
    {
        player = Player.Instance;

        currentHealth = bossObject.baseHealth;

        Timer timer = new Timer();
        timer.Elapsed += new ElapsedEventHandler(ResetBoss);
        timer.Interval = bossObject.regenTime * 1000;
        timer.Start();
    }
}
