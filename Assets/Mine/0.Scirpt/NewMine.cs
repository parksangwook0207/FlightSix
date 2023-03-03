using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMine : MonoBehaviour
{
    [SerializeField] private Image mineImage;
    [SerializeField] private TMPro.TMP_Text numText;
    [SerializeField] private Image panel;

    int val, x, y;
    public void Init(int val, int x, int y)
    {
        this.val = val;
        this.x = x;
        this.y = y;

        switch (val)
        {
            case -1:
                mineImage.gameObject.SetActive(true);
                numText.gameObject.SetActive(false);
                break;
            case 0:
                mineImage.gameObject.SetActive(false);
                numText.gameObject.SetActive(true);
                numText.text = string.Empty;
                break;
            default:
                mineImage.gameObject.SetActive(false);
                numText.gameObject.SetActive(true);
                numText.text = val.ToString();
                break;


        }
    }

    public void OnPanelOpen()
    {
        GetComponent<Button>().interactable = false;
        panel.gameObject.SetActive(false);
        Mine cont = FindAnyObjectByType<Mine>();
        if (val == 0)
        {
            FindAnyObjectByType<Mine>().AutoOpen(x, y);
        }
        else if (val == -1)
        {
            FindAnyObjectByType<Mine>().ShowOverPancl();
        }

        cont.Clpan();
    }

    public void Open()
    {
        panel.gameObject.SetActive(false);
    }
}

