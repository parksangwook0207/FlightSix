using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 5 x 5 생성 ㅇ
/// 지뢰생성
/// 지뢰에 가까울수록 숫자표현
/// </summary>
public class MthgSci : MonoBehaviour
{
    public int height = 5, width = 5;
    public GameObject Mine;
    private GameObject[,] MineMap;
    

    [SerializeField] private Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        MineMap = new GameObject[width, height];
        Create();
    }

    void Create() // 생성하는 곳
    {
        // 생성코드
        int starX = -width / 2;
        int starY = -height / 2;

        for (int i = 0; i < height; i++)
        {
            for (int o = 0; o < width; o++)
            {
                Vector3 pos = new Vector3(starX + o, starY + i, 0);
                GameObject min = Instantiate<GameObject>(Mine, pos, Quaternion.identity);
                min.name = (i * 5 + o).ToString();

                MineMap[i, o] = min;

                min.transform.SetParent(parent);
            }

        }
    }
    void MineCreate()
    {
        
    }




}
