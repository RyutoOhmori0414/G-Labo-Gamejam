using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] float _speedMax = 5;
    [SerializeField] float _speed = 5;
    [SerializeField] float _minusSpeed = 3;
    [Tooltip("スタート位置")]private Vector2 startPos;
    [Tooltip("背景幅")] float repeatWidth;
    bool _mainusBool = false;
    
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
        transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
        if (_mainusBool) 
        { 
            _speed += Time.deltaTime;
            if(_speedMax == _speed) { _mainusBool = false;}
        }
    }

    public void Speed()
    {
        _speed -= _minusSpeed;
        _mainusBool = true;
    }
}
