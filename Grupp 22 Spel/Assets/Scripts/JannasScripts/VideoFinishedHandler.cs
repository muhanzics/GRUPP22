using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoFinishedHandler : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float fadeOutDuration = 10.0f; // Adjust fade-out duration if needed
    private bool isFadingOut = false;
    public Image blackOverlay;
    public GameObject fadeTrigger1;
    public GameObject fadeTrigger2;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished;

        // Add listeners for the fade triggers
        if (fadeTrigger1 != null)
        {
            fadeTrigger1.GetComponent<Button>().onClick.AddListener(OnFadeTriggerClicked);
        }

        if (fadeTrigger2 != null)
        {
            fadeTrigger2.GetComponent<Button>().onClick.AddListener(OnFadeTriggerClicked);
        }
    }

    public void OnVideoFinished(VideoPlayer vp)
    {
        if (!isFadingOut)
        {
            StartCoroutine(FadeOutAndLoadNextScene());
        }
    }

    public void OnFadeTriggerClicked()
    {
        if (!isFadingOut)
        {
            StartCoroutine(FadeOutAndLoadNextScene());
        }
    }

    IEnumerator FadeOutAndLoadNextScene()
    {
        isFadingOut = true; // Ensure the fade-out process doesn't start multiple times

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
    }
}
