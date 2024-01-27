using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CritPopUp : MonoBehaviour
{
    public float CritChance = 1f;
    [SerializeField] float tickTime = 1f;
    bool isWaiting = false;
    [SerializeField] Transform popUp;
    [SerializeField] Vector2[] posRange;
    [SerializeField] float onScreenTime;
    private void Start()
    {

    }
    private void Update()
    {
        if (!isWaiting) StartCoroutine(Cycle());
    }
    IEnumerator Cycle()
    {
        isWaiting = true;
        yield return new WaitForSeconds(tickTime);
        if (Random.Range(1, 1000) < CritChance * 10)
            ShowPopUp();
        yield return new WaitForSeconds(onScreenTime);
        popUp.gameObject.SetActive(false);
        isWaiting = false;
    }
    [Button]
    public void ShowPopUp()
    {
        //popUp.position = new Vector3(posRange.x, posRange.y);
        popUp.position = new Vector3(Random.Range(posRange[0].x, posRange[1].x), Random.Range(posRange[0].y, posRange[1].y));
        popUp.gameObject.SetActive(true);
    }
    public void Click()
    {
        popUp.gameObject.SetActive(false);
        isWaiting = false;
        StopCoroutine(Cycle());
        //rest of code :D
        print("clicked");
    }
}
