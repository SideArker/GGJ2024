using NaughtyAttributes;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    public static ZoneController instance;
    Player player;
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] Boss bossPrefab;
    Enemy currentEnemy;
    Boss currentBoss;

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
        int randomEnemy = Random.Range(0, currentZone.enemies.Count - 1);
        enemy.SetEnemyObject(currentZone.enemies[randomEnemy]);
        currentEnemy = enemy;
    }

    public void ChangeZone()
    {
        float zoneIndex = player.playerStats.currentStage / 10;
    }

    public void DamageEnemy()
    {
        if (currentBoss) currentBoss.TakeDamage();
        else currentBoss = null;
        if (currentEnemy) currentEnemy.TakeDamage();
        else currentEnemy = null;
    }

    public void ChangeEnemy()
    {
        player.playerStats.currentStage++;
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
            int randomEnemy = Random.Range(0, currentZone.enemies.Count - 1);
            enemy.SetEnemyObject(currentZone.enemies[randomEnemy]);
            currentEnemy = enemy;
        }
    }
}
