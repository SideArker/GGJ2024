using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public PlayerStats playerStats { get; private set; }
    [SerializeField] Slider funmeter;
    [SerializeField] TMP_Text laughsDisplay;

    [SerializeField] Color funMeterStart;
    [SerializeField] Color funMeterEnd;

    private void Awake()
    {
        Instance = this;
        playerStats = GetComponent<PlayerStats>();
    }
    void Start()
    {
        Player.Instance.SetLaughs();
    }
    public void SetFunmeter(float value)
    {
        funmeter.value = value;
        funmeter.fillRect.GetComponent<Image>().color = Color.Lerp(funMeterStart, funMeterEnd, value);
    }
    public void SetLaughs()
    {
        //print(value);
        laughsDisplay.text = NumShortener.Shorten((decimal) playerStats.laughs);
    }
}
