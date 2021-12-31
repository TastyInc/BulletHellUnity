using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 3;
    public float hpRegen = 5;

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
        Debug.Log("CAKJSF LKASF");
        TakeDamage();
    }

    void ReplenishHealthOverTime() {
        if (health < maxHealth) {
            health++;
        }
    }

    void TakeDamage()
    {
        health--;

        if (health <= 0) { 
            //ded
        }
    }
}
