using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button playVideoButton;
    public Canvas CanvasMain;
    public Canvas VideoCanvas;
    void Start()
    {
        playVideoButton.onClick.AddListener(PlayVideo);
        videoPlayer.loopPointReached += EndReached;
        VideoCanvas.enabled = false;
        
    }
    public void PlayVideo() {
        CanvasMain.enabled = false;
        VideoCanvas.enabled = true;
        videoPlayer.Play();
        playVideoButton.gameObject.SetActive(false);
    }
    public void EndReached (VideoPlayer vp) {
        CanvasMain.enabled = true;
        VideoCanvas.enabled = false;
        playVideoButton.gameObject.SetActive(true);
    }
    public void OnDestroy() {
        videoPlayer.loopPointReached -= EndReached;
        playVideoButton.onClick.RemoveListener(PlayVideo);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
