using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    public AudioClip[] hitSounds; // Assign 3 hit sounds in Inspector
    private AudioSource audioSource;

    private int lives = 3;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void LoseLife()
    {
        if (lives <= 0)
            return;

        // Play random hit sound
        if (hitSounds.Length > 0 && audioSource != null)
        {
            int index = Random.Range(0, hitSounds.Length);
            audioSource.PlayOneShot(hitSounds[index]);
        }

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