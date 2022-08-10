using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ItemController : MonoBehaviour
{
    [Header("RegidBody")]
    [SerializeField]Rigidbody _rb;
    [Header("オブジェクトのスピード")]
    [SerializeField]float _speed = 0;
    void Start()
    {
        
    }

    void Update()
    {
        //横に移動する
        _rb.velocity = new Vector2(_speed, _rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Destroy(this.gameObject);
        }
    }


}
