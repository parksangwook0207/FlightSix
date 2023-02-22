using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance;
    [SerializeField] private Transform parent;
    [SerializeField] private Enemy[] enemies;

    [SerializeField] private Transform eBullet;

    float delaySpawn = 100f;
    
    float nextDelay = 2f;

    

    [HideInInspector] public bool spawnStop = false;

    private void Awake()
    {
        Instance = this;
    }

    public int Stage { get; set; }
    
    public int SpawnCount { get; set; }

    public bool SpawnStop { get; set; }

    private void Start()
    {
        StageUp();
    }
    // Update is called once per frame
    void Update()
    {
        if (SpawnStop)
        {
            return;
        }
        if (SpawnCount != 0 && SpawnCount % (Stage * 5) == 0)
        {
            Enemy enemy = Instantiate(enemies[enemies.Length - 1], transform);

            enemy.SetParent(eBullet);
            enemy.transform.localPosition = Vector2.zero;
            enemy.transform.SetParent(parent);
            SpawnStop = true;
        }
        else
        {
            delaySpawn += Time.deltaTime;
            if (delaySpawn > nextDelay)
            {
                int rand = Random.Range(0, Stage);
                if (rand > enemies.Length - 1)
                {
                    rand = enemies.Length - 1;
                }
                Enemy enemy = Instantiate(enemies[rand], transform);
                enemy.SetParent(eBullet);
                enemy.transform.localPosition = new Vector2(Random.Range(-2.5f, 2.5f), 0f);
                enemy.transform.SetParent(parent);

                delaySpawn = 0f;
                SpawnCount++;
                nextDelay = Random.Range(2, 5);

            }


        }

    }
    public void StageUp()
    {
        Stage++;
        SpawnCount = 0;
        SpawnStop = false;
    }
}
