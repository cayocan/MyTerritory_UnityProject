using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {
    public int lifes = 1;

    public NavMeshAgent navigation;
    public Animator anim;
    public Collider collisor;


    bool dead;

	// Update is called once per frame
	void Update () {
        if (!dead)
        {
            ChaseSomething(PlayerManager.instance.transform);
        }    
	}

    void ChaseSomething(Transform something)
    {
        try
        {
            navigation.SetDestination(something.position);
        }
        catch (Exception)
        {}   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            this.lifes -= 1;
        }

        if (lifes <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("isDead");
        dead = true;
        navigation.Stop();
        collisor.enabled = false;
    }

    void DestroyAfterSink()
    {
        Destroy(gameObject);
    }
}
