using UnityEngine;
using TMPro;

public class EndScreenUI : MonoBehaviour
{
    [Header("Text Fields - Level 1 Victory")]
    public TextMeshProUGUI scoreText_Level1;
    public TextMeshProUGUI timeText_Level1;
    public TextMeshProUGUI livesText_Level1;

    [Header("Text Fields - Regular Victory")]
    public TextMeshProUGUI scoreText_Regular;
    public TextMeshProUGUI timeText_Regular;
    public TextMeshProUGUI livesText_Regular;

    [Header("Text Fields - Defeat")]
    public TextMeshProUGUI scoreText_Defeat;
    public TextMeshProUGUI timeText_Defeat;
    public TextMeshProUGUI livesText_Defeat;

    [Header("Panels")]
    public GameObject Victoire1niveau;
    public GameObject Victoire;
    public GameObject Defaite;

    void Start()
    {
        // First disable all panels
        Victoire1niveau.SetActive(false);
        Victoire.SetActive(false);
        Defaite.SetActive(false);

        if (GameResult.DidPlayerWin)
        {
            if (GameResult.PreviousScene == "niveau1")
            {
                // Activate Level 1 Victory
                Victoire1niveau.SetActive(true);
                scoreText_Level1.text = "" + EndGameData.finalScore;
                timeText_Level1.text = "" + FormatTime(EndGameData.timeLeft);
                livesText_Level1.text = "" + EndGameData.livesLeft;
            }
            else
            {
                // Activate Regular Victory
                Victoire.SetActive(true);
                scoreText_Regular.text = "" + EndGameData.finalScore;
                timeText_Regular.text = "" + FormatTime(EndGameData.timeLeft);
                livesText_Regular.text = "" + EndGameData.livesLeft;
            }
        }
        else
        {
            // Activate Defeat screen
            Defaite.SetActive(true);
            scoreText_Defeat.text = "" + EndGameData.finalScore;
            timeText_Defeat.text = "" + FormatTime(EndGameData.timeLeft);
            livesText_Defeat.text = "" + EndGameData.livesLeft;
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
