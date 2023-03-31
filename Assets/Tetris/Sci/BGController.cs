using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGController : MonoBehaviour
{
    // 선생님과 같이한 거
    [SerializeField] private BGBlock prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private AudioSource audio;




    [HideInInspector] public Vector3 startPos;


    public List<List<BGBlock>> bgBlock = new List<List<BGBlock>>();

    public int BlockXCnt { get; set; }
    public int BlockYCnt { get; set; }

    const int startYIndex = 1;

    public float spacingX = 0;
    public float spacingY = 0;


    void Start()
    {
        BlockXCnt = 10;
        BlockYCnt = 20;
        parent.GetComponent<GridLayoutGroup>().constraintCount = BlockXCnt;
        spacingX = parent.GetComponent<GridLayoutGroup>().spacing.x;
        spacingY = parent.GetComponent<GridLayoutGroup>().spacing.y;

        CreateBGBlock();
    }

    void CreateBGBlock()
    {
        for (int i = 0; i < BlockYCnt; i++)
        {
            bgBlock.Add(new List<BGBlock>());
            for (int j = 0; j < BlockXCnt; j++)
            {
                bgBlock[i].Add(Instantiate(prefab, parent));
                bgBlock[i][j].Check = false;
                bgBlock[i][j].Y = i;
                bgBlock[i][j].X = j;
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

    public void EffectSoundStart()
    {
        audio.Play();
    }
}
