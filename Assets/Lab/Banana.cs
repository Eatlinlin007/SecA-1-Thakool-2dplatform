using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Weapon
{
    [SerializeField] private float speed;

    void Start()
    {
        Damage = 30;
        speed = 4;
        Move();
    }
    public override void Move()
    {
        Debug.Log("Banana moves with constant speed using Transform ");
    }
    public override void OnHitWith(Character camelCase)
    {

    }
}
