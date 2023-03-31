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
             Rotata();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            KeyLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            KeyRight();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ControllerManager.Instance.blockCont.FindBlockMain().Down();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            autoDown = true;
        }
        autoDownTime += Time.deltaTime;
        if (autoDown)
        {
            if (autoDownTime > 0.001f)
            {
                autoDownTime = 0;
                ControllerManager.Instance.blockCont.FindBlockMain().Down();
            }
        }
        else
        {
            if (autoDownTime > downTime)
            {
                autoDownTime = 0;
                ControllerManager.Instance.blockCont.FindBlockMain().Down();
            }
        }
    }

    public void KeyLeft()
    {
        ControllerManager.Instance.blockCont.FindBlockMain().Left();
    }
    public void KeyRight()
    {
        ControllerManager.Instance.blockCont.FindBlockMain().Right();
    }
    public void Rotata()
    {
        ControllerManager.Instance.blockCont.FindBlockMain().Rotate();
    }

    public void Down()
    {
        autoDown = true;
    }
}
