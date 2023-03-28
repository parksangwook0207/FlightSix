using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControll : MonoBehaviour
{
    [HideInInspector] public GameObject block;
    [HideInInspector] public bool autoDown = false;
    [HideInInspector] public float downTime = 2f;

    float autoDownTime = 0;
    float keyMoveDelay = 0f;
    // Update is called once per frame
    
    public void Update()
    {
        keyMoveDelay += Time.deltaTime;        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ControllerManager.Instance.blockCont.FindBlockMain().Rotate();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ControllerManager.Instance.blockCont.FindBlockMain().Left();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ControllerManager.Instance.blockCont.FindBlockMain().Right();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ControllerManager.Instance.blockCont.FindBlockMain().Down();
        }
    }
}
