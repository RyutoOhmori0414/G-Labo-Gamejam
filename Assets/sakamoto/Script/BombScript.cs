using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BombScript : MonoBehaviour
{
    //[Header("���������Ƃ��̃G�t�F�N�g")]
    [SerializeField] GameObject _bombEffect;
    [SerializeField] Rigidbody2D _rb;
    [Tooltip("��ɔ�Ԃ��ǂ���")] bool _isUp;
    [Header("��ɔ��ł����X�s�[�h")]
    [SerializeField]float _upSpeed;
    [Header("���ɔ��ł����X�s�[�h")]
    [SerializeField]float _downSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 20f);

        var player1 = Vector3.Distance(GameObject.Find("Player1").transform.position,this.gameObject.transform.position); 
        var player2 = Vector3.Distance(GameObject.Find("Player2").transform.position,this.gameObject.transform.position);

        //�v���C���[2�̕����߂�������
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
            //�v���C���[�ɓ����������G�t�F�N�g�𐶐�����
         �@ GameObject ins = Instantiate(_bombEffect, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(ins, 0.5f);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 2f);
        }
    }


    ///// <summary>
    ///// �������g����ʊO�ɍs�����Ƃ���Destroy����
    ///// �������ŏ������ʊO�ɂ����ꍇ�͌Ă΂ꂸ�ēx��ʊO�ɏo��ƌĂ΂��
    ///// </summary>
    //private void OnBecameInvisible()
    //{
    //    Destroy(this.gameObject);
    //}
}
