using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : SingletonBehaviour<SceneLoadManager>
{
    /// <summary>
    ///ボタンイベントなどから呼ぶ用の関数
    /// </summary>
    /// <param name="SceneName">シーンの名前</param>
    public void LoadScene(string SceneName) 
    {
        Debug.Log($"{SceneName}がLoadされました");
        SceneManager.LoadScene(SceneName);
    }
}
