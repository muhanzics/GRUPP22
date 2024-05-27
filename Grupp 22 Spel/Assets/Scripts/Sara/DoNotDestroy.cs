using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private static DoNotDestroy instance;

    public static DoNotDestroy Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DoNotDestroy>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject("DoNotDestroySingleton");
                    instance = singleton.AddComponent<DoNotDestroy>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return instance;
        }
    }

    private AudioSource audioSource;
    private List<GameObject> activePanels = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        bool anyPanelActive = activePanels.Exists(panel => panel != null && panel.activeSelf);

        if (anyPanelActive)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
        }
        else
        {
            if (!audioSource.isPlaying)
            {
                audioSource.UnPause();
            }
        }
    }

    public void RegisterPanel(GameObject panel)
    {
        if (!activePanels.Contains(panel))
        {
            activePanels.Add(panel);
        }
    }

    public void UnregisterPanel(GameObject panel)
    {
        if (activePanels.Contains(panel))
        {
            activePanels.Remove(panel);
        }
    }
}
