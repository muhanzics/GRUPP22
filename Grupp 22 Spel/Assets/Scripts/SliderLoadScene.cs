using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace

public class SliderLoadScene : MonoBehaviour
{
    public Slider slider;        
    public float returnSpeed = 2f; 
    public float fadeDuration = 0.5f; 
    public string sceneToLoad;   

    private float startValue;    
    private bool isDragging;     

    void Start()
    {
        startValue = slider.value;
        slider.onValueChanged.AddListener(OnSliderValueChanged);
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
            StartCoroutine(FadeOutSliderAndLoadScene());
            slider.value = startValue;
        }
    }

    private void OnSliderValueChanged(float value)
    {
    }

    private IEnumerator FadeOutSliderAndLoadScene()
    {
        float elapsedTime = 0f;
        CanvasGroup sliderCanvasGroup = slider.GetComponent<CanvasGroup>();

        if (sliderCanvasGroup == null)
        {
            sliderCanvasGroup = slider.gameObject.AddComponent<CanvasGroup>();
        }
        while (elapsedTime < fadeDuration)
        {
            float alpha = elapsedTime / fadeDuration;
            sliderCanvasGroup.alpha = 1 - alpha;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        sliderCanvasGroup.alpha = 0; 
        slider.gameObject.SetActive(false); 

        SceneManager.LoadScene(sceneToLoad);
    }
}
