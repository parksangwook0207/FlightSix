using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Mine : MonoBehaviour
{
    [SerializeField] private NewMine prefab;
    [SerializeField] private Transform parent;

    int[,] map;

    int size = 5;
    // Start is called before the first frame update
    void Start()
    {
        map = new int[size, size];
        int[] tempMap = new int [size *size];
        for (int i = 0; i < size; i++)
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
            for (int j = 0; j < size; j++)
            {
                NewMine m = Instantiate(prefab, parent);
                m.Init(map[i, j]);
            }
        }     
    }

   void FindMine(int x, int y)
    {
        for (int i = x-1; i <= x+1; i++)
        {
            if (i < 0 ||i >= size)
            {
                continue;
            }
            for (int j = y-1; j <= y+1; j++)
            {
                if (j < 0 || i >= size)
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
}
