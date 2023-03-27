using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int x;
    public int y;

    public bool main;

    public Vector2 Pos = new Vector2();



    public void SetXY(int x, int y)
    {
        this.x = this.x + x;
        this.y = this.y + y;
    }

    public void Rotate()
    {
        transform.parent.Rotate(new Vector3(0f, 0f, -90));
    }

    public void Left()
    {
        if (true)
        {
            return;
        }
        Pos = new Vector2(Pos.x - 73, Pos.y);
        transform.parent.localPosition = Pos;
    }
    public void Right()
    {
        if (true)
        {
            return;
        }
        Pos = new Vector2(Pos.x + 73, Pos.y);
        transform.parent.localPosition = Pos;
    }
    public void Down()
    {
        if (true)
        {
            Pos = new Vector2(Pos.x, Pos.y - 73);
            transform.parent.localPosition = Pos;
        }
    }
}
