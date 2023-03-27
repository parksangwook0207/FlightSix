using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGController : MonoBehaviour
{
    // 선생님과 같이한 거
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;


    [HideInInspector] public Vector3 startPos;


    public List<List<GameObject>> bgBlock = new List<List<GameObject>>();

    public int BlockXCnt { get; set; }
    public int BlockYCnt { get; set; }

    const int startYIndex = 1;



    void Start()
    {
        BlockXCnt = 10;
        BlockYCnt = 20;



        parent.GetComponent<GridLayoutGroup>().constraintCount = BlockXCnt;

        CreateBGBlock();
    }

    void CreateBGBlock()
    {
        for (int i = 0; i < BlockYCnt; i++)
        {
            bgBlock.Add(new List<GameObject>());
            for (int j = 0; j < BlockXCnt; j++)
            {
                bgBlock[i].Add(Instantiate(prefab, parent));
            }
        }
        StartCoroutine(Gridoff());
    }

    IEnumerator Gridoff()
    {
        yield return new WaitForSeconds(0.2f);
        parent.GetComponent<GridLayoutGroup>().enabled = false;
        //startPos = bgBlock[startY]
        ControllerManager.Instance.blockCont.CreateBlock();
    }
    
}
