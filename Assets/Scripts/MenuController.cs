using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#pragma warning disable 0649

public class MenuController : MonoBehaviour
{
    [SerializeField] private RectTransform background;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject playerSelection;
    
    private Vector2 screenSize = new Vector2(Screen.width, Screen.height);

    void Start()
    {
        // Set background image to size of screen
        background.sizeDelta = screenSize;
    }

    public void PlayerSelectionButton()
    {
        // Change menu from main to player selection
        mainMenu.SetActive(false);
        playerSelection.SetActive(true);
    }

    public void BackButton()
    {
        // Change player selection menu back to main menu
        playerSelection.SetActive(false);
        mainMenu.SetActive(true);
    }
}
