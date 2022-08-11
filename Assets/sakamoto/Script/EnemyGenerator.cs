using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("Object�𐶐�����ꏊ")]
    [SerializeField] List<GameObject> _generationLocation = new List<GameObject>();

    [Header("�S�[���𐶐�����ꏊ")]
    [SerializeField] GameObject _goalPosition;

    [Header("�������邨�ז�Object")]
    [SerializeField] List<GameObject> _generationObj = new List<GameObject>();

    [Header("��������A�C�e��")]
    [SerializeField] List<GameObject> _generationItem = new List<GameObject>(); 

    [Header("���ז��A�C�e����Prefab")]
    [SerializeField] GameObject _disturbPrefab;

    [Header("���ז��A�C�e���𐶐����鎞��")]
    [SerializeField] float _generationTime = 0;

    [Header("�������A�C�e���𐶐����鎞��")]
    [SerializeField] float _itemGenerationTime = 0;

    [Header("�S�[����Prefab")]
    [SerializeField] GameObject _goalPrefab;

    [Tooltip("TIme���J�E���g����")]
    float _countTime = 0;

    [Tooltip("ItemTime���J�E���g����")]
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

    /// <summary>�ݒ肵�����Ԃ��Ƃ�List��Object�������_���ɐ�������</summary>
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

    /// <summary>���ז��I�u�W�F�N�g�𐶐�����</summary>
    public void GenerationObj() 
    {
        int priceNum = Random.Range(0, _generationLocation.Count);
        int ObjectNum = Random.Range(0, _generationObj.Count);

        GameObject Ins = Instantiate(_disturbPrefab, _generationLocation[priceNum].transform.position, _generationLocation[priceNum].transform.rotation);
    }

    /// <summary>�S�[���̃I�u�W�F�N�g�𐶐�����</summary>
    public void GoalGeneration() 
    {
        Debug.Log("�Ă΂�Ƃ��");
        GameObject Ins = Instantiate(_goalPrefab, _generationLocation[2].transform.position, _generationLocation[2].transform.rotation);
    }
}
