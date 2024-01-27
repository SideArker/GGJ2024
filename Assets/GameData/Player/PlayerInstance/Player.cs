using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public PlayerStats playerStats { get; private set; }
    [SerializeField] Slider funmeter;

    private void Awake()
    {
        Instance = this;
        playerStats = GetComponent<PlayerStats>();

    }
    public void SetFunmeter(float value)
    {
        print(value);
        funmeter.value = value;
    }
    private void Start()
    {
    }
}
