using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager Instance;

    public KeyControll KeyCont;
    public BGController bgCont;
    public BlockController blockCont;

    private void Awake()
    {
        Instance = this;
    }
}
