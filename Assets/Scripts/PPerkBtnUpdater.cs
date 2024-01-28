using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPerkBtnUpdater : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    TooltipTrigger tooltip;
    [SerializeField] PrestigePerkObject prestigePerkObject;
    public bool isPurchased = false;
    [SerializeField] Color[] colors;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tooltip = GetComponent<TooltipTrigger>();
        spriteRenderer.sprite = prestigePerkObject.sprite;
        tooltip.header = prestigePerkObject.perkName;
        tooltip.content = prestigePerkObject.perkDescription;
        spriteRenderer.color = colors[0];
    }
    public void OnMouseDown()
    {
        if(!isPurchased)
        {
            var playerstats = Player.Instance.playerStats;
            playerstats.prestigePoints -= prestigePerkObject.cost;
            isPurchased = true;
            spriteRenderer.color = colors[1];

            playerstats.damage.addModifier(prestigePerkObject.clickPowerMultiplier/100);
        }
    }
}
