using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int x;
    public int y;

    public bool main;

    public float SizeX { get; set; }
    public float SizeY { get; set; }

    public Vector2 Pos = new Vector2();

    BGController bgCont;
    BlockController blockCont;

    void Start()
    {
        SizeX = 33;
        SizeY = 33;

       bgCont = ControllerManager.Instance.bgCont;
        blockCont = ControllerManager.Instance.blockCont;

        GetComponent<RectTransform>().sizeDelta = new Vector2(SizeX - bgCont.spacingX, SizeY - bgCont.spacingY);
        Vector2 vec2 = GetComponent<RectTransform>().localPosition;
        GetComponent<RectTransform>().localPosition = new Vector2((vec2.x / 73f) * SizeX, (vec2.y / 73f) * SizeY);
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
        if (IsMoveX(-1))
        {
            Pos = new Vector2(Pos.x - SizeX, Pos.y);
            transform.parent.localPosition = Pos;
        }

    }
    public void Right()
    {
        if (IsMoveX(1))
        {
            Pos = new Vector2(Pos.x + SizeX, Pos.y);
            transform.parent.localPosition = Pos;
        }

    }
    public void Down()
    {
        if (IsCheckY() == true )
        {
            Pos = new Vector2(Pos.x, Pos.y - SizeY);
            transform.parent.localPosition = Pos;
        }
        else
        {
            BlockDownFinish();
            blockCont.SetParent();
            blockCont.XLineDelete();
            ControllerManager.Instance.KeyCont.autoDown = false;
            blockCont.CreateBlock();
        }
    }
    bool IsMoveX(int val)
    {
        int count = 0;
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            Block b = transform.parent.GetChild(i).GetComponent<Block>();
            int x = b.x + val;
            if (x >= 0 && x <= bgCont.BlockXCnt - 1 && bgCont.bgBlock[b.y][x].Check == false) 
                count++;
        }
        return count == transform.parent.childCount ? true : false;
    }
    bool IsMoveY()
    {
        int count = 0;
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            Block b = transform.parent.GetChild(i).GetComponent<Block>();
            if (b.y + 1 <= bgCont.BlockYCnt)
            {
                continue;
            }
            if (bgCont.bgBlock[b.y][b.x].Check == false)
            {
                count++;
            }

        }
        return count == transform.parent.childCount ? true : false;
    }

    bool IsCheckY()
    {
        int count = 0;
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            Block b = transform.parent.GetChild(i).GetComponent<Block>();

            if (b.y + 1 >= bgCont.BlockYCnt)
                 continue;
            
            if (bgCont.bgBlock[b.y +1][b.x].Check == false)
                count++;
            
            
        }
        return count == transform.parent.childCount ? true : false;
    }

    void BlockDownFinish()
    {
        foreach (Transform trans in transform.parent)
        {
            Block b = trans.GetComponent<Block>();
            bgCont.bgBlock[b.y][b.x].Check = true;
        }

        bgCont.EffectSoundStart();
    }
}
