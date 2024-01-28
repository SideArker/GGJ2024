using UnityEngine;
using UnityEngine.UI;

public class UIPerkController : MonoBehaviour
{
    public static UIPerkController instance;

    [SerializeField] GameObject perkPrefab;
    Player player;
    public void SpawnPerk(PerkObject perkObject)
    {
        GameObject perkClone = Instantiate(perkPrefab, transform);
        perkClone.transform.GetChild(0).GetComponent<Image>().sprite = perkObject.icon;
        perkClone.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(perkObject, perkClone));
        TooltipTrigger tooltipTrigger = perkClone.GetComponent<TooltipTrigger>();
        tooltipTrigger.header = perkObject.perkName;
        tooltipTrigger.content = perkObject.perkDescription;
        tooltipTrigger.special = perkObject.Cost + " Laughs";
        perkClone.SetActive(true);
    }

    public void OnButtonClick(PerkObject perk, GameObject btn)
    {
        if (player.playerStats.laughs < perk.Cost) return;
        PerkController.Instance.BuyPerk(perk);
        Destroy(btn);
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player = Player.Instance;
    }
}
