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
            ZoneController.instance.ChangeZone();
            timer.Stop();
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

        timer.Elapsed += new ElapsedEventHandler(ResetBoss);
        timer.Interval = bossObject.regenTime * 1000;
        timer.Start();
    }
}
