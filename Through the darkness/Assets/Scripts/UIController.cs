using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public HealthBar healthBar;
    public ManaBar manaBar;
    private void Awake()
    {
        instance = this;
    }
    public void UpdateHealthUI()
    {
        healthBar.SetHealth(PlayerStats.instance.currentHealth);
    }

    public void UpdateManaUI()
    {
        manaBar.SetMana(PlayerStats.instance.currentMana);
    }
}
