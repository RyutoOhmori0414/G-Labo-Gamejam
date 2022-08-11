using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressEnter : MonoBehaviour
{
    bool isPressEnter;
    [SerializeField]
    GameObject gameExplain;

    // Update is called once per frame
    void Update()
    {
        if(isPressEnter != true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameExplain.SetActive(false);
                //SoundManager.Instance.Play(1, 4);
                isPressEnter = true;

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //SoundManager.Instance.Play(1, 4);
                //SceneManager.LoadScene("Playgamen");
            }
        }

        
    }
}
