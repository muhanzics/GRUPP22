using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Passcode : MonoBehaviour
{
    string Code = "4753"; 
    string Nr = null; 
    int NrIndex = 0; 
    public Text UiText = null; 
    public Text AttemptsText = null; 
    public AudioSource audioData; 
    int attemptCount = 0; 
    public int maxAttempts = 3; 

    void Start()
    {
        UpdateAttemptsText();
    }

    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;
    }

    public void Enter()
    {
        if (Nr == Code)
        {
            Debug.Log("Correct code entered.");
            SceneManager.LoadScene("WIP");
        }
        else
        {
            attemptCount++;
            Debug.Log("Incorrect code entered. Attempt: " + attemptCount);
            // Play error audio if provided
            if (audioData != null)
            {
                audioData.Play();
            }

            // Update the attempts display
            UpdateAttemptsText();

            if (attemptCount >= maxAttempts)
            {
                Debug.Log("Maximum attempts reached.");
                // Load the scene for too many incorrect attempts
                SceneManager.LoadScene("8Caught");
            }
        }
        // Reset the entered code for the next attempt
        Nr = null;
        UiText.text = Nr;
    }

    public void Delete()
    {
        NrIndex = 0; // Reset the index since we're clearing the input
        Nr = null; // Clear the entered passcode
        UiText.text = Nr; // Update the UI text to reflect the cleared input
    }

    void UpdateAttemptsText()
    {
        // Update the attempts text UI
        if (AttemptsText != null)
        {
            AttemptsText.text = "Attempts: " + attemptCount + "/" + maxAttempts;
            // Change text color to red if on the last attempt
            if (attemptCount == maxAttempts - 1)
            {
                AttemptsText.color = Color.red;
            }
            else
            {
                AttemptsText.color = Color.black;
            }
        }
    }
}
