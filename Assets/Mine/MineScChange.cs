using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MineScChange : MonoBehaviour
{
    public void OnYes()
    {
        SceneManager.LoadScene("GMMine");
        Debug.Log("시작합니다");
    }

    public void OnNoplay()
    {
        SceneManager.LoadScene("GMStart");
        Debug.Log("대기합니다");
    }
}
