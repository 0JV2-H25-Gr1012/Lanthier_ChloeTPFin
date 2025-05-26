using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIButtonSoundOnly : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private string sceneToLoad = "niveau1";
    [SerializeField] private float delayBeforeScene = 0.2f;

    public void OnStartButtonClick()
    {
        // ✅ Always play the click sound
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        // 🚫 Only start the scene if the input field is filled
        if (inputField != null && !string.IsNullOrWhiteSpace(inputField.text))
        {
            StartCoroutine(LoadSceneAfterDelay());
        }
        else
        {
            Debug.Log("Champ de saisie vide. Le jeu ne commence pas.");
            // Optional: Show a warning message on screen
        }
    }

    private System.Collections.IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeScene);
        SceneManager.LoadScene(sceneToLoad);
    }
}
