using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private Dictionary<AudioSource, float> originalVolumes = new Dictionary<AudioSource, float>();
    private bool isSoundOn = true;

    void Start()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.CompareTag("SoundEffect"))
            {
                originalVolumes[audioSource] = audioSource.volume;
                Debug.Log("Saved volume for " + audioSource.name + ": " + audioSource.volume);
            }
            else
            {
                Debug.Log("AudioSource " + audioSource.name + " does not have the tag 'SoundEffect'.");
            }
        }

        Debug.Log("Found " + audioSources.Length + " audio sources in the scene.");

        SetSoundState(isSoundOn);
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        Debug.Log("Toggled sound. Sound is now " + (isSoundOn ? "On" : "Off"));
        SetSoundState(isSoundOn);
    }

    public void SetSoundState(bool soundOn)
    {
        Debug.Log("SetSoundState called with soundOn: " + soundOn);
        foreach (var entry in originalVolumes)
        {
            AudioSource audioSource = entry.Key;
            if (audioSource != null)
            {
                audioSource.volume = soundOn ? entry.Value : 0f;
                Debug.Log("Set volume for " + audioSource.name + " to " + audioSource.volume + " (soundOn: " + soundOn + ")");
            }
            else
            {
                Debug.LogWarning("AudioSource is null for an entry in originalVolumes.");
            }
        }
    }
}