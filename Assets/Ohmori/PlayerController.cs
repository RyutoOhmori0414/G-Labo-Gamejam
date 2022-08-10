using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>��e�����ꍇ�̏���</summary>
    public static event Action _hit; 
    Rigidbody2D _rb = default;
    //���������̓���
    float _horizontal = default;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxisRaw("Vertical");

        if (_horizontal == 0)
        {
            _rb.velocity = Vector2.zero;
        }
        
        _rb.AddForce(transform.up * _horizontal);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _hit.Invoke();
    }
}
