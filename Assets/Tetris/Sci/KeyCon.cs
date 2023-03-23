using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyCon : MonoBehaviour
{
    public GameObject block;

    [HideInInspector] public Vector2 movePos;
   
    // 블럭이 떨어지는 시간
    float autoDownTime = 0;


    // Update is called once per frame
    void Update()
    {
        if (block == null)
            return;

        // 방향키 위에를 누를 시 변환
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            block.transform.Rotate(Vector3.forward * 90 * -1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movePos.x -= 75f;
            block.transform.localPosition = movePos;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movePos.x += 75f;
            block.transform.localPosition = movePos;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            BlockDown();
            autoDownTime = 0;
        }
        
        autoDownTime += Time.deltaTime;
        if (autoDownTime > 1f)
        {
            autoDownTime = 0f;
            BlockDown();
        }
    }
    void BlockDown()
    {
        if (movePos.y == -712.5)
        {
            ConManager.Instance.tc.CreateBlockT();
            return;
        }
        movePos.y -= 75f;
        block.transform.localPosition = movePos;
    }

}
