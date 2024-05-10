using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class MainRoomSettingsController : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;

    private VideoPlayer videoPlayer;
    public Button playpausebutton;
    public Sprite playButton;
    public Sprite pauseButton;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {

        if(videoPlayer == null)
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
        if (playpausebutton != null)
            // Tilldela knappens nuvarande sprite till soundOnImage vid start
            //pauseButton = playpausebutton.image.sprite;

        playpausebutton.onClick.AddListener(changePlayPause);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void showSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void closeSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }

    public void changePlayPause()
    {
        if (videoPlayer != null)
        {
            if (isPaused)
            {
                videoPlayer.Play();
                playpausebutton.image.sprite = playButton;
                isPaused = false;
            }
            else
            {
                videoPlayer.Pause();
                playpausebutton.image.sprite = pauseButton;
                isPaused = true;
            }

        }
    }
}

