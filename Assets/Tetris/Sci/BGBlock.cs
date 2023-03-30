using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGBlock : MonoBehaviour
{
    // ÁÂÇ¥
    public bool Check { get; set; }

    public int X;
    public int Y;

    public TMPro.TMP_Text text;

    [SerializeField] bool isUICheck = true;


    // Update is called once per frame
    void Update()
    {
        if (isUICheck)
        {
            text.text = Check == true ? "0" : "X";
        }
        else
        {
            text.text = "";
        }
    }

   
}
