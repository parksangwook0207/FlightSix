using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBullet : MonoBehaviour
{
    private float speed = 2f; 

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, Time.deltaTime * speed));
    }
}
