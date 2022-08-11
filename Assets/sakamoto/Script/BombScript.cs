using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BombScript : MonoBehaviour
{
    //[Header("爆発したときのエフェクト")]
    [SerializeField] GameObject _bombEffect;
    [SerializeField] Rigidbody2D _rb;
    [Tooltip("上に飛ぶかどうか")] bool _isUp;
    [Header("上に飛んでいくスピード")]
    [SerializeField]float _upSpeed;
    [Header("下に飛んでいくスピード")]
    [SerializeField]float _downSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 20f);

        var player1 = Vector3.Distance(GameObject.Find("Player1").transform.position,this.gameObject.transform.position); 
        var player2 = Vector3.Distance(GameObject.Find("Player2").transform.position,this.gameObject.transform.position);

        //プレイヤー2の方が近かったら
        if (player1 > player2) 
        {
            _isUp = true;
        }
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isUp)
        {
            _rb.velocity = new Vector2(0, _upSpeed);
        }
        else 
        {
            _rb.velocity = new Vector2(0, _downSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            //プレイヤーに当たった時エフェクトを生成する
         　 GameObject ins = Instantiate(_bombEffect, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(ins, 0.5f);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 2f);
        }
    }


    ///// <summary>
    ///// 自分自身が画面外に行ったときにDestroyする
    ///// ただし最初から画面外にいた場合は呼ばれず再度画面外に出ると呼ばれる
    ///// </summary>
    //private void OnBecameInvisible()
    //{
    //    Destroy(this.gameObject);
    //}
}
