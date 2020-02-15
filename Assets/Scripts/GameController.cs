using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    void Start()
    {
        Debug.Log(AmountOfPlayers.playerCount);
        if (AmountOfPlayers.playerCount == 2)
        {
            Debug.Log("2");
        }
        if (AmountOfPlayers.playerCount == 3)
        {
            Debug.Log("3");
        }
    }
}
