using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneJamp : MonoBehaviour
{
    

     public void OnClick()
    {
        Invoke("GoPlay", 0.9f);
        //SoundManager.Instance.Play(1, 4);
    }

    void GoPlay()
    {
        Debug.Log("押された");
        //SoundManager.Instance.Play(1, 4);
        //SceneManager.LoadScene("");
    }

    public void QuitGame()
    {
        //SoundManager.Instance.Play(1, 4);
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void GoStart()
    {
        //SoundManager.Instance.Play(1, 4);
        Debug.Log("コンティニューボタンが押された");
        SceneManager.LoadScene("Title");
    }

}
