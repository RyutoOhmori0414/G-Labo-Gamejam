using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /// <summary>持っているアイテム</summary>
    private void OnEnable()
    {
        GameManager.NowGameTrun += WakeUpPlayer;
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); 
        //_rb.simulated = false;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ItemBox"))
        {
            Destroy(collision.gameObject);
            //_generator.GetComponent<EnemyGenerator>().GenerationOBJ();
        }
        _hit.Invoke();
    }

    void WakeUpPlayer(GameManager.GameTrun gameTurn)
    {
        if (gameTurn == GameManager.GameTrun.GameStart)
        {
            _rb.simulated = true;
        }
    }
}
