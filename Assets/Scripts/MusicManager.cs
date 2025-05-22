using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    void Awake()
{
    if (instance == null)
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();

        float volume = PlayerPrefs.GetFloat("musicVol", 0.5f);

        audioSource.volume = volume;

        audioSource.loop = true;
        audioSource.Play();
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
