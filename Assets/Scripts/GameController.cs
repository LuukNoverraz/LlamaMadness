using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

#pragma warning disable 0649

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefabs;
    [SerializeField] private GameObject[] mapPrefabs;
    private Camera[] playerCameras;
    [SerializeField] private Color[] skyColors;

    void Awake()
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
            Instantiate(mapPrefabs[1]);
        }
        if (SelectedStage.selectedStage == 3)
        {
            Instantiate(mapPrefabs[2]);
        }

        playerCameras[0] = GameObject.FindWithTag("Llama Player 1").GetComponent<Camera>();
        playerCameras[1] = GameObject.FindWithTag("Llama Player 2").GetComponent<Camera>();
        
        if (SelectedStage.selectedStage == 1)
        {
            playerCameras[0].backgroundColor = skyColors[0];
            playerCameras[1].backgroundColor = skyColors[0];
        }
        if (SelectedStage.selectedStage == 2)
        {
            playerCameras[0].backgroundColor = skyColors[1];
            playerCameras[1].backgroundColor = skyColors[1];
        }
        if (SelectedStage.selectedStage == 3)
        {
            playerCameras[0].backgroundColor = skyColors[2];
            playerCameras[1].backgroundColor = skyColors[2];
        }
    }
}