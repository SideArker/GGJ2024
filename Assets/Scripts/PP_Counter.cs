using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PP_Counter : MonoBehaviour
{
    [SerializeField] TMP_Text outputText;
    [SerializeField] double costOfFirstPoint = 100000;
    bool isCycle = false;
    private void Start()
    {
        if (!isCycle) StartCoroutine(Tick());
    }

    public void OnClick()
    {
        int tokens = CalculateTokenCount(Player.Instance.playerStats.laughs, costOfFirstPoint);
        if (tokens > 0)
        {
            Player.Instance.GetComponent<Prestige>().OnPrestige(tokens);
        }

    }

    public static int CalculateTokenCount(double budget, double costOfFirstToken)
    {
        int tokenCount = 0;
        double costOfNextToken = costOfFirstToken;

        while (budget >= costOfNextToken)
        {
            budget -= costOfNextToken;
            tokenCount++;
            costOfNextToken = math.ceil(costOfNextToken * 1.1); // Round up to the nearest integer
        }

        return tokenCount;
    }
    IEnumerator Tick()
    {
        isCycle = true;
        while (isCycle)
        {
            outputText.text = CalculateTokenCount(Player.Instance.playerStats.laughs, costOfFirstPoint).ToString();
            yield return new WaitForSeconds(1);
        }
    }
}
