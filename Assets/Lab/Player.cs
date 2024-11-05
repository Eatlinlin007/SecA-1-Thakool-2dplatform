using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character,IShootable
{
    float attackRange;

    [field: SerializeField] public GameObject Bullet { get; set; }

    [field: SerializeField] public Transform SpawnPoint { get; set; }


    [field: SerializeField] public float bulletWaitTime { get; set; }

    [field: SerializeField] public float bulletTimer { get; set; }
    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && (bulletWaitTime >= bulletTimer)) //ReloadTimer WaitTime
        {
            GameObject obj = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
            Banana banana = obj.GetComponent<Banana>();
            banana.Init(10,this);
            
            
        }
    }
    void Start()
    {
        Init(100);
        bulletWaitTime = 0.0f;
        bulletTimer = 2.0f;
    }

    void Update()
    {
        Shoot();
    }

    private void FixedUpdate() 
    {
        bulletWaitTime += Time.fixedDeltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null) 
        {
            OnHitWith(enemy);
        }
    }
    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }
}
