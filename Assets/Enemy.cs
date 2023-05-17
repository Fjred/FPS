using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// enemy - onDamage spawn blood particles, onDeath teleport to random location with full hp
public class Enemy : MonoBehaviour
{
    private Health health;

    public ParticleSystem blood;

    private NavMeshAgent agent;

    public Transform target;
    private void Awake()
    {
        health = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();

        health.onDamage.AddListener(OnDamage);
        health.onDeath.AddListener(OnDeath);
    }
     
    private void Update()
    {
        agent.destination = target.position;
    }
    private void OnDamage()
    {
        print("Ouch");
        //ParticleSystem damaged = Instantiate(blood, transform.position, Quaternion.identity);

        //damaged.Play();
    }    
    private void OnDeath()
    {
        print("Rip");
    }
}
