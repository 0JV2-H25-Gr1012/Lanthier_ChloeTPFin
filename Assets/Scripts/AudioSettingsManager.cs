using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider ambientSlider;

    void Start()
    {
        float musicVol = PlayerPrefs.GetFloat("musicVol", 0.5f);
        float ambientVol = PlayerPrefs.GetFloat("ambientVol", 0.5f);

        musicSlider.value = musicVol;
        ambientSlider.value = ambientVol;

        SetMusicVolume(musicVol);
        SetAmbientVolume(ambientVol);

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        ambientSlider.onValueChanged.AddListener(SetAmbientVolume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1)) * 20);
        PlayerPrefs.SetFloat("musicVol", volume);
    }

    public void SetAmbientVolume(float volume)
    {
        audioMixer.SetFloat("AmbientVolume", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1)) * 20);
        PlayerPrefs.SetFloat("ambientVol", volume);
    }
}
