using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 3;
    public float hpRegen = 5;
    public ParticleSystem damageParticles = null;


    private int health;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ReplenishHealthOverTime", hpRegen, hpRegen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("collision");
        TakeDamage();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO Checken was genau, hier kommt auch rand, sollte nichts machen :/

        //Debug.Log("CAKJSF LKASF");
        //TakeDamage();
    }

    void ReplenishHealthOverTime() {
        if (health < maxHealth) {
            health++;
        }
    }

    void TakeDamage()
    {
        if (damageParticles != null) {
            damageParticles.Play();
        }
        
        health--;

        if (health <= 0) { 
            //ded
        }
    }
}
