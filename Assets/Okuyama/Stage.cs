using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [Header("�S�[���𐶐�����^�C�~���O")]
    [SerializeField, Tooltip("�S�[���𐶐�����^�C�~���O")]  int _goleTiming = 10;

    [Header("�}�b�N�X�X�s�[�h")]
    [SerializeField, Tooltip("�}�b�N�X�X�s�[�h")] float _speedMax = 5;

    [Header("���炷�X�s�[�h")]
    [SerializeField, Tooltip("���炷�X�s�[�h")] float _minusSpeed = 3;

    [Header("EnemyGenerator")]
    [SerializeField, Tooltip("EnemyGenerator")] EnemyGenerator _enemyGenerator;

    [Header("��̃X�v���C�g")]
    [SerializeField, Tooltip("��̃X�v���C�g")] SpriteRenderer[] _nigthStage;

    [Header("�������̃X�v���C�g")]
    [SerializeField, Tooltip("�������̃X�v���C�g")] SpriteRenderer[] _brakingDownStage;
    
    [Tooltip("���݂̃X�s�[�h")]float _speed = 5;
    [Tooltip("�w�i�̓����ɂ��鑬��")] float _backGroundSpeed = 0.2f;
    [Tooltip("�X�^�[�g�ʒu")]private Vector2 startPos;
    [Tooltip("�w�i��")] float repeatWidth;
    [Tooltip("�����Z����������Bool")] bool _mainusBool = false;
    [Tooltip("�X�e�[�W����������")] int _stageCount = 0;

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
