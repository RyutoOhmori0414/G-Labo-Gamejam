using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("Objectを生成する場所")]
    List<GameObject> _generationLocation = new List<GameObject>();

    [Header("生成するObject")]
    List<GameObject> _generationObj = new List<GameObject>();

    [Header("生成する時間")]
    float _generationTime = 0;

    [Tooltip("TImeをカウントする")]
    float _countTime = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _countTime += Time.deltaTime;

        if (_countTime > _generationTime)
        {
            int priceNum = Random.Range(0, _generationLocation.Count);
            int ObjectNum = Random.Range(0, _generationObj.Count);

            GameObject Ins = Instantiate(_generationObj[ObjectNum], _generationObj[priceNum].transform.position, _generationObj[priceNum].transform.rotation);

        }
    }
}
