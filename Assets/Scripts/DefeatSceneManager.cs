using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatSceneManager : MonoBehaviour
{
    public void RestartLastLevel()
    {
        string sceneToReload = GameResult.PreviousScene;

        if (string.IsNullOrEmpty(sceneToReload))
        {
            sceneToReload = "niveau1"; 
        }

        SceneManager.LoadScene(sceneToReload);
    }
}