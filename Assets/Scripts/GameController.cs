using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    void Start()
    {
        if (AmountOfPlayers.playerCount == 2)
        {
            GameObject newCanvas = Instantiate(canvas) as GameObject;
            Debug.Log("2");
        }
        if (AmountOfPlayers.playerCount == 3)
        {
            Debug.Log("3");
        }
    }
}
