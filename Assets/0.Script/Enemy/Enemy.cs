using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public float speed;
    public float hp;
}

public abstract class Enemy : MonoBehaviour
{
    public EnemyData ed = new EnemyData();
    public List<Sprite> explosionSprite;
    public List<Sprite> noranSprite;
    public Sprite hitSprite;
    public abstract void Init();

    public virtual void Move()
    {
        if(ed.hp > 0)
        transform.Translate(new Vector2(0f, -(Time.deltaTime * ed.speed)));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // ÆøÆÄ ÀÎÆÑÆ®
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        

        if (collision.gameObject.GetComponent<PlayBullet>())
        {
            ed.hp -= collision.gameObject.GetComponent<PlayBullet>().power;

            if (ed.hp <= 0)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteAnimation>().SetSprite(explosionSprite, 0.03f, Die);

            }
            else
            {
                GetComponent<SpriteAnimation>().SetSprite(hitSprite, noranSprite, 0.1f);
            }
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
