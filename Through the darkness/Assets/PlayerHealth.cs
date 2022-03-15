using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    [HideInInspector] public int currentHealth;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        if (currentHealth <= 0)
            return;

        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(1);
            Debug.Log(currentHealth);
        }
    }
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
