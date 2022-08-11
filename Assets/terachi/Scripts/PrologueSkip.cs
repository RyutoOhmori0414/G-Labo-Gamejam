using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueSkip : MonoBehaviour
{
    [SerializeField]
    GameObject panelObject;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            panelObject.SetActive(false);
        }
    }
}
