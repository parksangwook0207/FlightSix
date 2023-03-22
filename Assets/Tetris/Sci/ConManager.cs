using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConManager : MonoBehaviour
{
    public static ConManager Instance;
    public KeyCon keyCont;

    private void Awake()
    {
        Instance = this;
    }
}
