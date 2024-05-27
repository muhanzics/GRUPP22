using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] string sceneToLoad = "GameOverScene";
    [SerializeField] GameObject pausePanel1; // Reference to the first panel
    [SerializeField] GameObject pausePanel2; // Reference to the second panel
    [SerializeField] Button pauseButton; // Reference to the button that can also pause the timer

    private bool isTimerPaused;

    void Start()
    {
        // Add listener for the button click event
        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(OnPauseButtonClicked);
        }
    }

    void Update()
    {
        // Check if either pause panel is active or the timer is manually paused
        if (isTimerPaused || (pausePanel1 != null && pausePanel1.activeSelf) || 
            (pausePanel2 != null && pausePanel2.activeSelf))
        {
            return; // If either panel is active or the timer is paused, do nothing (pause the timer)
        }

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            if (remainingTime < 0)
            {
                remainingTime = 0;
                timerText.color = Color.red;
                SceneManager.LoadScene(sceneToLoad);
            }
        }

        if (remainingTime > 0)
        {
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void OnPauseButtonClicked()
    {
        // Pause the timer when the button is clicked
        isTimerPaused = true;
    }
}
