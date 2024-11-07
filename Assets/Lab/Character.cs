using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    public Animator anim;
    public Rigidbody2D rb;

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject); 
            return true;
        }
        else return false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{this.name} took {damage} damage; Remaining Health: {this.Health}");

        IsDead();
    }
    public void Init(int newHealth)
    {
        Health = newHealth;
        
    }
}
