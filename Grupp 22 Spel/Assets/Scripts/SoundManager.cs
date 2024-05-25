using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private List<AudioSource> allAudioSources = new List<AudioSource>();

    void Start()
    {
        // H�mta alla AudioSource-komponenter i scenen
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        allAudioSources.AddRange(audioSources);

        // F�r fels�kning, skriv ut antal AudioSource-komponenter som hittades
        Debug.Log("Found " + audioSources.Length + " audio sources in the scene.");
    }

    public void SetSoundEffectsVolume(float volume)
    {
        Debug.Log("Slider volume: " + volume); // Skriv ut volymv�rdet fr�n sliden
        foreach (AudioSource audioSource in allAudioSources)
        {
            // Kontrollera att ljudeffekter har taggen "SoundEffect"
            if (audioSource.CompareTag("SoundEffect"))
            {
                audioSource.volume = volume;
                Debug.Log("Set volume for " + audioSource.name + " to " + volume); // Skriv ut vilken ljudk�lla som uppdateras
            }
        }
    }
}