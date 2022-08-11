using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//メモ
//シングルトンはグローバルなアクセスポイントを提供するもの
//インスペクターで値をいじらなくていいものでシングルトンを作る場合はMonoBehaviorを継承しなくてもいい
//Monobehaviourを継承する必要がないならstatucクラスでもシングルトンとあまり変わらない
//->それによるメリット:SingletonBehaviorクラスとの結合が回避できてnullになることがなくエラーが起こっても対処しやすい
//->デメリット:変数の値を手動で初期化しなければならない。Textureなどのリソースへの参照を持つ場合Nullを入れないと解放されない

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;

    //カプセル化
    // public static T Instance => _instance;

    //チーム制作の時はこう書いたほうがいい
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Type t = typeof(T);
                _instance = (T)FindObjectOfType(t);

                if (_instance == null)
                {
                    Debug.LogError($"{t}をアタッチしているGameObjectがありません");
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        OnAwake();
        ChackIns();
    }


    //継承先でAwakeが必要な場合はこれを呼ぶ
    protected virtual void OnAwake() { }

    protected void ChackIns()
    {
        if (_instance == null)
        {
            //キャストの意味を理解する。T型にキャストしている
            _instance = this as T;
        }
        else if (Instance == this)
        {
            return;
        }
        else if (Instance != this)
        {
            //すでにあった時は何もせずに消える
            Destroy(this);
        }
    }

}
