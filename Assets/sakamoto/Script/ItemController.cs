using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ItemController : MonoBehaviour
{
    [Header("RegidBody")]
    [SerializeField]Rigidbody _rb;
    [Header("�I�u�W�F�N�g�̃X�s�[�h")]
    [SerializeField]float _speed = 0;
    void Start()
    {
        
    }

    void Update()
    {
        //���Ɉړ�����
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
