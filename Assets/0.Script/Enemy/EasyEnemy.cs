using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemy : Enemy
{
    public override void Init()
    {
        ed.speed = 1f;
        ed.hp = 100f;
        ed.isBoss = false;
        ed.fireNormaltime = 2f;

        player = FindObjectOfType<Player>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

}
