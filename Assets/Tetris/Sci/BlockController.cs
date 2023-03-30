using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockController : MonoBehaviour
{
    [SerializeField] List<GameObject> blocks;
    [SerializeField] Transform parent;
    [SerializeField] Transform finishB;
    [SerializeField] private TMP_Text blocktext;
    //[SerializeField] GameObject overPanel;
    const int startPosY = 1;

    GameObject createObj;

    public List<Block> finishBlocks = new List<Block>();

    BGController bgCont;



    // Start is called before the first frame update
    void Start()
    {
        //overPanel.SetActive(false);
        bgCont = ControllerManager.Instance.bgCont;
    }

    public void CreateBlock()
    {
        int rand = Random.Range(0, blocks.Count);
        int x = ControllerManager.Instance.bgCont.BlockXCnt / 2;

        createObj = Instantiate(blocks[rand], parent);
        createObj.transform.localPosition = ControllerManager.Instance.bgCont.bgBlock[startPosY][x].transform.localPosition;

        ControllerManager.Instance.KeyCont.block = createObj;

        Block b = FindBlockMain();
        b.Pos = createObj.transform.localPosition;
    }
    public Block FindBlockMain()
    {
        for (int i = 0; i < createObj.transform.childCount; i++)
        {
            Block b = createObj.transform.GetChild(i).GetComponent<Block>();
            if (b.main)
            {
                return b;
            }
        }
        return null;
    }

    public void SetParent()
    {
        for (int i = createObj.transform.childCount - 1; i >= 0; i--)
        {
            Transform t = createObj.transform.GetChild(i);
            t.SetParent(finishB);
            t.localRotation = Quaternion.Euler(Vector3.zero);

            finishBlocks.Add(t.GetComponent<Block>());
        }

        Destroy(createObj);
    }

    public void XLineDelete()
    {
        List<int> delIndexs = new List<int>();
        for (int i = bgCont.BlockYCnt - 1; i >= 0; i--)
        {
            if (LineCheck(i))
            {
                delIndexs.Add(i);
            }
        }

        foreach (int y in delIndexs)
        {
            LineDelete(y);
        }
        delIndexs.Reverse();
        foreach (var y in delIndexs)
        {
            LineDown(y);
        }

        foreach (var item in delIndexs)
        {
            Debug.Log("Del :" + item);
        }


    }

    bool LineCheck(int y)
    {
        for (int x = 0; x < bgCont.BlockXCnt; x++)
        {
            if (bgCont.bgBlock[y][x].Check == false)
            {
                return false;
            }
        }
        return true;
    }

    void LineDelete(int y)
    {
        for (int i = finishBlocks.Count - 1; i >= 0; i--)
        {
            Block b = finishBlocks[i];
            if (b.y == y)
            {
                bgCont.bgBlock[b.y][b.x].Check = false;
                Destroy(b.gameObject);
                finishBlocks.Remove(b);
                blocktext.text += 10;
            }
        }
    }

    void LineDown(int y)
    {
        for (int i = 0; i < finishBlocks.Count; i++)
        {
            Block b = finishBlocks[i];
            if (b.y <= y - 1)
            {
                Vector2 vec2 = b.transform.localPosition;
                b.transform.localPosition = new Vector2(vec2.x, vec2.y - b.SizeY);
                b.y++;
            }
            MapReflush();
        }
    }

    void MapReflush()
    {
        for (int y = 0; y < bgCont.BlockYCnt; y++)
        {
            for (int x = 0; x < bgCont.BlockXCnt; x++)
            {
                bgCont.bgBlock[y][x].Check = false;
            }
        }
        for (int i = 0; i < finishBlocks.Count; i++)
        {
            Block b = finishBlocks[i];
            bgCont.bgBlock[b.y][b.x].Check = true;
        }
    }
}
