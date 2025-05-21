using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject volumeCanvas;
    public GameObject instructionCanvas;

    public void ShowVolume()
    {
        menuCanvas.SetActive(false);
        volumeCanvas.SetActive(true);
    }

    public void ShowInstructions()
    {
        menuCanvas.SetActive(false);
        instructionCanvas.SetActive(true);
    }

    public void BackToMenu()
    {
        volumeCanvas.SetActive(false);
        instructionCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }
}
