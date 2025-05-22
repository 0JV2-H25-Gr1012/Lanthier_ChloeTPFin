using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        // Singleton check to prevent duplicates
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();

            float savedVolume = PlayerPrefs.GetFloat("volume", 0.5f);
            AudioListener.volume = savedVolume;

            if (audioSource != null)
            {
                audioSource.volume = savedVolume;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void UpdateVolume(float newVolume)
    {
        AudioListener.volume = newVolume;
        PlayerPrefs.SetFloat("volume", newVolume);

        if (audioSource != null)
        {
            audioSource.volume = newVolume;
        }
    }
}
