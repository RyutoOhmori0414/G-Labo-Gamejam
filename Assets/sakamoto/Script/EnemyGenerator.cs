using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("Objectを生成する場所")]
    [SerializeField] List<GameObject> _generationLocation = new List<GameObject>();

    [Header("ゴールを生成する場所")]
    [SerializeField] GameObject _goalPosition;

    [Header("生成するObject")]
    [SerializeField] List<GameObject> _generationObj = new List<GameObject>();

    [Header("お邪魔アイテムのPrefab")]
    [SerializeField] GameObject _disturbPrefab;

    [Header("生成する時間")]
    [SerializeField] float _generationTime = 0;

    [Header("ゴールのPrefab")]
    [SerializeField] GameObject _goalPrefab;

    [Tooltip("TImeをカウントする")]
    float _countTime = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeGeneration();
    }

    /// <summary>設定した時間ごとにListのObjectをランダムに生成する</summary>
    void TimeGeneration() 
    {
        _countTime += Time.deltaTime;

        if (_countTime > _generationTime)
        {
            int priceNum = Random.Range(0, _generationLocation.Count);
            int ObjectNum = Random.Range(0, _generationObj.Count);

            GameObject Ins = Instantiate(_generationObj[ObjectNum], _generationLocation[priceNum].transform.position, _generationLocation[priceNum].transform.rotation);

            _countTime = 0;
        }
    }

    /// <summary>お邪魔オブジェクトを生成する</summary>
    public void GenerationObj() 
    {
        int priceNum = Random.Range(0, _generationLocation.Count);
        int ObjectNum = Random.Range(0, _generationObj.Count);

        GameObject Ins = Instantiate(_disturbPrefab, _generationLocation[priceNum].transform.position, _generationLocation[priceNum].transform.rotation);
    }

    public void GoalGeneration() 
    {
        GameObject Ins = Instantiate(_goalPrefab, _generationLocation[1].transform.position, _generationLocation[1].transform.rotation);
    }
}
