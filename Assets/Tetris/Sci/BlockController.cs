using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] List<GameObject> blocks;
    [SerializeField] Transform parent;
    [SerializeField] Transform finishB;
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
}
