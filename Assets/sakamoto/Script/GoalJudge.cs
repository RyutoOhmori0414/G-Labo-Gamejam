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
        _player1Win = GameObject.Find("Rezarut/Player1WinPanel"); ;
        _player1Win = GameObject.Find("Rezarut/Player2WinPanel"); ;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player1" && _gameManager.NowTrun == GameManager.GameTrun.GameStart)
        {
            SoundManager.Instance.Play(1, 0);
            SoundManager.Instance.Play(1, 5);
            _player1Win.SetActive(true);
            _gameManager.ChengeType(GameManager.GameTrun.Result);
        }
        else if (collision.gameObject.name == "Player2" && _gameManager.NowTrun == GameManager.GameTrun.GameStart) 
        {
            SoundManager.Instance.Play(1, 0);
            SoundManager.Instance.Play(1, 5);
            _player1Win.SetActive(true);
            _gameManager.ChengeType(GameManager.GameTrun.Result);
        }
        
    }
}
