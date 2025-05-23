using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LivesManager livesManager;
    public GameTimer gameTimer;
    public ScoreManager scoreManager;

    private bool gameEnded = false;

    public void EndGame(bool victory)
    {
        if (gameEnded) return;
        gameEnded = true;

        EndGameData.finalScore = scoreManager.GetScore();
        EndGameData.timeLeft = gameTimer.GetRemainingTime();
        EndGameData.livesLeft = livesManager.GetLives();

        GameResult.DidPlayerWin = victory;
        GameResult.PreviousScene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene("MenuDeFin");
    }
}