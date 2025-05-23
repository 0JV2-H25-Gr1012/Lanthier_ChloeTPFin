using UnityEngine;
using UnityEngine.UI;

public class UIButtonClickManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;

    void Start()
    {
        Button[] allButtons = FindObjectsOfType<Button>(true); // include inactive buttons

        foreach (Button btn in allButtons)
        {
            // Skip buttons that already have their own click logic
            if (btn.GetComponent<UIButtonSoundOnly>() == null)
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
}
