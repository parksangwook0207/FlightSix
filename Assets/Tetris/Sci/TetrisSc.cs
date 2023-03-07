using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TetrisSc : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform tar;

    public int BlockXCnt { get; set; }
    public int BlockYCnt { get; set; }

    private Vector3 start;

    private List<GameObject> tebox = new List<GameObject>();


    void Start()
    {
        BlockXCnt = 10;
        BlockYCnt = 20;

        GetComponent<GridLayoutGroup>().constraintCount = BlockXCnt;

        Tetrisnew();

        
    }

    public void Tetrisnew()
    {
        for (int i = 0; i < BlockXCnt * BlockYCnt; i++)
        {
            tebox.Add(Instantiate(prefab, parent));
        }
        StartCoroutine(Tetrisoff());
    }

    IEnumerator Tetrisoff()
    {
        yield return new WaitForSeconds(0.02f);
        GetComponent<GridLayoutGroup>().enabled = false;
        start = tebox[BlockXCnt / 2].transform.localPosition;
        tar.localPosition = start;
    }    
}
