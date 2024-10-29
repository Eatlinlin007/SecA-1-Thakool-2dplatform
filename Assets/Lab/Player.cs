using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character,IShootable
{
    float attackRange;
    public Player player;

    [field: SerializeField]
    GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }

    [field: SerializeField]
    Transform spawnPoint;
    public Transform SpawnPoint { get { return spawnPoint; } set { spawnPoint = value; } }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1")&& bulletWaitTime >= bulletTimer) 
        {
            Instantiate(bullet,SpawnPoint.position,Quaternion.identity);
        }
    }
    [field: SerializeField]
    public float bulletWaitTime { get; set; }
    [field: SerializeField]
    public float bulletTimer { get; set; }
    void Start()
    {
        Init(100);
        bulletWaitTime = 0.0f;
        bulletTimer = 1.0f;
    }

    void Update()
    {
        Shoot();
    }

    void FixeUpdate() 
    {
        bulletTimer += Time.fixedDeltaTime;
    }
}
