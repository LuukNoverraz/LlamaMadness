using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

#pragma warning disable 0649

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefabs;
    [SerializeField] private GameObject[] mapPrefabs;
    public Vector3[] dreamyCheckpointLocations;
    public Vector3[] floatyCheckpointLocations;
    [HideInInspector] public int stage;
    [HideInInspector] public int passedCheckpoints;
    [HideInInspector] public int stageCheckpointAmounts;

    void Start()
    {   
        // Set border image based on player amount
        if (AmountOfPlayers.playerCount == 2)
        {
            Instantiate(playerPrefabs[0]);
        }
        if (AmountOfPlayers.playerCount == 3)
        {
            Instantiate(playerPrefabs[1]);
        }
        if (SelectedStage.selectedStage == 1)
        {
            Instantiate(mapPrefabs[0]);
        }
        if (SelectedStage.selectedStage == 2)
        {
            stage = 2;
            Instantiate(mapPrefabs[1]);
            stageCheckpointAmounts = 18;
        }
        if (SelectedStage.selectedStage == 3)
        {
            stage = 3;
            Instantiate(mapPrefabs[2]);
            stageCheckpointAmounts = 23;
        }
    }

    public void CheckpointPassed()
    {
        passedCheckpoints++;
        Debug.Log("Checkpoint passed");
    }
}