using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    private int lives = 3;

    public void LoseLife()
    {
        if (lives <= 0)
            return;

        lives--;

        switch (lives)
        {
            case 2:
                Heart3.enabled = false;
                Debug.Log("Lost 1st life. 2 remaining.");
                break;
            case 1:
                Heart2.enabled = false;
                Debug.Log("Lost 2nd life. 1 remaining.");
                break;
            case 0:
                Heart1.enabled = false;
                Debug.Log("Lost final life. Game Over!");

                GameResult.DidPlayerWin = false;
                GameResult.PreviousScene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("MenuDeFin");

                break;
        }
    }
}
