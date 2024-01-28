using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesSpriteController : MonoBehaviour
{
    EnemyObject enemyObject;
    BossObject bossObject;
    Enemy enemy;
    Boss boss;
    Image image;
    bool isAnimate = false;
    [SerializeField] float animTimeDelay = .5f;
    private void Start()
    {
        image = GetComponent<Image>();
        enemy = GetComponent<Enemy>();
        boss = GetComponent<Boss>();
        if (enemy)
        {
            enemyObject = enemy.enemyObject;
        }
        else
        {
            boss = GetComponent<Boss>();
            bossObject = boss.bossObject;
        }
    }

    private void Update()
    {
        if(!isAnimate)
        {
            StartCoroutine(animation());
        }
    }
    IEnumerator animation()
    {
        isAnimate = true;
        if(enemy)
        {
            image.sprite = (enemyObject.baseHealth / enemy.currentHealth >= 1.25f) ? enemyObject.laughingSprites[0] : enemyObject.normalSprites[0];
            yield return new WaitForSeconds(animTimeDelay);
            image.sprite = (enemyObject.baseHealth / enemy.currentHealth >= 1.25f) ? enemyObject.laughingSprites[1] : enemyObject.normalSprites[1];
        }
        else
        {
            image.sprite = (bossObject.baseHealth / boss.currentHealth >= 1.25f) ? bossObject.laughingSprites[0] : bossObject.normalSprites[0];
            yield return new WaitForSeconds(animTimeDelay);
            image.sprite = (bossObject.baseHealth / boss.currentHealth >= 1.25f) ? bossObject.laughingSprites[1] : bossObject.normalSprites[1];

        }
        yield return new WaitForSeconds(animTimeDelay);
        isAnimate = false;
    }
}
