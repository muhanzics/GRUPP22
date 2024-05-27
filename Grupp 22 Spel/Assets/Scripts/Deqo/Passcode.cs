using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Passcode : MonoBehaviour
{
    string Code = "4758"; 
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
            SceneManager.LoadScene("12.Finnish");
        }
        else
        {
            attemptCount++;
            Debug.Log("Incorrect code entered. Attempt: " + attemptCount);
            if (audioData != null)
            {
                audioData.Play();
            }
            UpdateAttemptsText();

            if (attemptCount >= maxAttempts)
            {
                Debug.Log("Maximum attempts reached.");
                SceneManager.LoadScene("8Caught");
            }
        }
        Nr = null;
        UiText.text = Nr;
    }

    public void Delete()
    {
        NrIndex = 0; 
        Nr = null; 
        UiText.text = Nr; 
    }

    void UpdateAttemptsText()
    {
        if (AttemptsText != null)
        {
            AttemptsText.text = "Attempts: " + attemptCount + "/" + maxAttempts;
            if (attemptCount == maxAttempts - 1)
            {
                AttemptsText.color = Color.red;
            }
            else
            {
                AttemptsText.color = Color.white;
            }
        }
    }
}
