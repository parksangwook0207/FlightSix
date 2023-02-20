using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public float speed;
    public float hp;
    public bool isBoss;
    public float rotZ;
    public int paIdx;
    public bool isRot;

}

public abstract class Enemy : MonoBehaviour
{
    public EnemyData ed = new EnemyData();
    public List<Transform> fireTrans;
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
        ATTPatten();


    }

    int fireIndex = 0;
    private void ATTPatten()
    {
        switch (ed.paIdx)
        {
            case 0:
                
                
                Vector2 vec = fireTrans[fireIndex].position - player.transform.position;
                float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
                fireTrans[fireIndex].rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

                
                if (ed.paIdx == 0)
                {
                    if (player != null)
                    {
                        
                        testTime += Time.deltaTime;
                        if (Random.Range(0, 20) < 100)
                        {
                            PattenChange();
                        }
                        fireIndex++;
                        if (fireTrans.Count-1 <= fireIndex)
                        {
                            fireIndex = 0;
                        }
                    }
                }
                break;
            case 1:
                testTime += Time.deltaTime;
                if (testTime > 0.2f)
                {
                    transform.GetChild(1).transform.rotation = Quaternion.Euler(0f, 0f, ed.rotZ);
                    ed.rotZ += 1f;
                    testTime += Time.deltaTime;
                    if (testTime > 3f)
                    {
                        EnemyBullet bullet = Instantiate(eBullet, fireTrans[fireIndex]);
                        bullet.transform.SetParent(parent);
                        testTime = 0;
                    }
                }
                break;
            case 2:
                testTime += Time.deltaTime;
                if (testTime > 0.2f)
                {
                    if (ed.isRot)
                    {
                        if (ed.rotZ >= 60)
                        {
                            ed.isRot = false;
                        }
                        ed.rotZ -= 10f;
                    }
                    else
                    {
                        if (ed.rotZ <= -60)
                        {
                            ed.isRot = true;
                            if (Random.Range(0, 100) < 20)
                            {
                                PattenChange();
                            }
                        }
                        ed.rotZ += 10f;
                    }
                    transform.GetChild(1).transform.rotation = Quaternion.Euler(0f, 0f, ed.rotZ);

                    EnemyBullet bullet = Instantiate(eBullet, fireTrans[fireIndex]);
                    bullet.transform.SetParent(parent);
                    testTime = 0;
                    

                }
                break;


        }





    }

    private void PattenChange()
    {
        ed.rotZ = 0;
        ed.isRot = false;
        ed.paIdx = Random.Range(0, 3);
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