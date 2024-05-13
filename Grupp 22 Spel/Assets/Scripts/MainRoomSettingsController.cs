using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Sprites;
using UnityEngine.UI;
using Unity.VisualScripting;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanels;

    private VideoPlayer videoPlayer;
    public Button playpausebutton;
    public Sprite playButton;
    public Sprite pauseButton;
    private bool isPaused = false;
    void Start()
    {
        if(videoPlayer == null) {
            videoPlayer = gameObject.GetComponent<VideoPlayer>();
        } 
        if (playpausebutton != null) {
            playpausebutton.onClick.AddListener(ChangePlayPause);
        }
    }

    public void ShowSettingsPanel()
    {
        settingsPanels.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        settingsPanels.SetActive(false);
    }

    public void ChangePlayPause()
    {
        if (videoPlayer != null)
        {
            if (isPaused)
            {
                videoPlayer.Play();
                playpausebutton.image.sprite = pauseButton;
                isPaused = false;
            }
            else
            {
                videoPlayer.Pause();
                playpausebutton.image.sprite = playButton;
                isPaused = true;
            }

        }
    }

    public void PlayVideoSpeed()
    {
        if (videoPlayer)
        {
            if (videoPlayer.playbackSpeed == 1.0f)
            {
                videoPlayer.playbackSpeed = 4.0f;
            }
            else
            {
                videoPlayer.playbackSpeed = 1.0f;
            }
        }
    }

    public void FastForward()
    {
        videoPlayer.time += 5f; // Adjust the value as needed for fast forward speed
    }

    public void Rewind()
    {
        videoPlayer.time -= 5f; // Adjust the value as needed for rewind speed
    }

}