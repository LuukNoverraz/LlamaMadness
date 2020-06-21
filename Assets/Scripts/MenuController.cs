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
    [SerializeField] private GameObject mapSelection;
    
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
        mapSelection.SetActive(true);
    }
    public void StageBackButton()
    {
        // Change player selection menu back to player selection
        mainMenu.SetActive(true);
        mapSelection.SetActive(false);
    }

    public void BackButton()
    {
        // Change player selection menu back to main menu
        playerSelection.SetActive(false);
        mapSelection.SetActive(true);
    }
}
