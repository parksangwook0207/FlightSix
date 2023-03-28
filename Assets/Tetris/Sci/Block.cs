using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int x;
    public int y;

    public bool main;

    public Vector2 Pos = new Vector2();

    BGController bgCont;
    BlockController blockCont;

    void Start()
    {
        bgCont = ControllerManager.Instance.bgCont;
        blockCont = ControllerManager.Instance.blockCont;
    }

    void Update()
    {
        SetAutoXY(transform);
    }

    public void SetXY(int x, int y)
    {
        this.x = this.x + x;
        this.y = this.y + y;
    }

    public void SetAutoXY(Transform trans)
    {
        float distance = 100;
        for (int i = 0; i < bgCont.BlockYCnt; i++)
        {
            for (int j = 0; j < bgCont.BlockXCnt; j++)
            {
                float dis = Vector2.Distance(bgCont.bgBlock[i][j].transform.position, trans.position);
                if (dis < 0.001f)
                {
                    distance = dis;
                    BGBlock bgB = bgCont.bgBlock[i][j].GetComponent<BGBlock>();
                    x = bgB.X;
                    y = bgB.Y;
                    //return;
                }
            }
        }
    }

    public void Rotate()
    {
        transform.parent.Rotate(new Vector3(0f, 0f, -90f));
    }

    public void Left()
    {
        if (isMoveX(-1))
        {
            Pos = new Vector2(Pos.x - 73, Pos.y);
            transform.parent.localPosition = Pos;
        }
       
    }
    public void Right()
    {
        if (isMoveX(1))
        {
            Pos = new Vector2(Pos.x + 73, Pos.y);
            transform.parent.localPosition = Pos;
        }
       
    }
    public void Down()
    {
        if (isMoveY())
        {
            Pos = new Vector2(Pos.x, Pos.y - 73);
            transform.parent.localPosition = Pos;
        }
    }
    bool isMoveX(int val)
    {
        int count = 0;
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            Block b = transform.parent.GetChild(i).GetComponent<Block>();
            int x = b.x + val;
            if (x >= 0 && x <= bgCont.BlockXCnt - 1)
                count++;
        }
        return count == transform.parent.childCount ? true : false;
    }
    bool isMoveY()
    {
        int count = 0;
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            Block b = transform.parent.GetChild(i).GetComponent<Block>();
            if (b.y + 1  <= bgCont.BlockYCnt - 1)
                count++;
        }
        return count == transform.parent.childCount ? true : false;
    }
}
