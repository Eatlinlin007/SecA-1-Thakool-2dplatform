using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Weapon
{
    [SerializeField] private float speed;

    void Start()
    {
        Damage = 30;
        speed = 4.0f* GetShootDirection();
        Move();
    }

    private void FixedUpdate()
    {
        Move();
    }
    public override void Move()
    {
        //Debug.Log("Banana moves with constant speed using Transform ");
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }
    public override void OnHitWith(Character character)
    {
        if (character is Enemy)
        {
            character.TakeDamage(this.Damage);
        }
    }
}
