using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSettingsController : MonoBehaviour
{

    [SerializeField] private GameObject settingsPanel;
    
   public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}
