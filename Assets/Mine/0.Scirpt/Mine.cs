using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Mine : MonoBehaviour
{
    [SerializeField] private NewMine prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject clpan;
    [SerializeField] private GameObject panel;

    [SerializeField] private GridLayoutGroup grid;

    int[,] map;

    [SerializeField] private int size = 5;
    [SerializeField] private int mineCnt = 1;

    private List<List<NewMine>> mineList = new List<List<NewMine>>();
    // Start is called before the first frame update
    void Start()
    {
        grid.constraintCount = size;

        map = new int[size, size];
        int[] tempMap = new int [size *size];
        for (int i = 0; i < mineCnt; i++)
        {
            tempMap[i] = -1;
        }

        for (int i = 0; i < size * size; i++)
        {
            tempMap = tempMap.OrderBy(x => Random.Range(0, i)).ToArray();
        }
        

        int count = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                map[i, j] = tempMap[count];
                count++;
            }
            
        }
        // 지뢰 찾는중
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (map[i, j] == -1)
                {
                    FindMine(i, j);
                }
            }
        }

        for (int i = 0; i < size; i++)
        {
            mineList.Add(new List<NewMine>()); // 생성코드
            for (int j = 0; j < size; j++)
            {
                NewMine m = Instantiate(prefab, parent);
                m.Init(map[i, j], i, j);
                mineList[i].Add(m);
            }
        }
    }

    // 예외처리
     void FindMine(int x, int y) // 꼭짓점 검사
    {
        for (int i = x - 1; i <= x + 1; i++)
        {
            if (i < 0 || i >= size)
            {
                continue;
            }
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (j < 0 || j >= size)
                {
                    continue;
                }
                if (map[i, j] == -1)
                {
                    continue;
                }
                map[i, j]++;
            }
        }
    }
    public void AutoOpen(int x, int y)
    {
        for (int i = x - 1; i <= x + 1; i++)
        {
            if (i < 0 || i >= size)
            {
                continue;
            }
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (j < 0 || j >= size)
                {
                    continue;
                }
                if (i == x && j == y)
                {
                    continue;
                }
                if (map[i, j] == 0)
                {
                    mineList[i][j].Open();
                    clickCnt++;
                }
            }
        }
    }

    public void ShowOverPancl() // 판넬 
    {
        panel.SetActive(true);
    }

    int clickCnt = 0;
    public void Clpan() // 판넬 
    {
        clickCnt++;
        int count = (size * size);

        if (count == mineCnt)
        {
            clpan.SetActive(true);
        }
    }
}
