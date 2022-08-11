using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ItemController : MonoBehaviour
{
    [Header("RegidBody")]
    [SerializeField]Rigidbody2D _rb;
    [Header("オブジェクトのスピード")]
    [SerializeField]float _speed = 0;
    [Header("追尾するかどうか")]
    [SerializeField] bool _isTracking = false;

    SoundManager _soundManager;

    [Tooltip("追尾する弾の速度")]
    Vector3 velocity;
    [Tooltip("発射されるときの初期位置")]
    Vector3 _positionObj;
    [Tooltip("追尾する加速度")]
    private Vector3 acceleration;
    [Tooltip("追尾するターゲットをセットする")]
    private Transform target;
    // 着弾時間
    float period = 2f;
    void Start()
    {
       // target = GameObject.Find("Player").GetComponent<Transform>();
        _positionObj = transform.position;

        _soundManager = SoundManager.Instance;

    }

    void Update()
    {
        TrackingBool();

    }

    void FixedUpdate()
    {
        ItemMove();
    }

    /// <summary>追尾に関する処理</summary>
    void TrackingBool() 
    {
        if (_isTracking)
        {
            acceleration = Vector3.zero;

            //ターゲットと自分自身の差
            var diff = target.position - transform.position;

            //加速度を求めてる
            acceleration += (diff - velocity * period) * 2f
                            / (period * period);


            //加速度が一定以上だと追尾を弱くする
            if (acceleration.magnitude > 10f)
            {
                acceleration = acceleration.normalized * 10f;
            }

            // 着弾時間を徐々に減らしていく
            period -= Time.deltaTime;

            // 速度の計算
            velocity += acceleration * Time.deltaTime;
        }
        else
        {


        }
    }

    /// <summary>Itemの移動処理</summary>
    void ItemMove() 
    {
        if (_isTracking)
        {
            _rb.MovePosition(transform.position + velocity * Time.deltaTime);
        }
        else
        {
            //横に移動する
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// 自分自身が画面外に行ったときにDestroyする
    /// ただし最初から画面外にいた場合は呼ばれず再度画面外に出ると呼ばれる
    /// </summary>
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }


     public void Sound() 
    {
        if(gameObject.name == "Fukurou") 
        {
            _soundManager.Play(1, 0);
        }
        else if(gameObject.name == "Fire") 
        {
            int a = Random.Range(0, 5);
            if (a == 0) 
            {
                _soundManager.Play(1, 1);
            }
        }

    } 

}
