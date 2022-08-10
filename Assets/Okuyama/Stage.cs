using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] float _speedMax = 5;
    [SerializeField] float _speed = 5;
    [SerializeField] float _minusSpeed = 3;
    [SerializeField] SpriteRenderer[] _nigthStage;
    [SerializeField] SpriteRenderer[] _brakingDownStage;
    [Tooltip("�X�^�[�g�ʒu")]private Vector2 startPos;
    [Tooltip("�w�i��")] float repeatWidth;
    bool _mainusBool = false;
    //SpriteRenderer _spriteRenderer;
    
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
        }
        transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
    }
    public void Timer30()
    {
        foreach (SpriteRenderer childTransform in _nigthStage)
        {
            float color_a = 0;
            color_a -= Time.deltaTime;
            childTransform.color += new Color(0, 0, 0, color_a);
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
            color_a -= Time.deltaTime;
            childTransform.color += new Color(0, 0, 0, color_a);
        }
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
        transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
    }
}
