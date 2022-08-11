using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("Object�𐶐�����ꏊ")]
    [SerializeField] List<GameObject> _generationLocation = new List<GameObject>();

    [Header("�S�[���𐶐�����ꏊ")]
    [SerializeField] GameObject _goalPosition;

    [Header("��������Object")]
    [SerializeField] List<GameObject> _generationObj = new List<GameObject>();

    [Header("���ז��A�C�e����Prefab")]
    [SerializeField] GameObject _disturbPrefab;

    [Header("�������鎞��")]
    [SerializeField] float _generationTime = 0;

    [Header("�S�[����Prefab")]
    [SerializeField] GameObject _goalPrefab;

    [Tooltip("TIme���J�E���g����")]
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

    /// <summary>�ݒ肵�����Ԃ��Ƃ�List��Object�������_���ɐ�������</summary>
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

    /// <summary>���ז��I�u�W�F�N�g�𐶐�����</summary>
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
