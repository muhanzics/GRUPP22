using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float delay = 2f;
    private string sceneToLoad;
    public void LoadScene(string sceneName)
    {
        sceneToLoad = sceneName;
        Invoke("LoadWithDelay", delay);
        
    }
    private void LoadWithDelay() {
        SceneManager.LoadScene(sceneToLoad);
    }
    
}