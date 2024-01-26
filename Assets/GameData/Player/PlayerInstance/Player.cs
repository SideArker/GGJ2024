using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public PlayerStats playerStats { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }
}
