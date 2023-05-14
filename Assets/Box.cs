using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Health health;
    private void Awake()
    {
        health = GetComponent<Health>();
        health.onDamage.AddListener(OnDamage);
        health.onDeath.AddListener(OnDeath);
    }

    private void OnDamage()
    {
        print("moves a box a little bit");
    }
    private void OnDeath()
    {
        print("spawns many rigidbody peaces");
    }
}
