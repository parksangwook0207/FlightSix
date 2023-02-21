using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiCon : MonoBehaviour
{
    public static UiCon Instance;
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] PlayBoom pb;

    int score = 0;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreTxt.text = score.ToString();
        }
    }
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    public void OnFireBoom()
    {
        Debug.Log("���Ĺ�ư�� ���� �Ǿ����ϴ�.");
        Instantiate(pb);
    }

}
