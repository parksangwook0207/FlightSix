using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCon : MonoBehaviour
{
    public static ItemCon Instace;

    [SerializeField] private List<Item> items;
    [SerializeField] private Transform parent;




    void Awake()
    {
        Instace = this;
    }

    /// <summary>
    ///  아이템드랍 0 폭탄 1 파워 2 코인
    /// </summary>
    /// <param name="trans"></param>
    public void Spwan(Transform trans = null)
    {
        int rand = Random.Range(0, 100);

        

        // 조건 ? 참 : 거짓
        int itemIndex = rand <= 3 ? 0 : rand <= 10 ? 1 : 2;
        itemIndex = 1;

        if (trans != null)
        {
            Item item = Instantiate(items[itemIndex], trans);
            item.transform.SetParent(parent);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
