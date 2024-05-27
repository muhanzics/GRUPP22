using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowPanelAfterButtonAudio : MonoBehaviour
{
    [SerializeField] private AudioSource buttonAudioSource; // Reference to the AudioSource on the button
    [SerializeField] private GameObject panel; // Reference to the panel to be shown

    private Button button;

    void Start()
    {
        // Ensure the panel is initially hidden
        if (panel != null)
        {
            panel.SetActive(false);
        }

        // Get the Button component
        button = GetComponent<Button>();
        if (button != null)
        {
            // Add a listener to the button's onClick event
            button.onClick.AddListener(OnButtonClicked);
        }
    }

    private void OnButtonClicked()
    {
        if (buttonAudioSource != null)
        {
            // Play the audio
            buttonAudioSource.Play();
            // Start the coroutine to wait for the audio to finish
            StartCoroutine(WaitForAudioToEnd());
        }
    }

    private IEnumerator WaitForAudioToEnd()
    {
        // Wait until the audio has finished playing
        while (buttonAudioSource.isPlaying)
        {
            yield return null;
        }

        // Show the panel after the audio has finished playing
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }
}
