using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

void Start()
{
    float savedVolume = PlayerPrefs.GetFloat("volume", 0.5f);
    volumeSlider.value = savedVolume;
    AudioListener.volume = savedVolume;

    volumeSlider.onValueChanged.AddListener(SetVolume);
}

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("volume", value);
    }
}