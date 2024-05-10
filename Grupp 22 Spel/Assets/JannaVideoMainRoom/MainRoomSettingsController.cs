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
    public Button button;
    public Sprite playButton;
    public Sprite pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
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
            if (videoPlayer.isPlaying == true)
            {
                videoPlayer.Play();
                button.image.sprite = playButton;
            }
            else
            {
                videoPlayer.Pause();
                button.image.sprite = pauseButton;
            }

        }
    }
}
        
  
    
   

