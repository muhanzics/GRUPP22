using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoomSettingsController : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    } 

    public void showSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void closeSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
   
}
