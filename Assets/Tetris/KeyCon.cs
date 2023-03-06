using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyCon : MonoBehaviour
{
    [SerializeField] private GameObject key;

    float moveX = 0;
    float moveY = 0;
    // Start is called before the first frame update

    float autoDownTime = 0;



    // Update is called once per frame
    void Update()
    {
        // ����Ű ������ ���� �� ��ȯ
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            key.transform.Rotate(Vector3.forward * 90 * -1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveX -= 75.6f;
            key.transform.localPosition = new Vector3(moveX, moveY);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveX += 75.6f;
            key.transform.localPosition = new Vector3(moveX, moveY);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            BlockDown();
            autoDownTime = 0;
        }
        
        autoDownTime += Time.deltaTime;
        if (autoDownTime > 0.5f)
        {
            autoDownTime = 0;
            BlockDown();
        }

    }
    void BlockDown()
    {
        moveY -= 75.6f;
        key.transform.localPosition = new Vector3(moveX, moveY);
    }
}
