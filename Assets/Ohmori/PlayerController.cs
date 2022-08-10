using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>被弾した場合の処理</summary>
    public static event Action _hit; 
    Rigidbody2D _rb = default;
    //水平方向の入力
    float _horizontal = default;
    //垂直方向の入力
    float _vertical = default;
    /// <summary>お邪魔時に使うジェネレーター</summary>
    [SerializeField] GameObject _generator;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _vertical = Input.GetAxisRaw("Vertical");
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (_vertical == 0)
        {
            _rb.velocity = new Vector2 (_rb.velocity.x ,0);
        }
        if (_horizontal == 0)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }


        _rb.AddForce(transform.right * _horizontal);
        _rb.AddForce(transform.up * _vertical);
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
}
