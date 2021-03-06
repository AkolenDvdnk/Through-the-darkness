using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();   
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointController.instance.DeactivateCheckpoints();

            animator.SetBool("isActivated", true);

            CheckpointController.instance.SetSpawnPoint(transform.position);
        }
    }
    public void ResetCheckpoint()
    {
        animator.SetBool("isActivated", false);
    }
}
