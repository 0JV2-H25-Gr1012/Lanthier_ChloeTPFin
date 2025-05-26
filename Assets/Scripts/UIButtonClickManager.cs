using UnityEngine;
using UnityEngine.UI;

public class UIButtonClickManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;

    void Start()
    {
        Button[] allButtons = FindObjectsOfType<Button>(true); 

        foreach (Button btn in allButtons)
        {
            
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
