using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEmey : Enemy
{
    public override void Init()
    {
        ed.speed = 1f;
        ed.hp = 500f;
        ed.fireNormaltime = 2f; 
        ed.isBoss = false;

        player = FindObjectOfType<Player>();

    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
