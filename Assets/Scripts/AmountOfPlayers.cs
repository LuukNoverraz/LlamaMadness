using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmountOfPlayers : MonoBehaviour
{
    public int setPlayerCount;
    public static int playerCount;

    //Set player count from pressed menu buttons
    public void SetPlayers(int setPlayerCount)
    {
        playerCount = setPlayerCount;
        SceneManager.LoadScene("Main");
    }
}