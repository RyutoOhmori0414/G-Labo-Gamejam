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
    [Header("Game���n�߂�܂ł̎���")]
    [SerializeField]float _startWaitTime = 0;
    [Tooltip("���݂̃Q�[���^�[��")]
    GameTrun _gameTrun = GameTrun.StandbyTurn;
    /// <summary>���݂̃^�[�����ς�������ɒʒm����</summary>
    public static event Action<GameTrun> NowGameTrun;
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

        //�J�E���g��0�ɂȂ�����
        if (_countTime > _startWaitTime && _gameTrun == GameTrun.StandbyTurn)
        {
            _gameTrun = GameTrun.GameStart;
            Debug.Log("�Ă΂ꂽ");
            NowGameTrun(_gameTrun);
        }
        else if(_gameTrun == GameTrun.StandbyTurn)
        {
            _timeText.text = _countTime.ToString("F0");
        }

    }
}
