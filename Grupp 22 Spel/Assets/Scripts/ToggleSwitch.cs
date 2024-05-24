using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Xml.Serialization;

public class ToggleSwitch : MonoBehaviour, IPointerClickHandler
{
    [Header("Slider setup")]
    [SerializeField, Range(0, 1f)] private float sliderValue;

    public bool CurrentValue { get; private set; }

    private Slider _slider;

    [Header("Animation")]
    [SerializeField, Range(0, 1f)] private float animationDuration = 0.5f;
    [SerializeField]
    private AnimationCurve slideEase =
        AnimationCurve.EaseInOut(timeStart: 0, valueStart: 0, timeEnd: 1, valueEnd: 1);

    private Coroutine _animateSliderCoroutine;

    [Header("Events")]
    [SerializeField] private UnityEvent onToggleOn;
    [SerializeField] private UnityEvent onToggleOff;

    private ToggleSwitchGroupManager _toggleSwitchGroupManager;

    protected void OnValidate()
    {
        SetupToggleComponents();

        _slider.value = sliderValue;
    }

    private void SetupToggleComponents()
    {
        if (_slider != null)
            return;

        SetupSliderComponent();
    }


    private void SetupSliderComponent()
    {
        _slider = GetComponent<Slider>();

        if (_slider == null)
        {
            Debug.Log(message: "No Slider found!", context: this);
            return;
        }

        _slider.interactable = false;
        var sliderColors = _slider.colors;
        sliderColors.disabledColor = Color.white;
        _slider.colors = sliderColors;
        _slider.transition = Selectable.Transition.None;

    }

    public void SetupForManager(ToggleSwitchGroupManager manager)
    {
        _toggleSwitchGroupManager = manager;
    }

    private void Awake()
    {
        SetupToggleComponents();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Toggle();
    }

    private void Toggle()
    {
        if (_toggleSwitchGroupManager != null)
            _toggleSwitchGroupManager.ToggleGroup(toggleSwitch: this);
        else
            SetStateAndStartAnimation(!CurrentValue);
    }

    public void ToggleByGroupManager(bool valueToSetTo)
    {
        SetStateAndStartAnimation(valueToSetTo);
    }

    private void SetStateAndStartAnimation(bool state)
    {
        CurrentValue = state;

        if (CurrentValue)
            onToggleOn?.Invoke();
        else
            onToggleOff?.Invoke();

        if (_animateSliderCoroutine != null)
            StopCoroutine(_animateSliderCoroutine);

        _animateSliderCoroutine = StartCoroutine(routine: AnimateSlider());
    }

    private IEnumerator AnimateSlider()
    {
        float startValue = _slider.value;
        float endValue = CurrentValue ? 1 : 0;

        float time = 0;
        if (animationDuration > 0)
        {
            while (time < animationDuration)
            {
                time += Time.deltaTime;

                float lerpfactor = slideEase.Evaluate(time: time / animationDuration);
                _slider.value = sliderValue = Mathf.Lerp(a: startValue, b: endValue, t: lerpfactor);

                yield return null;

            }
        }

        _slider.value = endValue;
    }

    public class ToggleSwitchGroupManager : MonoBehavior
    {

        public void ToggleGroup(ToggleSwitch toggleSwitch)
        {

        }
    }


}
