using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] int _GoleInstans = 10;
    [SerializeField] float _backGroundSpeed = 0.2f;
    [SerializeField] float _speedMax = 5;
    [SerializeField] float _speed = 5;
    [SerializeField] float _minusSpeed = 3;
    [SerializeField] EnemyGenerator _enemyGenerator;
    [SerializeField] SpriteRenderer[] _nigthStage;
    [SerializeField] SpriteRenderer[] _brakingDownStage;
    [Tooltip("スタート位置")]private Vector2 startPos;
    [Tooltip("背景幅")] float repeatWidth;
    bool _mainusBool = false;
    int _goleCount = 0;

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
            if(_speedMax == _speed) { _mainusBool = false;}
        }
        Timer60();
    }

    public void Speed()
    {
        _speed -= _minusSpeed;
        _mainusBool = true;
    }

    public void Timer60()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
            _goleCount++;
            //if(_goleCount == _GoleInstans) { _enemyGenerator.GoleGeneration()}
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
        }
        transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
    }
}
