﻿using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 5;
    public int maxMana = 5;
    [HideInInspector] public int currentHealth;
    [HideInInspector] public int currentMana;

    public HealthBar healthBar;
    public ManaBar manaBar;

    private void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;

        healthBar.SetMaxHealth(maxHealth);
        manaBar.SetMaxMana(maxMana);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (currentHealth <= 0)
                return;

            TakeDamage(1);
            Debug.Log(currentHealth);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (currentMana <= 0)
                return;

            ReduceMana(1);
            Debug.Log(currentMana);
        }
    }
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    private void ReduceMana(int manaCost)
    {
        currentMana -= manaCost;

        manaBar.SetMana(currentMana);
    }
}