using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : Potion
{
    public int manaRestore = 1;

    protected override void PotionEffect()
    {
        if (PlayerStats.instance.currentMana == PlayerStats.instance.maxMana)
            return;

        PlayerStats.instance.currentMana += manaRestore;
        UIController.instance.UpdateManaUI();

        Destroy(gameObject);
    }
}
