using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MineScChange : MonoBehaviour
{
    public void OnYes()
    {
        SceneManager.LoadScene("GMMine");
        Debug.Log("�����մϴ�");
    }

    public void OnNoplay()
    {
        SceneManager.LoadScene("GMStart");
        Debug.Log("����մϴ�");
    }
}
