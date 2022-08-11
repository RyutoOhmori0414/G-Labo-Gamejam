using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("Objectを生成する場所")]
    [SerializeField] List<GameObject> _generationLocation = new List<GameObject>();

    [Header("ゴールを生成する場所")]
    [SerializeField] GameObject _goalPosition;

    [Header("生成するお邪魔Object")]
    [SerializeField] List<GameObject> _generationObj = new List<GameObject>();

    [Header("生成するアイテム")]
    [SerializeField] List<GameObject> _generationItem = new List<GameObject>(); 

    [Header("お邪魔アイテムのPrefab")]
    [SerializeField] GameObject _disturbPrefab;

    [Header("お邪魔アイテムを生成する時間")]
    [SerializeField] float _generationTime = 0;

    [Header("お助けアイテムを生成する時間")]
    [SerializeField] float _itemGenerationTime = 0;

    [Header("ゴールのPrefab")]
    [SerializeField] GameObject _goalPrefab;

    [Tooltip("TImeをカウントする")]
    float _countTime = 0;

    [Tooltip("ItemTimeをカウントする")]
    float _itemCountTime = 0;
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
        _itemCountTime += Time.deltaTime;   

        if (_countTime > _generationTime)
        {
            int priceNum = Random.Range(0, _generationLocation.Count);
            int ObjectNum = Random.Range(0, _generationObj.Count);

            GameObject Ins = Instantiate(_generationObj[ObjectNum], _generationLocation[priceNum].transform.position, _generationLocation[priceNum].transform.rotation);

            _countTime = 0;
        }

        if(_itemCountTime > _itemGenerationTime)
        {
            int priceNum = Random.Range(0, _generationLocation.Count);
            int ObjectNum = Random.Range(0, _generationItem.Count);

            GameObject Ins = Instantiate(_generationItem[ObjectNum], _generationLocation[priceNum].transform.position, _generationLocation[priceNum].transform.rotation);

            _itemCountTime = 0;
        }
    }

    /// <summary>お邪魔オブジェクトを生成する</summary>
    public void GenerationObj() 
    {
        int priceNum = Random.Range(0, _generationLocation.Count);
        int ObjectNum = Random.Range(0, _generationObj.Count);

        GameObject Ins = Instantiate(_disturbPrefab, _generationLocation[priceNum].transform.position, _generationLocation[priceNum].transform.rotation);
    }

    /// <summary>ゴールのオブジェクトを生成する</summary>
    public void GoalGeneration() 
    {
        Debug.Log("呼ばれとるで");
        GameObject Ins = Instantiate(_goalPrefab, _generationLocation[2].transform.position, _generationLocation[2].transform.rotation);
    }
}
