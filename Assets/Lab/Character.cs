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
    public HealthBar healthBar;

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
        //Debug.Log($"{this.name} took {damage} damage; Remaining Health: {this.Health}");
        healthBar.UpdateHealthBar(health);
        
        IsDead();
    }
    public virtual void Init(int newHealth)
    {
        Health = newHealth;
        healthBar.SetMaxHealth(newHealth);

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

}
