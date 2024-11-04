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

    public float WaitTime { get; set; }

      public float ReloadTimer { get; set; }


    private void Start()
    {
        Init(100);
        WaitTime = 0.0f;
        ReloadTimer = 5.0f;
        DamageHit = 30;
        AttackRange = 6;
        player = GameObject.FindObjectOfType<Player>();
    }

     void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
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
        if (WaitTime >= ReloadTimer) 
        {
            anim.SetTrigger("Shoot");
            GameObject obj = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
            WaitTime = 0;
        }
    }
}
