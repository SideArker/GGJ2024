using Managers.Sounds;
using NaughtyAttributes;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ZoneController : MonoBehaviour
{
    public static ZoneController instance;
    public bool autoNextStage = true;

    [Header("Hierarchy")]
    [SerializeField] ZoneHierarchy zoneHierarchy;

    [Header("Prefabs")]
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] Boss bossPrefab;

    [Header("Btn Sprites")]
    [SerializeField] Sprite[] pauseBtnSprites;

    [Header("Other")]
    [SerializeField] Transform spawnPos;
    [SerializeField] TMP_Text stageText;

    Player player;

    Enemy currentEnemy;
    Boss currentBoss;
    public bool isEnemyAlive = true;

    bool clickCooldown = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player = Player.Instance;
        ZoneObject currentZone = player.playerStats.currentZone;
        stageText.text = "Stage: " + player.playerStats.currentStage;


        // On zone startv
        isEnemyAlive = true;
        Enemy enemy = Instantiate(enemyPrefab, spawnPos);
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
        AutoNextStage();
        //ChangeEnemy();
    }

    void ClickCooldown()
    {
        clickCooldown = false;
    }


    public void DamageEnemy()
    {
        //print("DAMAGE!!!!!!!!!!!");
        SoundManager.Instance.PlayOneShoot(SoundManager.Instance.UISource, SoundManager.Instance.UICollection.clips[0]);

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
        Player.Instance.SetFunmeter(0);

        if (player.playerStats.highestStage < player.playerStats.currentStage)
        {
            player.playerStats.highestStage = player.playerStats.currentStage;
        }

        ZoneObject currentZone = player.playerStats.currentZone;
        isEnemyAlive = true;
        if (player.playerStats.currentStage % 10 == 0)
        {
            Debug.Log("Spawn boss");
            Boss boss = Instantiate(bossPrefab, spawnPos);
            boss.SetBossObject(currentZone.bosses[UnityEngine.Random.Range(0, currentZone.bosses.Count)]);
            boss.SetStats(player.playerStats.currentDifficulty, player.playerStats.currentStage);
            currentBoss = boss;
        }
        else
        {
            Enemy enemy = Instantiate(enemyPrefab, spawnPos);
            int randomEnemy = UnityEngine.Random.Range(0, currentZone.enemies.Count);
            enemy.SetEnemyObject(currentZone.enemies[randomEnemy]);
            enemy.SetStats(player.playerStats.currentDifficulty, player.playerStats.currentStage);
            currentEnemy = enemy;
            //print(currentEnemy.currentHealth);
        }
    }
    public void SwitchAutoNextStage(Image img)
    {
        if (autoNextStage)
        {
            autoNextStage = false;
            img.sprite = pauseBtnSprites[0];
        }
        else
        {
            autoNextStage = true;
            img.sprite = pauseBtnSprites[1];
        }
    }
    public void AutoNextStage()
    {
        if (autoNextStage) NextStage();
    }
    public void NextStage()
    {
        if (!isEnemyAlive)
        {
            player.playerStats.currentStage++;
            stageText.text = "Stage: " + player.playerStats.currentStage;
            player.playerStats.currentDifficulty = player.playerStats.currentStage * .2f + 1;
            ChangeEnemy();
        }
    }
    public void PreviousStage()
    {
        if (player.playerStats.currentStage > 1)
        {
            isEnemyAlive = false;
            try
            {
                Destroy(currentEnemy.gameObject);
                print("fucking shit");
            }
            catch
            {
                try
                {
                    Destroy(currentBoss.gameObject);
                }
                catch { }
            }

            player.playerStats.currentStage--;
            stageText.text = "Stage: " + player.playerStats.currentStage;

            player.playerStats.currentDifficulty = player.playerStats.currentStage * .2f + 1;
            ChangeEnemy();
        }
    }
    public void ChangeStage(int stage)
    {
        if (stage - 1 < player.playerStats.highestStage)
        {
            player.playerStats.currentStage = stage;
            player.playerStats.currentDifficulty = player.playerStats.currentStage * .2f + 1;

            ChangeEnemy();
        }
        else
        {
            player.playerStats.currentStage = player.playerStats.highestStage - 1;
            player.playerStats.currentDifficulty = player.playerStats.currentStage * .2f + 1;

            ChangeEnemy();
        }
    }
}
