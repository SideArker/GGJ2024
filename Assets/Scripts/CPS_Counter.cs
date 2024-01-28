using Managers.Sounds;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CPS_Counter : MonoBehaviour
{
    [SerializeField] TMP_Text outPutText;
    [SerializeField] string TextBeforeCPS;
    int clicks = 0;
    bool isCycle = false;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clicks++;
            SoundManager.Instance.PlayOneShoot(SoundManager.Instance.UISource, SoundManager.Instance.UICollection.clips[0]);
        }

        if(!isCycle)
        {
            StartCoroutine(Counter());
        }
    }
    IEnumerator Counter()
    {
        isCycle = true;
        yield return new WaitForSeconds(1);
        outPutText.text = TextBeforeCPS + clicks.ToString();
        clicks = 0;
        isCycle = false;
    }
}
