using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkSetter : MonoBehaviour
{
    [SerializeField] GameObject perkPrefab;
    [SerializeField] float radius;
    [SerializeField] int[] perksList;
    private void Start()
    {
        for (int i = 0; i < perksList.Length; i++)
        {
            var perk = Instantiate(perkPrefab);
            perk.transform.position = new Vector3(radius * (float)Mathf.Cos((float)CTR(45* i)), radius * (float)Mathf.Sin((float)CTR(45 * i)));
        }
    }
    public double CTR(float angle)
    {
        return (Math.PI / 180) * angle;
    }
}
