using UnityEngine;
using UnityEngine.UI;

public class HideOnClickAndShowOnOtherClick : MonoBehaviour
{
    public Button hideButton; // Button that will hide this GameObject
    public Button showButton; // Button that will show this GameObject

    void Start()
    {
        // Ensure the hideButton is assigned and has a Button component
        if (hideButton != null)
        {
            hideButton.onClick.AddListener(HideGameObject);
        }

        // Ensure the showButton is assigned and has a Button component
        if (showButton != null)
        {
            showButton.onClick.AddListener(ShowGameObject);
        }
    }

    void HideGameObject()
    {
        // Hide the GameObject by setting it to inactive
        gameObject.SetActive(false);
    }

    void ShowGameObject()
    {
        // Show the GameObject by setting it to active
        gameObject.SetActive(true);
    }
}
