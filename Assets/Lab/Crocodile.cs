using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy,IShootable
{
    [SerializeField] private float attackRange;
    [SerializeField] private Player player;

    [field: SerializeField]
     GameObject bullet;
    public GameObject Bullet {  get { return bullet; } set { bullet = value; } }

    [field: SerializeField]
    Transform spawnPoint;
    public Transform SpawnPoint { get { return spawnPoint; } set { spawnPoint = value; } }

      public float WaitTime { get; set; }

      public float ReloadTimer { get; set; }


    private void Start()
    {
        Init(100);
    }

    private void Update()
    {
        ReloadTimer -= Time.deltaTime;

        Behaviour();

        if (ReloadTimer < 0)
        {
            ReloadTimer = WaitTime;
        }
    }
    public override void Behaviour()
    {
        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;

        if (distance < attackRange)
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if (WaitTime >= ReloadTimer) 
        {
            GameObject obj = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
            WaitTime = 0;
        }
    }
}
