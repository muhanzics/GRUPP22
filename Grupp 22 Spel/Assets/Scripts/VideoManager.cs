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
    private static bool hasPlayedOnce = false; 
    private double lastFrameTime; 
    void Start()
    {
        playVideoButton.onClick.AddListener(PlayVideo);
        videoPlayer.loopPointReached += EndReached;
        VideoCanvas.enabled = false;

        if (hasPlayedOnce)
        {
            lastFrameTime = PlayerPrefs.GetFloat("LastFrameTime", 0);
            videoPlayer.time = lastFrameTime;
            videoPlayer.Pause();
        }
    }

    public void PlayVideo()
    {
        if (!hasPlayedOnce)
        {
            CanvasMain.enabled = false;
            VideoCanvas.enabled = true;
            videoPlayer.Play();
            playVideoButton.gameObject.SetActive(false);
        }
        else
        {
            CanvasMain.enabled = false;
            VideoCanvas.enabled = true;
            videoPlayer.time = lastFrameTime;
            videoPlayer.Pause();
        }
    }

    public void EndReached(VideoPlayer vp)
    {
        lastFrameTime = videoPlayer.frameCount / videoPlayer.frameRate;
        videoPlayer.time = lastFrameTime;
        videoPlayer.Pause();
        hasPlayedOnce = true;

        PlayerPrefs.SetInt("VideoPlayedOnce", 1);
        PlayerPrefs.SetFloat("LastFrameTime", (float)lastFrameTime);
        PlayerPrefs.Save();
    }

    public void OnDestroy()
    {
        videoPlayer.loopPointReached -= EndReached;
        playVideoButton.onClick.RemoveListener(PlayVideo);
    }
}
