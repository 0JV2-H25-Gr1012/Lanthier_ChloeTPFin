using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButtonClickSound : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {

        Button[] allButtons = Resources.FindObjectsOfTypeAll<Button>();

        foreach (Button btn in allButtons)
        {
            btn.onClick.AddListener(() =>
            {
                if (audioSource != null && clickSound != null)
                {
                    audioSource.PlayOneShot(clickSound);
                }
            });
        }
    }
}
