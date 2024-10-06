using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
             damage = value; 
        }
    }
    
     protected string owner;
    public void OnHitWith(Character Hit)
    {
        
    }
    public abstract void Move();
    public int GetShootDirection()
    {
        return 1;
    }
}
