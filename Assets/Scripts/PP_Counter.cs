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
    private void Update()
    {
        if (!isCycle) StartCoroutine(Tick());
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
        outputText.text = CalculateTokenCount(Player.Instance.playerStats.prestigePoints, costOfFirstPoint).ToString();
        yield return new WaitForSeconds(1);
        isCycle = false;

    }
}
