using UnityEngine;
using UnityEngine.UI;

public class UIButtonClickSound : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        Button[] allButtons = FindObjectsOfType<Button>();

        Debug.Log("Found " + allButtons.Length + " buttons.");

        foreach (Button btn in allButtons)
        {
            Debug.Log("Setting up button: " + btn.name);
            btn.onClick.AddListener(() =>
            {
                if (audioSource != null && clickSound != null)
                {
                    Debug.Log("Click sound played");
                    audioSource.PlayOneShot(clickSound);
                }
            });
        }
    }
}
