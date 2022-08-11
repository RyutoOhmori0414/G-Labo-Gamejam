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
    [SerializeField] float _fastTime = 60,_secondTime = 30;
    [Header("Gameを始めるまでの時間")]
    [SerializeField]float _startWaitTime = 0;
    [Tooltip("現在のゲームターン")]
    GameTrun _gameTrun = GameTrun.StandbyTurn;

    public GameTrun NowTrun => _gameTrun;
    /// <summary>現在のターンが変わった時に通知する</summary>
    public static event Action<GameTrun> NowGameTrun;
    [Tooltip("時間をはかる")]
    float _countTime;
    [Header("時間を表示するテキスト")]
    [SerializeField] Text _timeText;
    [SerializeField] Stage[] _stage;
    //MAX2min 減ってく



    void Start()
    {
        timer += _startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < _fastTime)
        {
            _stage[0].Timer30();
            _stage[1].Timer30();
            if (timer < _secondTime)
            {
                _stage[0].Timer0();
                _stage[1].Timer0();
            }
        }
        if (timer < 0)
        {
            result.SetActive(true);
        }

        _countTime += Time.deltaTime;

        //カウントが0になった時
        if (_countTime > _startWaitTime && _gameTrun == GameTrun.StandbyTurn)
        {
            _gameTrun = GameTrun.GameStart;
            Debug.Log("呼ばれた");
            NowGameTrun(_gameTrun);
            _timeText.gameObject.SetActive(false);
        }
        else if(_gameTrun == GameTrun.StandbyTurn)
        {
            _timeText.text = _countTime.ToString("F0");
        }

    }

    /// <summary>
    /// ゲームの状態をリザルトに変える
    /// </summary>
    public void ChengeType(GameTrun trun) 
    {
        _gameTrun = trun;
    }
}
