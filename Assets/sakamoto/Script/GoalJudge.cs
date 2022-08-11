using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalJudge : MonoBehaviour
{
    [SerializeField] GameObject _player1Win;
    [SerializeField] GameObject _player2Win;

    GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player1" && _gameManager.NowTrun == GameManager.GameTrun.GameStart)
        {
            _player1Win.SetActive(true);
            _gameManager.ChengeType(GameManager.GameTrun.Result);
        }
        else if (collision.gameObject.name == "Player2" && _gameManager.NowTrun == GameManager.GameTrun.GameStart) 
        {
            _player1Win.SetActive(true);
            _gameManager.ChengeType(GameManager.GameTrun.Result);
        }
        
    }
}
