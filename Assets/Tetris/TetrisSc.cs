using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TetrisSc : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;

    public int BlockXCnt { get; set; }
    public int BlockYCnt { get; set; }
    // Start is called before the first frame update




    void Start()
    {
        BlockXCnt = 10;
        BlockYCnt = 20;
        Tetris();
    }

    public void Tetris()
    {
        for (int i = 0; i < BlockXCnt * BlockYCnt; i++)
        {
            Instantiate(prefab, parent);
        }
    }
}
