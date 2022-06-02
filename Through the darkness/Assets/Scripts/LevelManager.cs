using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;

    private void Awake()
    {
        instance = this;
    }
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }
    private IEnumerator RespawnCo()
    {
        PlayerComponents.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn);

        PlayerComponents.instance.gameObject.SetActive(true);
        PlayerComponents.instance.transform.position = CheckpointController.instance.spawnPoint;

        PlayerStats.instance.currentHealth = PlayerStats.instance.maxHealth;

        UIController.instance.UpdateHealthUI();

    }
}
