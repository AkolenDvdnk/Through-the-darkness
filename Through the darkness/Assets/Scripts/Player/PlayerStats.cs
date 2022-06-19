using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public int maxHealth = 5;
    public int maxMana = 5;
    [HideInInspector] public int currentHealth;
    [HideInInspector] public int currentMana;

    [SerializeField] HealthBar healthBar;
    [SerializeField] ManaBar manaBar;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;

        healthBar.SetMaxHealth(maxHealth);
        manaBar.SetMaxMana(maxMana);
    }
    private void Update()
    {
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (currentHealth <= 0)
            Death();

        if (Input.GetKeyDown(KeyCode.O))
        {
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
    private void Death()
    {
        LevelManager.instance.RespawnPlayer();
    }
}
