using UnityEngine;

public class Potion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PotionEffect();
        }
    }
    protected virtual void PotionEffect() { }
}
