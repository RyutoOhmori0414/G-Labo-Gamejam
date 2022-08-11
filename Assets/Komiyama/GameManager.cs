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
        GameOver,
    }

    [SerializeField]
    float timer = 120;
    [SerializeField]
    GameObject result = null;
    [SerializeField] float _fastTime = 60, _secondTime = 30;
    [Header("Gameを始めるまでの時間")]
    [SerializeField] float _startWaitTime = 0;
    [SerializeField] GameObject _player1Win;
    [SerializeField] GameObject _player2Win;
    [SerializeField] GameObject _conte;
    [Tooltip("現在のゲームターン")]
    GameTrun _gameTrun = GameTrun.StandbyTurn;

    public GameTrun NowTrun => _gameTrun;
    /// <summary>現在のターンが変わった時に通知する</summary>
    public event Action<GameTrun> NowGameTrun;
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
        if (timer < _fastTime)
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
            _gameTrun = GameTrun.GameOver;
            SoundManager.Instance.Play(0, 3);
        }

        _countTime += Time.deltaTime;

        //カウントが0になった時
        if (_countTime > _startWaitTime && _gameTrun == GameTrun.StandbyTurn)
        {
            _gameTrun = GameTrun.GameStart;
            Debug.Log("GameManager呼ばれた");
            NowGameTrun(_gameTrun);
            _timeText.gameObject.SetActive(false);
        }
        else if (_gameTrun == GameTrun.StandbyTurn)
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

    public void Result(string str)
    {
        if (str == "1")
        {
            SoundManager.Instance.Play(1, 0);
            SoundManager.Instance.Play(1, 5);
            _player1Win.SetActive(true);
            _conte.SetActive(true);
            _gameTrun = GameManager.GameTrun.Result;
        }
        else if (str == "2")
        {
            SoundManager.Instance.Play(1, 0);
            SoundManager.Instance.Play(1, 5);

            _player2Win.SetActive(true);
            _conte.SetActive(true);
            _gameTrun = GameManager.GameTrun.Result;
        }
    }
}
