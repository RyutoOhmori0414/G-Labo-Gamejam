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
    [Tooltip("���݂̃Q�[���^�[��")]
    GameTrun _gameTrun = GameTrun.StandbyTurn;
    /// <summary>���݂̃^�[�����ς�������ɒʒm����</summary>
    public event Action<GameTrun> NowGameTrun;
    [Tooltip("���Ԃ��͂���")]
    float _countTime;
    [Header("���Ԃ�\������e�L�X�g")]
    [SerializeField] Text _timeText;
    //MAX2min �����Ă�



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
        //�J�E���g��0�ɂȂ�����
        if (_countTime < 0) 
        {
            _gameTrun = GameTrun.GameStart;
            NowGameTrun(_gameTrun);
        }

    }
}
