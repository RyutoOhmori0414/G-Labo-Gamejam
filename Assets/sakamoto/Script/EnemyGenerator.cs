using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("Object�𐶐�����ꏊ")]
    List<GameObject> _generationLocation = new List<GameObject>();

    [Header("��������Object")]
    List<GameObject> _generationObj = new List<GameObject>();

    [Header("�������鎞��")]
    float _generationTime = 0;

    [Tooltip("TIme���J�E���g����")]
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
