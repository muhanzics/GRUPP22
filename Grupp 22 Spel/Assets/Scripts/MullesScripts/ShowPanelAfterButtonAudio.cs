using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowPanelAfterButtonAudio : MonoBehaviour
{
     public AudioSource buttonAudioSource; 
     public GameObject panel; 

    public Button button;

    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }//if

        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClicked);
        }//if
    }//start

    public void OnButtonClicked()
    {
        if (buttonAudioSource != null)
        {
            buttonAudioSource.Play();
            StartCoroutine(WaitForAudioToEnd());
        }//if
    }//onbuttonclicked

    public IEnumerator WaitForAudioToEnd()
    {
        while (buttonAudioSource.isPlaying)
        {
            yield return null;
        }//while
        if (panel != null)
        {
            panel.SetActive(true);
        }//if
    }//waitforaudiotoend
}//showpanelafterbuttonaudio
