using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI; 

public class MenuSettingsController : MonoBehaviour
{
    public Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;
    private bool isOn = true;
    public AudioSource audioSource;
    public Slider volumeSlider;

    [SerializeField] private GameObject settingsPanel;

    void Start()
    {

        button = GetComponent<Button>();

        if (button != null)
        { 
            // Tilldela knappens nuvarande sprite till soundOnImage vid start
            soundOnImage = button.image.sprite;
    }

     if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
    }
        else
    {
            Load();
    }

        if (volumeSlider != null)
    {
        volumeSlider.onValueChanged.AddListener(delegate { changeVolume(); });
        volumeSlider.value = AudioListener.volume; // Initialize slider with current volume
    }
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

        if (audioSource == null)
        {
            return;
        }


        if (isOn)
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

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    }


