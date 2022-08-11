using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ItemController : MonoBehaviour
{
    [Header("RegidBody")]
    [SerializeField]Rigidbody2D _rb;
    [Header("�I�u�W�F�N�g�̃X�s�[�h")]
    [SerializeField]float _speed = 0;
    [Header("�ǔ����邩�ǂ���")]
    [SerializeField] bool _isTracking = false;

    SoundManager _soundManager;

    [Tooltip("�ǔ�����e�̑��x")]
    Vector3 velocity;
    [Tooltip("���˂����Ƃ��̏����ʒu")]
    Vector3 _positionObj;
    [Tooltip("�ǔ���������x")]
    private Vector3 acceleration;
    [Tooltip("�ǔ�����^�[�Q�b�g���Z�b�g����")]
    private Transform target;
    // ���e����
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

    /// <summary>�ǔ��Ɋւ��鏈��</summary>
    void TrackingBool() 
    {
        if (_isTracking)
        {
            acceleration = Vector3.zero;

            //�^�[�Q�b�g�Ǝ������g�̍�
            var diff = target.position - transform.position;

            //�����x�����߂Ă�
            acceleration += (diff - velocity * period) * 2f
                            / (period * period);


            //�����x�����ȏゾ�ƒǔ����キ����
            if (acceleration.magnitude > 10f)
            {
                acceleration = acceleration.normalized * 10f;
            }

            // ���e���Ԃ����X�Ɍ��炵�Ă���
            period -= Time.deltaTime;

            // ���x�̌v�Z
            velocity += acceleration * Time.deltaTime;
        }
        else
        {


        }
    }

    /// <summary>Item�̈ړ�����</summary>
    void ItemMove() 
    {
        if (_isTracking)
        {
            _rb.MovePosition(transform.position + velocity * Time.deltaTime);
        }
        else
        {
            //���Ɉړ�����
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
    /// �������g����ʊO�ɍs�����Ƃ���Destroy����
    /// �������ŏ������ʊO�ɂ����ꍇ�͌Ă΂ꂸ�ēx��ʊO�ɏo��ƌĂ΂��
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
