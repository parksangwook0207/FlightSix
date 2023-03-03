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
        // Áö·Ú Ã£´ÂÁß
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
            mineList.Add(new List<NewMine>());
            for (int j = 0; j < size; j++)
            {
                NewMine m = Instantiate(prefab, parent);
                m.Init(map[i, j], i, j);
                mineList[i].Add(m);
            }
        }
    }

    // ¿¹¿ÜÃ³¸®
     void FindMine(int x, int y) // ²ÀÁþÁ¡ °Ë»ç
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

    public void ShowOverPancl() // ÆÇ³Ú 
    {
        panel.SetActive(true);
    }

    int clickCnt = 0;
    public void Clpan() // ÆÇ³Ú 
    {
        clickCnt++;
        int count = (size * size);

        if (count == mineCnt)
        {
            clpan.SetActive(true);
        }
    }
}
