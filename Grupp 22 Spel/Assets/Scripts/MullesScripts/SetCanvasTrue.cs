using UnityEngine;

public class SetCanvasManager : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject secondaryCanvas;

    void Start()
    {
        mainCanvas.SetActive(true);
        secondaryCanvas.SetActive(false);
    }//start

    public void OpenSecondaryCanvas()
    {
        mainCanvas.SetActive(false);
        secondaryCanvas.SetActive(true);
    }//openseondarycanvas

    public void CloseSecondaryCanvas()
    {
        secondaryCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }//closesecondarycanvas
}//canvasmanager
