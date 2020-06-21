using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

#pragma warning disable 0649

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefabs;
    [SerializeField] private GameObject[] mapPrefabs;
    [SerializeField] private GameObject borderImage;
    [SerializeField] private Sprite twoPlayersBorders;
    [SerializeField] private Sprite threePlayersBorders;

    void Start()
    {
        // Set border image based on player amount
        borderImage.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        if (AmountOfPlayers.playerCount == 2)
        {
            Instantiate(playerPrefabs[0]);
            // borderImage.GetComponent<Image>().sprite = twoPlayersBorders;
        }
        if (AmountOfPlayers.playerCount == 3)
        {
            Instantiate(playerPrefabs[1]);
            // borderImage.GetComponent<Image>().sprite = threePlayersBorders;
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
    }
}
