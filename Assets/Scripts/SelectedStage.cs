using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedStage : MonoBehaviour
{
    public MenuController menuController;
    public int setSelectedStage;
    public static int selectedStage;

    //Set player count from pressed menu buttons
    public void SetStage(int setSelectedStage)
    {
        selectedStage = setSelectedStage;
        menuController.PlayerSelectionButton();
    }
}
