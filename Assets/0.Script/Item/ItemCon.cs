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
    ///  ?????۵??? 0 ??ź 1 ?Ŀ? 2 ????
    /// </summary>
    /// <param name="trans"></param>
    public void Spwan(Transform trans = null)
    {
        int rand = Random.Range(0, 100);

        // ???? ? ?? : ????
        int itemIndex =  rand <= 75 ? 0 : rand <= 85 ? 1 : rand <= 95 ? 2 : 3;  
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
