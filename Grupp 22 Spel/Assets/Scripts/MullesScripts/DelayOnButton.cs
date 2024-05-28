using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DelayedButtonActivation : MonoBehaviour
{
    public Button button;
    public float delayTime = 10f; 
    public float fadeInDuration = 1f;

    void Start()
    {
        button.gameObject.SetActive(false);
        Invoke("ActivateButton", delayTime);
    } // start

    void ActivateButton()
    {
        if(button != null){
            button.gameObject.SetActive(true);

            StartCoroutine(FadeInCoroutine(button.image));
        }//while
    } //activate button
    IEnumerator FadeInCoroutine(Image image) {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        float increment = Time.deltaTime/fadeInDuration;
        while(image.color.a < 1f) {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + increment);
            yield return null;
        }//while
    } //fadeincoroutine

}//delayedbuttonactivation
