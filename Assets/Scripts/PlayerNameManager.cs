using UnityEngine;
using TMPro;

public class PlayerNameManager : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void SaveName()
    {
        string playerName = nameInput.text;
        PlayerPrefs.SetString("playerName", playerName);
    }
}

