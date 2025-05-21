using UnityEngine;

public class ToggleVolumeMenu : MonoBehaviour
{
    [SerializeField] private GameObject volumeCanvas;
    private bool isVisible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            isVisible = !isVisible;
            volumeCanvas.SetActive(isVisible);
        }
    }
}

