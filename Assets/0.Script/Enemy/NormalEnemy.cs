using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    public override void Init()
    {
        ed.speed = Random.Range(3, 6) * 0.1f;
        ed.hp = 500f;
        ed.isBoss = false;
        ed.fireNormaltime = 1f;
        player = FindObjectOfType<Player>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
