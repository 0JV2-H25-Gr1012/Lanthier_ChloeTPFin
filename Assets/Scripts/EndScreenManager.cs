using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    public GameObject victoryScreen;
    public GameObject victoryLevel1Screen;
    public GameObject defeatScreen;

void Start()
{
    Invoke("ShowEndScreen", 0.1f); // Small delay
}

void ShowEndScreen()
{
    string previousScene = GameResult.PreviousScene;
    Debug.Log("🟦 Previous Scene: " + previousScene);
    Debug.Log("🟨 DidPlayerWin: " + GameResult.DidPlayerWin);

    if (GameResult.DidPlayerWin)
    {
        if (previousScene == "niveau1")
        {
            Debug.Log("🟢 Victory Screen for Level 1");
            victoryLevel1Screen.SetActive(true);
            victoryScreen.SetActive(false);
        }
        else
        {
            Debug.Log("🟢 General Victory Screen");
            victoryScreen.SetActive(true);
            victoryLevel1Screen.SetActive(false);
        }

        defeatScreen.SetActive(false);
    }
    else
    {
        Debug.Log("🔴 Player lost. Showing defeat screen.");
        victoryScreen.SetActive(false);
        victoryLevel1Screen.SetActive(false);
        defeatScreen.SetActive(true);
    }
}


}