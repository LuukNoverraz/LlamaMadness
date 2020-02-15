using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        mainMenu.SetActive(false);
        playerSelection.SetActive(true);
    }

    public void BackButton()
    {
        playerSelection.SetActive(false);
        mainMenu.SetActive(true);
    }
}
