using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [Header("ゴールを生成するタイミング")]
    [SerializeField, Tooltip("ゴールを生成するタイミング")]  int _goleTiming = 10;

    [Header("マックススピード")]
    [SerializeField, Tooltip("マックススピード")] float _speedMax = 5;

    [Header("減らすスピード")]
    [SerializeField, Tooltip("減らすスピード")] float _minusSpeed = 3;

    [Header("EnemyGenerator")]
    [SerializeField, Tooltip("EnemyGenerator")] EnemyGenerator _enemyGenerator;

    [Header("夜のスプライト")]
    [SerializeField, Tooltip("夜のスプライト")] SpriteRenderer[] _nigthStage;

    [Header("明け方のスプライト")]
    [SerializeField, Tooltip("明け方のスプライト")] SpriteRenderer[] _brakingDownStage;
    
    [Tooltip("現在のスピード")]float _speed = 5;
    [Tooltip("背景の透明にする速さ")] float _backGroundSpeed = 0.2f;
    [Tooltip("スタート位置")]private Vector2 startPos;
    [Tooltip("背景幅")] float repeatWidth;
    [Tooltip("引き算をした時のBool")] bool _mainusBool = false;
    [Tooltip("ステージが代わった回数")] int _stageCount = 0;

    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    void Update()
    {
        if (_mainusBool) 
        { 
            _speed += Time.deltaTime;
            if(_speedMax <= _speed) 
            { 
                _mainusBool = false;
                _speed = _speedMax;
            }
        }
        Timer60();
    }

    public void Speed()
    {
        if (_speed <= 0) { return; }
        _speed -= _minusSpeed;
        _mainusBool = true;
    }

    public void Timer60()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
            _stageCount++;
            if(_stageCount == _goleTiming) { _enemyGenerator.GoalGeneration(); }
        }
        transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
    }
    public void Timer30()
    {
        foreach (SpriteRenderer childTransform in _nigthStage)
        {
            float color_a = 0;
            color_a -= _backGroundSpeed * Time.deltaTime;
            childTransform.color += new Color(0, 0, 0, color_a);
            if(color_a < -120) { childTransform.gameObject.SetActive(false); }
        }
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
            _stageCount++;
            if (_stageCount == _goleTiming) { _enemyGenerator.GoalGeneration(); }
        }
        transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
    }
    public void Timer0()
    {
        foreach (SpriteRenderer childTransform in _brakingDownStage)
        {
            float color_a = 0;
            color_a -= _backGroundSpeed * Time.deltaTime;
            childTransform.color += new Color(0, 0, 0, color_a);
            if (color_a < -120) { childTransform.gameObject.SetActive(false); }
        }
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
            _stageCount++;
            if (_stageCount == _goleTiming) { _enemyGenerator.GoalGeneration(); }
        }
        transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
    }
}
