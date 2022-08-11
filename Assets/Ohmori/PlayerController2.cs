using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    /// <summary>被弾した場合の処理</summary>
    public static event Action _hit; 
    Rigidbody2D _rb = default;
    //水平方向の入力
    float _horizontal = default;
    //垂直方向の入力
    float _vertical = default;
    [Header("ボールの動くスピード")]
    [SerializeField] float _speed = 1f;
    /// <summary>お邪魔時に使うジェネレーター</summary>
    [SerializeField] GameObject _generator;
    /// <summary>お邪魔アイテム</summary>
    [Header("お邪魔アイテム　ItemBoxのTag Ctrlを押して出るGameObject")]
    [SerializeField] Dictionary<string, GameObject> _itemList = new Dictionary<string, GameObject>();
    /// <summary>現在持っているアイテム</summary>
    [SerializeField] GameObject _currentItem;
    /// <summary>お助けアイテム</summary>
    [Header("お助けアイテム　ItemBoxのTag Ctrlを押して出るGameObject")]
    [SerializeField] Dictionary<string, GameObject> _itemList2 = new Dictionary<string, GameObject>();
    /// <summary>現在持っているアイテムを表示するUI</summary>
    [Header("現在持っているアイテムを表示するUI")]
    [SerializeField] Image _currentItemUI;
    /// <summary>BackGroundのスクリプト</summary>
    [Header("BackGroundのスクリプト")]
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
            Debug.Log("呼ばれとるで");
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
