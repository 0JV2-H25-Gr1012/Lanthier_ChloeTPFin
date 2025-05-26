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
    
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        
        if (inputField != null && !string.IsNullOrWhiteSpace(inputField.text))
        {
            StartCoroutine(LoadSceneAfterDelay());
        }
        else
        {
            Debug.Log("Champ de saisie vide. Le jeu ne commence pas.");
            
        }
    }

    private System.Collections.IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeScene);
        SceneManager.LoadScene(sceneToLoad);
    }
}
