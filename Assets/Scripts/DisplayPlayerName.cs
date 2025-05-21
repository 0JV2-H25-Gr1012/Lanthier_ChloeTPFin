using UnityEngine;
using TMPro;

public class DisplayPlayerName : MonoBehaviour
{
    public TMP_Text nameDisplay;

    void Start()
    {
        string savedName = PlayerPrefs.GetString("playerName", "Joueur");
        nameDisplay.text = savedName;
    }
}
