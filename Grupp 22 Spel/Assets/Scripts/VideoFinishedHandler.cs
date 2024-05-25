using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
public class VideoFinishedHandler : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public float fadeOutDuration = 10.0f; // Justera fade out-duration vid behov
    private bool isFadingOut = false;
    private bool hasVideoFinished = false;
    public Image blackOverlay;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    public void OnVideoFinished(VideoPlayer vp)
    {
            if (!isFadingOut)
            {
                hasVideoFinished = true;
                StartCoroutine(FadeOutAndLoadNextScene());
            }
        }

    IEnumerator FadeOutAndLoadNextScene()
    {
        float timer = 0f;
        Color color = blackOverlay.color;

        while (timer < fadeOutDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / fadeOutDuration);
            blackOverlay.color = color;
            yield return null;
        }

        videoPlayer.Stop();
        yield return new WaitForSeconds(fadeOutDuration);

        LoadNextScene();
    }

    void LoadNextScene()
    {
        // Ladda n�sta scen
        SceneManager.LoadScene("2IntroductionToBeingKidnapped");
    }
}

