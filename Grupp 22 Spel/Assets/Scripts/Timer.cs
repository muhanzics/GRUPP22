using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] string sceneToLoad = "GameOverScene";
    [SerializeField] GameObject pausePanel; 

    void Update()
    {
        if (pausePanel != null && pausePanel.activeSelf)
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
}
