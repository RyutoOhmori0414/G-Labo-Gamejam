using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>”í’e‚µ‚½ê‡‚Ìˆ—</summary>
    public static event Action _hit; 
    Rigidbody2D _rb = default;
    //…•½•ûŒü‚Ì“ü—Í
    float _horizontal = default;
    //‚’¼•ûŒü‚Ì“ü—Í
    float _vertical = default;
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
        _hit.Invoke();
    }
}
