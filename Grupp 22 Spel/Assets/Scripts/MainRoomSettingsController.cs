using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanels;

    public void ShowSettingsPanel()
    {
        settingsPanels.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        settingsPanels.SetActive(false);
    }
   
}
