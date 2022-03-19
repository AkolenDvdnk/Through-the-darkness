using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Potion
{
    public int healPower = 1;

    protected override void PotionEffect()
    {
        if (PlayerStats.instance.currentHealth == PlayerStats.instance.maxHealth)
            return;

        PlayerStats.instance.currentHealth += healPower;
        UIController.instance.UpdateHealthUI();

        Destroy(gameObject);
    }
}
