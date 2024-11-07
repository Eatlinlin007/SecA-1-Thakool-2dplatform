using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy,IShootable
{
    float attackRange;
    public float AttackRange { get { return attackRange; } set { attackRange = value; } }
    public Player player;

    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform SpawnPoint { get; set; }

    public float bulletWaitTime { get; set; }

      public float bulletTimer { get; set; }


     void Start()
    {
        Init(100);
        bulletWaitTime = 0.0f;
        bulletTimer = 5.0f;
        DamageHit = 30;
        AttackRange = 8;
        player = GameObject.FindObjectOfType<Player>();
    }

    private void FixedUpdate()
    {
        bulletWaitTime += Time.fixedDeltaTime;
        Behaviour();
    }
    public override void Behaviour()
    {
        Vector2 distance = player.transform.position - transform.position;  

        if (distance.magnitude <= attackRange)
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if (bulletWaitTime >= bulletTimer) 
        {
            anim.SetTrigger("Shoot");
            GameObject obj = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
            Rock rock = obj.GetComponent<Rock>();
            rock.Init(20, this);

            bulletWaitTime = 0;
        }
    }
}
