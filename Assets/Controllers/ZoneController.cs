using NaughtyAttributes;
using System;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    public static ZoneController instance;
    public bool autoNextStage = true;

    [Header("Hierarchy")]
    [SerializeField] ZoneHierarchy zoneHierarchy;

    [Header("Prefabs")]
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] Boss bossPrefab;

    Player player;

    Enemy currentEnemy;
    Boss currentBoss;

    bool clickCooldown = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player = Player.Instance;
        ZoneObject currentZone = player.playerStats.currentZone;

        // On zone start
        Enemy enemy = Instantiate(enemyPrefab);
        int randomEnemy = UnityEngine.Random.Range(0, currentZone.enemies.Count - 1);
        enemy.SetEnemyObject(currentZone.enemies[randomEnemy]);
        currentEnemy = enemy;
    }

    public void ChangeZone()
    {
        int zoneIndex = Array.IndexOf(zoneHierarchy.Zones, player.playerStats.currentZone) + 1;
        if (zoneIndex > zoneHierarchy.Zones.Length - 1)
        {
            zoneIndex = 0;
        }

        player.playerStats.currentZone = zoneHierarchy.Zones[zoneIndex];
        ChangeEnemy();
    }

    void ClickCooldown()
    {
        clickCooldown = false;
    }


    public void DamageEnemy()
    {
        if (clickCooldown) return;
        clickCooldown = true;
        if (currentBoss) currentBoss.TakeDamage();
        else currentBoss = null;
        if (currentEnemy) currentEnemy.TakeDamage();
        else currentEnemy = null;
        Invoke(nameof(ClickCooldown), 0.05f);
    }

    public void ChangeEnemy()
    {
        if (autoNextStage) player.playerStats.currentStage++;
        player.playerStats.currentDifficulty += .2f;

        if (player.playerStats.highestStage < player.playerStats.currentStage)
        {
            player.playerStats.highestStage = player.playerStats.currentStage;
        }

        ZoneObject currentZone = player.playerStats.currentZone;
        if (player.playerStats.currentStage % 10 == 0)
        {
            Debug.Log("Spawn boss");
            Boss boss = Instantiate(bossPrefab);
            boss.SetBossObject(currentZone.boss);
            currentBoss = boss;
        }
        else
        {
            Enemy enemy = Instantiate(enemyPrefab);
            int randomEnemy = UnityEngine.Random.Range(0, currentZone.enemies.Count - 1);
            enemy.SetEnemyObject(currentZone.enemies[randomEnemy]);
            enemy.SetStats(player.playerStats.currentDifficulty, player.playerStats.currentStage);
            currentEnemy = enemy;
        }
    }
    public void ChangeStage(int stage)
    {
        if (stage - 1 < player.playerStats.highestStage)
        {
            player.playerStats.currentStage = stage;
            ChangeEnemy();
        }
        else
        {
            player.playerStats.currentStage = player.playerStats.highestStage - 1;
            ChangeEnemy();
        }
    }
}
