using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject secondaryCanvas;

    void Start()
    {
        mainCanvas.SetActive(true);
        secondaryCanvas.SetActive(false);
    }

    public void OpenSecondaryCanvas()
    {
        mainCanvas.SetActive(false);
        secondaryCanvas.SetActive(true);
    }

    public void CloseSecondaryCanvas()
    {
        secondaryCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
