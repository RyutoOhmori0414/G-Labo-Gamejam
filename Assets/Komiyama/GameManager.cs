using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public enum GameTrun 
    {
        StandbyTurn,
        GameStart,
        Result,
    }

    [SerializeField]
    float timer = 120;
    [SerializeField]
    GameObject result = null;
    [Tooltip("現在のゲームターン")]
    GameTrun _gameTrun = GameTrun.StandbyTurn;
    /// <summary>現在のターンが変わった時に通知する</summary>
    public event Action<GameTrun> NowGameTrun;
    [Tooltip("時間をはかる")]
    float _countTime;
    [Header("時間を表示するテキスト")]
    [SerializeField] Text _timeText;
    //MAX2min 減ってく



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            result.SetActive(true);
        }

        _countTime += Time.deltaTime;
        _timeText.text = _countTime.ToString("F0");
        //カウントが0になった時
        if (_countTime < 0) 
        {
            _gameTrun = GameTrun.GameStart;
            NowGameTrun(_gameTrun);
        }

    }
}
