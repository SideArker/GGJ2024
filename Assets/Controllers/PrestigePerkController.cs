using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrestigePerkController : MonoBehaviour
{
   public void BuyPerk(PrestigePerkObject perkObject)
    {
        Player player = Player.Instance;
        PrestigePerk result = player.playerStats.prestigePerks.Find(x => x.perkObject == perkObject);
        if (result != null) return;

        if (player.playerStats.prestigePoints < perkObject.cost) return;
        result = new PrestigePerk(perkObject.name, perkObject.perkDescription, perkObject, 1);

        player.playerStats.prestigePerks.Add(result);

        player.playerStats.prestigePoints -= result.perkObject.cost;
    }
}
