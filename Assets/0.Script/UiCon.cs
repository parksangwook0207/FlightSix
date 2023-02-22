using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiCon : MonoBehaviour
{
    public static UiCon Instance;
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] PlayBoom pb;

    [SerializeField] private List<Image> sb;

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
        Debug.Log("폭파버튼이 감지 되었습니다.");
        Instantiate(pb);
    }

    public void LifeChange(int life)
    {
        foreach (var item in sb)
        {
            item.gameObject.SetActive(false);
        }
        for (int i = 0; i < life; i++)
        {
            sb[i].gameObject.SetActive(true);
        }
    }
}
