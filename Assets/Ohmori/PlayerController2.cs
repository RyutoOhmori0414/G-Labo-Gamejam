using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    /// <summary>��e�����ꍇ�̏���</summary>
    public static event Action _hit; 
    Rigidbody2D _rb = default;
    //���������̓���
    float _horizontal = default;
    //���������̓���
    float _vertical = default;
    [Header("�{�[���̓����X�s�[�h")]
    [SerializeField] float _speed = 1f;
    /// <summary>���ז����Ɏg���W�F�l���[�^�[</summary>
    [SerializeField] GameObject _generator;
    /// <summary>���ז��A�C�e��</summary>
    [Header("���ז��A�C�e���@ItemBox��Tag Ctrl�������ďo��GameObject")]
    [SerializeField] Dictionary<string, GameObject> _itemList = new Dictionary<string, GameObject>();
    /// <summary>���ݎ����Ă���A�C�e��</summary>
    [SerializeField] GameObject _currentItem;
    /// <summary>�������A�C�e��</summary>
    [Header("�������A�C�e���@ItemBox��Tag Ctrl�������ďo��GameObject")]
    [SerializeField] Dictionary<string, GameObject> _itemList2 = new Dictionary<string, GameObject>();
    /// <summary>���ݎ����Ă���A�C�e����\������UI</summary>
    [Header("���ݎ����Ă���A�C�e����\������UI")]
    [SerializeField] Image _currentItemUI;
    /// <summary>BackGround�̃X�N���v�g</summary>
    [Header("BackGround�̃X�N���v�g")]
    [SerializeField] Stage _bgScript;
    private void OnEnable()
    {
        GameManager.NowGameTrun += WakeUpPlayer;
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); 
        _rb.simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        _vertical = Input.GetAxisRaw("Vertical2");
        _horizontal = Input.GetAxisRaw("Horizontal2");
        Vector3 Vect = new Vector3(_horizontal, _vertical, 0);
        Vect = Vect.normalized;

        if (_vertical == 0)
        {
            _rb.velocity = new Vector2 (_rb.velocity.x ,0);
        }
        if (_horizontal == 0)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }

        _rb.AddForce(transform.right * Vect.x * _speed);
        _rb.AddForce(transform.up * Vect.y * _speed);

        if (Input.GetButton("Fire2") && _currentItem)
        {
            Instantiate(_currentItem);
            _currentItem = null;
            _currentItemUI.sprite = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_itemList.ContainsKey(collision.gameObject.tag))
        {
            _currentItem = _itemList[collision.gameObject.tag];
            _currentItemUI.sprite = _itemList[collision.gameObject.tag].GetComponent<SpriteRenderer>().sprite;
        }
        else if (_itemList2.ContainsKey(collision.gameObject.tag))
        {
            _currentItem = _itemList2[collision.gameObject.tag];
            _currentItemUI.sprite = _itemList2[collision.gameObject.tag].GetComponent<SpriteRenderer>().sprite;
        }
        if (!collision.gameObject.CompareTag("BuckGround"))
        {
            _bgScript.Speed();
            GetComponent<Animator>().Play("OnEnemy");
            Debug.Log("�Ă΂�Ƃ��");
        }
    }
    void WakeUpPlayer(GameManager.GameTrun gameTurn)
    {
        if (gameTurn == GameManager.GameTrun.GameStart)
        {
            _rb.simulated = true;
        }
    }
}
