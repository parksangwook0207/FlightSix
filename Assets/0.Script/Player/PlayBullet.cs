using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBullet : MonoBehaviour
{
    private float speed = 10f;
    [HideInInspector] public float power = 0;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, Time.deltaTime * speed));
    }

    public void SetPower(float power)
    {
        this.power = power;
    }

    
}
