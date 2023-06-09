using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// player - onDamage hp number decreases in UI, onDeath game restarts
// enemy - onDamage spawn blood particles, onDeath teleport to random location with full hp
// box - onDamage box moves a little, onDeath spawns 4-8 wooden planks with physics
public class Health : MonoBehaviour
{
    public int maxHp = 100;
    public int hp;

    public bool destroyOnDeath;

    public UnityEvent onDamage;
    public UnityEvent onDeath;
    public void Damage(int amount)
    {
        hp -= amount;
        onDamage.Invoke();
        if (hp <= 0) Die();
    }

    public void Die()
    {
        onDeath.Invoke();
        if(destroyOnDeath) Destroy(gameObject);
    }
}
