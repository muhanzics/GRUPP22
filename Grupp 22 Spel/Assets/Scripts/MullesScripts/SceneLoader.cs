using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float delay = 0f;
    private string sceneToLoad;
    public void LoadScene(string sceneName)
    {
        sceneToLoad = sceneName;
        Invoke("LoadWithDelay", delay);
        
    }//loadscene
    private void LoadWithDelay() {
        SceneManager.LoadScene(sceneToLoad);
    }//loadwithdelay
    
}//sceneloader