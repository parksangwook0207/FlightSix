using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public override void Init()
    {
        ed.speed = 1f;
        ed.hp = 1000f;
        ed.isBoss = true;
        ed.fireNormaltime = 1f;
        player = FindObjectOfType<Player>();
        GetComponent<SpriteAnimation>().SetSprite(explosionSprite, 0.1f, Die);
    }
    private void Start()
    {
        Init();
    }
}
