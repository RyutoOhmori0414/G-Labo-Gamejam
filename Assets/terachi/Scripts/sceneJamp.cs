using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneJamp : MonoBehaviour
{
    
     public void OnClick()
    {
        Invoke("GoPlay", 0.9f);
    }

    void GoPlay()
    {
        Debug.Log("押された");
        //SceneManager.LoadScene("");
    }

    public void QuitGame()
    {

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void GoStart()
    {
        Debug.Log("コンティニューボタンが押された");
        //SceneManager.LoadScene("");
    }

}
