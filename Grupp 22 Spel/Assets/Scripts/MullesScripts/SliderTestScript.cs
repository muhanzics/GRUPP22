using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlideScript : MonoBehaviour
{
    public Slider slider;        
    public GameObject panel;     
    public CanvasGroup sliderCanvasGroup; 
    public CanvasGroup panelCanvasGroup;  
    public float returnSpeed = 2f; 
    public float fadeDuration = 0.5f; 

    private float startValue;    
    private bool isDragging;     

    void Start()
    {
        startValue = slider.value;
        panel.SetActive(false); 
        panelCanvasGroup.alpha = 0; 
        sliderCanvasGroup.alpha = 1; 
    }

    void Update()
    {
        if (!isDragging && slider.value != startValue)
        {
            slider.value = Mathf.Lerp(slider.value, startValue, Time.deltaTime * returnSpeed);
        }
    }

    public void OnPointerDown()
    {
        isDragging = true;
    }

    public void OnPointerUp()
    {
        isDragging = false;
        if (slider.value >= slider.maxValue)
        {
            StartCoroutine(FadeOutSliderAndFadeInPanel());
            slider.value = startValue; 
        }
    }
    private IEnumerator FadeOutSliderAndFadeInPanel()
    {
        panel.SetActive(true); 

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = elapsedTime / fadeDuration;
            sliderCanvasGroup.alpha = 1 - alpha;
            panelCanvasGroup.alpha = alpha;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        sliderCanvasGroup.alpha = 0; 
        panelCanvasGroup.alpha = 1;  
        slider.gameObject.SetActive(false); 
    }
}
