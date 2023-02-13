using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

    [SerializeField] private Transform[] buttonts;
    [SerializeField] private Transform[] middleTs;
    [SerializeField] private Transform[] topTs;

    [SerializeField] private float buttomSpeed = 0f;
    [SerializeField] private float middleTsSpeed = 0f;
    [SerializeField] private float topTsSpeed = 0f;

    [SerializeField] private float lastPos = 0f;
    [SerializeField] private float initPos = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in buttonts)
        {
            BGMove(item, buttomSpeed);
        }
        foreach (var item in middleTs)
        {
            BGMove(item, middleTsSpeed);
        }
        foreach (var item in topTs)
        {
            BGMove(item, topTsSpeed);
        }
    }

    void BGMove(Transform trans, float speed)
    {
        trans.Translate(new Vector2(0f, -(Time.deltaTime * topTsSpeed)));
        if (trans.position.y < lastPos)
        {
            trans.position = new Vector3(0f, initPos);
        }
    }
}
