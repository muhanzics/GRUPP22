using UnityEngine;
using UnityEngine.UI;

public class HideOnClick : MonoBehaviour
{
    public Button hideButton; 
    public Button showButton; 

    void Start()
    {
        if (hideButton != null)
        {
            hideButton.onClick.AddListener(HideGameObject);
        }//if

        if (showButton != null)
        {
            showButton.onClick.AddListener(ShowGameObject);
        }//if
    }//start

    void HideGameObject()
    {
        gameObject.SetActive(false);
    }//hidegameobject

    void ShowGameObject()
    {
        gameObject.SetActive(true);
    }//showgameobject
}//hideonclick
