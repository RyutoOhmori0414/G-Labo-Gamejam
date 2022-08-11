using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GoalController : MonoBehaviour
{
    [Header("ゴールのスピード")]
    [SerializeField] float _speed;

    [Header("RigidBody")]
    [SerializeField] Rigidbody2D _rb;

    [Header("ResultSceneの名前")]
    [SerializeField] string _resultName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(_speed * -1, 0);
    }

}
