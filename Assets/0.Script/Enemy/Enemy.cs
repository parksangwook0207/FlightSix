using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public float speed;
    public float hp;
    public bool isBoss;
}

public abstract class Enemy : MonoBehaviour
{
    public EnemyData ed = new EnemyData();
    public Transform fireTrans;
    public EnemyBullet eBullet;

    public List<Sprite> explosionSprite;
    public List<Sprite> noranSprite;
   
    public Sprite hitSprite;

    protected private Player player;
    protected Transform parent;


    public abstract void Init();

    public virtual void SetParent(Transform parent)
    {
        this.parent = parent;
    }

    public virtual void Move()
    {
       if (ed.isBoss)
        {
            if (transform.localPosition.y >= 3)
            {
                if (ed.hp > 0)
                {
                    transform.Translate(new Vector2(0f, -(Time.deltaTime * ed.speed)));
                }
            }
        }
       else
        {
            if (ed.hp > 0)
            {
                transform.Translate(new Vector2(0f, -(Time.deltaTime * ed.speed)));
            }
        }
    }
    float testTime = 0;

    // Update is called once per frame
    void Update()
    {
        Move();

        if (player != null)
        {
            Vector2 vec = fireTrans.position - player.transform.position;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            fireTrans.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        testTime += Time.deltaTime;
        if (testTime > 2f)
        {
            EnemyBullet bullet = Instantiate(eBullet, fireTrans);
            bullet.transform.SetParent(parent);
            testTime = 0;
        }
    }

    // ÆøÆÄ ÀÎÆÑÆ®
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayBullet>())
        {
            ed.hp -= collision.gameObject.GetComponent<PlayBullet>().power;

            if (ed.hp <= 0)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteAnimation>().SetSprite(explosionSprite, 0.1f, Die);

            }
            else
            {
                GetComponent<SpriteAnimation>().SetSprite(hitSprite, noranSprite, 0.1f);
            }
        }
        Destroy(collision.gameObject);
    }
    public void Die()
    {
        ItemCon.Instace.Spwan(transform);
        Destroy(gameObject);
    }

    
}
