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
    [SerializeField] GameObject pausePanel1; 
    [SerializeField] GameObject pausePanel2; 
    [SerializeField] Button pauseButton; 

    private bool isTimerPaused;

    void Start()
    {
        
        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(OnPauseButtonClicked);
        }
    }

    void Update()
    {
        
        if (isTimerPaused || (pausePanel1 != null && pausePanel1.activeSelf) || 
            (pausePanel2 != null && pausePanel2.activeSelf))
        {
            return; 
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
        
        isTimerPaused = true;
    }
}
