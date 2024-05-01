using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MenuSettingsController : MonoBehaviour
{
    public Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;
    private bool isOn = true;
    public AudioSource audioSource;

    [SerializeField] private GameObject settingsPanel;

    void Start()
    {
        if (button != null)
            // Tilldela knappens nuvarande sprite till soundOnImage vid start
            soundOnImage = button.image.sprite;
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void ButtonClicked()
    {
        if(isOn)
        {
            button.image.sprite = soundOffImage;
            isOn = false;
            audioSource.mute = true;
        } else
        {
            button.image.sprite = soundOnImage;
            isOn = true;
            audioSource.mute = false;
        }
    }
}
