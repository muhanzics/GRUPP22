using UnityEngine;

public class SetPanelTrue : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        panel.SetActive(false);
    } //start
    public void TogglePanel() {
        panel.SetActive(!panel.activeSelf);
    } //togglepanel
    public void TogglePanelOff() {
        panel.SetActive(panel.activeSelf);
    }//togglepaneloff
}//setpaneltrue