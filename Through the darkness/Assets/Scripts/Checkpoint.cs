using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject glow;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointController.instance.DeactivateCheckpoints(); 

            glow.SetActive(true);

            CheckpointController.instance.SetSpawnPoint(transform.position);
        }
    }
    public void ResetCheckpoint()
    {
        glow.SetActive(false);
    }
}
