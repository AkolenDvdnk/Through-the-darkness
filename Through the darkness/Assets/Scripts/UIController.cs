using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public HealthBar healthBar;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateHealthUI()
    {
        healthBar.SetHealth(PlayerStats.instance.currentHealth);
    }
}
