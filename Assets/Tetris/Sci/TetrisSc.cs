using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TetrisSc : MonoBehaviour
{
    // 이미지 프리팹 
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;

    // 블럭 프리팹
    [SerializeField] private GameObject prefabblock;
    [SerializeField] private Transform parentblock;

    


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
        // 처음 10 * 20 생성
        for (int i = 0; i < BlockXCnt * BlockYCnt; i++)
        {
            tebox.Add(Instantiate(prefab, parent));
        }
        StartCoroutine(Tetrisoff());
    }

    IEnumerator Tetrisoff()
    {    
        // 처음생성될 때 칸에 딱 맞게 떨어지는 코드(?)
        yield return new WaitForSeconds(0.2f);
        GetComponent<GridLayoutGroup>().enabled = false;

        CreateBlockT();
    }

    public void CreateBlockT()
    {
        GameObject pb = Instantiate(prefabblock, parentblock);
        start = tebox[BlockXCnt / 2].transform.localPosition;
        pb.transform.localPosition = start;
        ConManager.Instance.keyCont.block = pb;
        ConManager.Instance.keyCont.movePos = new Vector2(start.x, start.y);
    }
    
}
