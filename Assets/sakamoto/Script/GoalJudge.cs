using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalJudge : MonoBehaviour
{
    GameObject _player1Win;
    GameObject _player2Win;

    GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _player1Win = GameObject.Find("Rezarut/Player1WinPanel"); 
        _player1Win = GameObject.Find("Rezarut/Player2WinPanel");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player1" && _gameManager.NowTrun == GameManager.GameTrun.GameStart)
        {
            _gameManager.Result("1");
            Debug.Log("�Ă΂ꂽ");
        }
        else if (collision.gameObject.name == "Player2" && _gameManager.NowTrun == GameManager.GameTrun.GameStart) 
        {
            _gameManager.Result("2");
        }
        
    }
}
