using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameSelector : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private Button connectButton;
    [SerializeField] private int minNameLen = 1;
    [SerializeField] private int maxNameLen = 12;

    public const string PlayerNameKey = "PlayerName";

    private void Start() {
        if(SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Null){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }

        nameField.text = PlayerPrefs.GetString(PlayerNameKey, string.Empty);
        HandleNameChanged();
    }

    public void HandleNameChanged(){
        connectButton.interactable =
            nameField.text.Length >= minNameLen &&
            nameField.text.Length <= maxNameLen;
    }

    public void Connect(){
        PlayerPrefs.SetString(PlayerNameKey, nameField.text);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
