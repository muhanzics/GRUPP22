using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DelayedVideoPlayer : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float delay = 2f;
    void Start()
    {
        videoPlayer.playbackSpeed = 0f;
        Invoke("PlayVideo", delay);
    }

    // Update is called once per frame
    void Update()
    {
        videoPlayer.playbackSpeed = 1f;
    }
}
