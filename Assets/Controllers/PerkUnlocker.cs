using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PerkUnlocker : MonoBehaviour
{
    public static PerkUnlocker Instance;

    public List<PerkObject> unlockedPerks;

    [SerializeField] PerkObject[] clownCostumePerks;
    [SerializeField] PerkObject[] funnyJokesPerks;
    [SerializeField] PerkObject[] soundEffectsPerks;
    [SerializeField] PerkObject[] slipFallPerks;
    [SerializeField] PerkObject[] prankPerks;
    [SerializeField] PerkObject[] ticklingPerks;
    [SerializeField] PerkObject[] potionPerks;
    [SerializeField] PerkObject[] chipsPerks;


    public void UnlockPerks(UpgradeType upgradeType)
    {
        Player player = Player.Instance;

        PerkObject[] iterationObject;

        switch(upgradeType)
        {
            case UpgradeType.Costume:
                {
                    iterationObject = clownCostumePerks;
                    break;
                }
            case UpgradeType.Jokes:
                {
                    iterationObject = funnyJokesPerks;
                    break;
                }
            case UpgradeType.SoundEffects:
                {
                    iterationObject = soundEffectsPerks;
                    break;
                }
            case UpgradeType.SlipFall:
                {
                    iterationObject = slipFallPerks;
                    break;
                }
            case UpgradeType.Tickle:
                {
                    iterationObject = ticklingPerks;
                    break;
                }
            case UpgradeType.Potion:
                {
                    iterationObject = potionPerks;
                    break;
                }
            case UpgradeType.BrainChip:
                {
                    iterationObject = chipsPerks;
                    break;
                }
            default:
                {
                    iterationObject = funnyJokesPerks;
                        break;
                }
        }

        Upgrade upg = player.playerStats.upgrades.Find(x => x.upgradeObject.upgradeType == upgradeType);

        foreach (PerkObject perk in iterationObject)
        {
            if (player.playerStats.perks.Find(x => x.perkObject == perk) != null) return;

            if (perk.upgradeNeeded == upg.upgradeObject && upg.Level >= perk.amountNeeded)
            {
                Debug.Log("Found matching perk");
                Debug.Log(perk);
                unlockedPerks.Add(perk);
            };
        }

    }

    private void Awake()
    {
        Instance = this;
    }
}
