using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Direction
    {
        Center = 0,
        Left,
        Right
    }
    private Direction dir = Direction.Center;
    [SerializeField] private List<Sprite> centerSp;
    [SerializeField] private List<Sprite> leftSp;
    [SerializeField] private List<Sprite> rightSp;

    [SerializeField] private Transform parent;
    [SerializeField] private GameObject pbullet;

    [SerializeField] private List<SubPlayer> follows;


    [SerializeField] private float power = 0f;
    [HideInInspector] public int boom = 0;

    private SpriteAnimation sa;

    private float speed = 3f;
    private int bulletLevel = 0;
    private int life = 3;
    

    private int followIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        sa = GetComponent<SpriteAnimation>();
        sa.SetSprite(centerSp, 0.2f);

        UiCon.Instance.LifeChange(life);
        UiCon.Instance.BoomChange(boom);


        InvokeRepeating("PlayBu", 1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (life < 0)
        {
            return;
        }
        // 캐릭터 이동범위 지정
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float clampX = Mathf.Clamp(transform.position.x + x, -2.28f, 2.28f);

        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        float clampY = Mathf.Clamp(transform.position.y + y, -4.48f, 4.48f);

        transform.position = new Vector2(clampX, clampY);


        // 방향에 따른 이미지 변경
        if (x < 0 && dir != Direction.Left)
        {
            dir = Direction.Left;
            sa.SetSprite(leftSp[0], leftSp, 0.2f);
        }
        else if (x > 0 && dir != Direction.Right)
        {
            dir = Direction.Right;
            sa.SetSprite(rightSp[0], rightSp, 0.2f);
        }
        else if (x == 0 && dir != Direction.Center)
        {
            dir = Direction.Center;
            sa.SetSprite(centerSp[0], centerSp, 0.2f);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (boom > 0)
            {
                UiCon.Instance.OnFireBoom();
            }
        }
    }

    void PlayBu()
    {
        GameObject obj = Instantiate(pbullet, transform.GetChild(0));
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            PlayBullet pb = obj.transform.GetChild(i).GetComponent<PlayBullet>();
            pb.SetPower(power);
            //pb.transform.localPosition = new Vector2(0f, 0.7f);
            

        }
        obj.transform.SetParent(parent);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Item>())
        {
            collision.GetComponent<Item>().Get();
            if (collision.GetComponent<Power>())
            {
                bulletLevel++;
                if (bulletLevel > 3)
                {
                    bulletLevel = 3;
                    UiCon.Instance.Score += 50;
                }
                pbullet = Resources.Load<GameObject>($"pBullet {bulletLevel}");
            }
            else if (collision.GetComponent<Boom>())
            {
                boom++;
                if (boom > 1)
                {
                    boom = 2;
                    UiCon.Instance.BoomChange(boom);
                }
            }
            else if (collision.GetComponent<Follow>())
            {
                if (followIdx < follows.Count)
                {
                    follows[followIdx].gameObject.SetActive(true);
                    followIdx++;
                }


            
            }
        }
        else if (collision.GetComponent<EnemyBullet>())
        {
            life--;
            UiCon.Instance.LifeChange(life);
            if (life > 0)
            {
                StartCoroutine("DieAnimtion");
            }
            else
            {
                CancelInvoke("PlayBu");
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0);

                Time.timeScale = 0;
                UiCon.Instance.Popup(true);
            }

        }
        Destroy(collision.gameObject);
    }

    // 비행기가 깎일 때
    IEnumerator DieAnimtion()
    {
        CancelInvoke("PlayBu");
        GetComponent<BoxCollider2D>().enabled = false;
        for (int i = 0; i < 5; i++)
        {
            GetComponent<BoxCollider2D>().enabled = false; ;
            yield return new WaitForSeconds(0.2f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.7f);
        }
        InvokeRepeating("PlayBu", 1f, 0.2f);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        GetComponent<BoxCollider2D>().enabled = true;
        
    }
}
