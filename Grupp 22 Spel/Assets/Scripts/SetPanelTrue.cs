using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPanelTrue : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        panel.SetActive(false);
    }
    public void TogglePanel() {
        panel.SetActive(!panel.activeSelf);
    }
    public void TogglePanelOff() {
        panel.SetActive(panel.activeSelf);
    }
}