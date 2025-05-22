using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionWithSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private float delayBeforeLoad = 0.2f;

    public void LoadSceneWithSound(string sceneName)
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        StartCoroutine(LoadAfterDelay(sceneName));
    }

    private IEnumerator LoadAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene(sceneName);
    }
}
