using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefabs;
    [SerializeField] private GameObject borderImage;
    [SerializeField] private Sprite twoPlayersBorders;
    [SerializeField] private Sprite threePlayersBorders;

    void Start()
    {
        borderImage.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        if (AmountOfPlayers.playerCount == 2)
        {
            Instantiate(playerPrefabs[0]);
            borderImage.GetComponent<Image>().sprite = twoPlayersBorders;
        }
        if (AmountOfPlayers.playerCount == 3)
        {
            Instantiate(playerPrefabs[1]);
            borderImage.GetComponent<Image>().sprite = threePlayersBorders;
        }
    }
}
