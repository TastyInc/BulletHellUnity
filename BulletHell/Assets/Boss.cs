using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxHp = 400;
    public int currentHp;

    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        healthBar.SetMaxHealth(maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null) {
            int damage = collision.gameObject.GetComponent<Bullet>().damage;
            healthBar.SubtractHealth(damage);

            collision.gameObject.SetActive(false);
        }

    }
}
