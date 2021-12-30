using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxHp = 400;

    public HealthBar healthBar;

    private int currentHp;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        healthBar.SetMaxHealth(maxHp);

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0.5f, 0);
        //rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation + 1);
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
