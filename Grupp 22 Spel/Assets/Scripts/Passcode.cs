using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Passcode : MonoBehaviour
{
    string Code = "123";
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public Text UiText = null;
    public AudioSource audioData;


    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;
    }

    public void Enter()
    {
        if (Nr == Code)
        {
            Debug.Log("It's working");
            /*debug log �r en placeholder just nu. n�r vi best�mt vad f�r scen d�rren ska till s� ska den
            bort och ist�llet st� "SceneManager.LoadScene() */
        }
        else
        {
            Debug.Log("It's not working");
            //audioData.Play();
        }

    }
    public void Delete()
    {
        NrIndex++;
        Nr = null;
        UiText.text = Nr;
    }
}

