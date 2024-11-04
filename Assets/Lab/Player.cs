using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character,IShootable
{
    float attackRange;
    public Player player;
    [field: SerializeField] public GameObject Bullet { get; set; }

    [field: SerializeField] public Transform SpawnPoint { get; set; }

    [field: SerializeField]
    public float WaitTime { get; set; }
    [field: SerializeField]
    public float ReloadTimer { get; set; }
    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && (WaitTime >= ReloadTimer))
        {
            Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
            WaitTime = 0;
        }
    }
    void Start()
    {
        Init(100);
        WaitTime = 0.0f;
       // ReloadTimer = 1.0f;
    }

    void Update()
    {
        Shoot();
    }

    void FixeUpdate() 
    {
        WaitTime += Time.fixedDeltaTime;
    }
}
