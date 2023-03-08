using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TetrisSc : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject prefab1;
    [SerializeField] private Transform parent1;

    public int BlockXCnt { get; set; }
    public int BlockYCnt { get; set; }


    private Image newBlock;

    private Vector3 start;

    private List<GameObject> tebox = new List<GameObject>();


    void Start()
    {
        BlockXCnt = 10;
        BlockYCnt = 20;

        GetComponent<GridLayoutGroup>().constraintCount = BlockXCnt;

        Tetrisnew();
        CreateBlockT();
    }

    public void Tetrisnew()
    {
        // 처음 10 * 20 생성
        for (int i = 0; i < BlockXCnt * BlockYCnt; i++)
        {
            tebox.Add(Instantiate(prefab, parent));
        }
        StartCoroutine(Tetrisoff());
    }

    IEnumerator Tetrisoff()
    {
        yield return new WaitForSeconds(0.2f);
        GetComponent<GridLayoutGroup>().enabled = false;
        start = tebox[BlockXCnt / 2].transform.localPosition;
        prefab1.transform.localPosition = start;
    }
    
    void CreateBlockT()
    {
        Instantiate(prefab1, parent1);
    }
}
