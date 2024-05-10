using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class NewBehaviourScript : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        // S�tt upp referensen till VideoPlayer-komponenten
        videoPlayer = GetComponent<VideoPlayer>();

        // Stoppa videouppspelningen n�r scenen startar
        videoPlayer.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // �ndra till �nskad knapp
        {
            // Spela upp videon n�r knappen trycks ned
            PlayVideo();
        }

    }

    public void PlayVideo()
    {
        // Starta uppspelning av videon
        videoPlayer.Play();
    }
}
