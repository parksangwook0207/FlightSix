using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void OnGameScene()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("³Ñ¾î°©´Ï´Ù");
    }
    public void OnMainScene()
    {
        SceneManager.LoadScene("Main");
        Debug.Log("³Ñ¾î°©´Ï´Ù");
    }
}
