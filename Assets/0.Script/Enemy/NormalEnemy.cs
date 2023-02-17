using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    public override void Init()
    {
        ed.speed = 0.8f;
        ed.hp = 100f;
        ed.isBoss = false;
        player = FindObjectOfType<Player>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
