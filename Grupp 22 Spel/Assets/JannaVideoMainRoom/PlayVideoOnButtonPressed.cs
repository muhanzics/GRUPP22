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
        // Sätt upp referensen till VideoPlayer-komponenten
        videoPlayer = GetComponent<VideoPlayer>();

        // Stoppa videouppspelningen när scenen startar
        videoPlayer.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Ändra till önskad knapp
        {
            // Spela upp videon när knappen trycks ned
            PlayVideo();
        }

    }

    public void PlayVideo()
    {
        // Starta uppspelning av videon
        videoPlayer.Play();
    }
}
