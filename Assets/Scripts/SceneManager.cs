using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void LoadSceneJeu()
    {
        SceneManager.LoadScene("niveau1");
    }

    public void LoadNiveau2()
    {
        SceneManager.LoadScene("niveau2");
    }

    public void RestartNiveau1()
    {
        SceneManager.LoadScene("niveau1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}