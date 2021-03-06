using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;

    private Checkpoint[] checkpoints;

    [HideInInspector] public Vector3 spawnPoint;

    private void Awake()
    {
        instance = this;

        checkpoints = FindObjectsOfType<Checkpoint>();
    }
    private void Start()
    {
        spawnPoint = PlayerController.instance.transform.position;
    }
    public void DeactivateCheckpoints()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoint();
        }
    }
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
