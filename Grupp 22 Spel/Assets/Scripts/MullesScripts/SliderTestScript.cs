using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlideScript : MonoBehaviour
{
    public Slider slider;        // Reference to the Slider
    public GameObject panel;     // Reference to the Panel
    public CanvasGroup sliderCanvasGroup; // CanvasGroup for the Slider to control its visibility
    public CanvasGroup panelCanvasGroup;  // CanvasGroup for the Panel to control its visibility
    public float returnSpeed = 2f; // Speed at which the slider returns to start
    public float fadeDuration = 0.5f; // Duration of the fade effect

    private float startValue;    // Initial value of the Slider
    private bool isDragging;     // To check if the slider is being dragged

    void Start()
    {
        startValue = slider.value;
        panel.SetActive(false); // Ensure the panel is initially hidden
        panelCanvasGroup.alpha = 0; // Set initial alpha to 0
        sliderCanvasGroup.alpha = 1; // Set initial alpha to 1
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
            StartCoroutine(FadeOutSliderAndFadeInPanel());
            slider.value = startValue; // Reset the slider to the start value
        }
    }

    private void OnSliderValueChanged(float value)
    {
        // Additional logic can be placed here if needed when the slider value changes
    }

    private IEnumerator FadeOutSliderAndFadeInPanel()
    {
        panel.SetActive(true); // Ensure the panel is active before fading in

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = elapsedTime / fadeDuration;
            sliderCanvasGroup.alpha = 1 - alpha;
            panelCanvasGroup.alpha = alpha;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        sliderCanvasGroup.alpha = 0; // Ensure the slider is fully transparent
        panelCanvasGroup.alpha = 1;  // Ensure the panel is fully opaque
        slider.gameObject.SetActive(false); // Optionally deactivate the slider after fading out
    }
}
