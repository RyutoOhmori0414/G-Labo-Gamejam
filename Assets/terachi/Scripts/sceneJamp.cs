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
        Debug.Log("‰Ÿ‚³‚ê‚½");
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

}
