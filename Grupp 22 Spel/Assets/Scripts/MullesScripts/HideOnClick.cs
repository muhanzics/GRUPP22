using UnityEngine;
using UnityEngine.UI;

public class HideOnClickAndShowOnOtherClick : MonoBehaviour
{
    public Button hideButton; 
    public Button showButton; 

    void Start()
    {
        if (hideButton != null)
        {
            hideButton.onClick.AddListener(HideGameObject);
        }

        if (showButton != null)
        {
            showButton.onClick.AddListener(ShowGameObject);
        }
    }

    void HideGameObject()
    {
        gameObject.SetActive(false);
    }

    void ShowGameObject()
    {
        gameObject.SetActive(true);
    }
}
