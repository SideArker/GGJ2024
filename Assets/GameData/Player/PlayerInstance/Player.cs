using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public PlayerStats playerStats { get; private set; }

    private void Awake()
    {
        Instance = this;
        playerStats = GetComponent<PlayerStats>();

    }

    private void Start()
    {
    }
}
