using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    [SerializeField]
    float timer = 120;
    [SerializeField]
    GameObject result = null;
    //MAX2min �����Ă�

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            result.SetActive(true);
        }
    }
}
