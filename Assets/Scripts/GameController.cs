using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private RectTransform borderTransform;
    void Start()
    {
        if (AmountOfPlayers.playerCount == 2)
        {
            Debug.Log("2");
        }
        if (AmountOfPlayers.playerCount == 3)
        {
            Debug.Log("3");
        }
        borderTransform.localPosition = new Vector2(Screen.width / AmountOfPlayers.playerCount, 0);
        borderTransform.sizeDelta = new Vector2(18.0f, Screen.height);
    }
}
