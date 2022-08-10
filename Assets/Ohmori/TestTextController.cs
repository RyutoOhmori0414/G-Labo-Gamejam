using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TestTextController : MonoBehaviour
{
    [SerializeField] Text _text;

    [SerializeField] string _textstring;

    [SerializeField] float _distance;

    int _mojisuu = default;
    float _keikajikan = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - _keikajikan > _distance && _mojisuu < _textstring.Length)
        {
            _mojisuu++;
            _text.text = _textstring.Substring(0, _mojisuu);
            _keikajikan = Time.realtimeSinceStartup;
        }
    }
}
