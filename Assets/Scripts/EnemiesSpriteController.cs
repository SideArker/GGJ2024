using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesSpriteController : MonoBehaviour
{
    EnemyObject enemyObject;
    Enemy enemy;
    Image image;
    bool isAnimate = false;
    [SerializeField] float animTimeDelay = .5f;
    private void Start()
    {
        image = GetComponent<Image>();
        enemy = GetComponent<Enemy>();
        enemyObject = enemy.enemyObject;
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
        image.sprite = (enemyObject.baseHealth / enemy.currentHealth >= 2) ? enemyObject.laughingSprites[0] : enemyObject.normalSprites[0];
        yield return new WaitForSeconds(animTimeDelay);
        image.sprite = (enemyObject.baseHealth / enemy.currentHealth >= 2) ? enemyObject.laughingSprites[1] : enemyObject.normalSprites[1];
        yield return new WaitForSeconds(animTimeDelay);
        isAnimate = false;
    }
}
