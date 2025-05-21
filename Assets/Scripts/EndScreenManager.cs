using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenManager : MonoBehaviour
{
    public GameObject victoryScreen;  // assign in Inspector
    public GameObject defeatScreen;   // assign in Inspector

    void Start()
    {
        if (GameResult.DidPlayerWin)
        {
            victoryScreen.SetActive(true);
            defeatScreen.SetActive(false);
        }
        else
        {
            victoryScreen.SetActive(false);
            defeatScreen.SetActive(true);
        }
    }
}
