using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxHp = 400;

    public HealthBar healthBar;

    private int currentHp;
    private Rigidbody2D rb;
    private Vector2 movement = new Vector2(0,0);
    private float rotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        healthBar.SetMaxHealth(maxHp);

        rb = gameObject.GetComponent<Rigidbody2D>();

        FunctionTimer.Create(() => NewMovement(new Vector2(0, -1.5f), 1), 0);
        FunctionTimer.Create(() => NewMovement(new Vector2(0, 0), 7.7f), 7.2f);
        FunctionTimer.Create(() => NewMovement(new Vector2(1.5f, -0.5f), 1), 7.5f);
        FunctionTimer.Create(() => NewMovement(new Vector2(1.5f, -0.5f), -1.2f), 23.5f);
        FunctionTimer.Create(() => NewMovement(new Vector2(-3.5f, -0.5f), 1), 38.5f);

        FunctionTimer.Create(() => NewMovement(new Vector2(0, -4f), 2), 68.5f);
        FunctionTimer.Create(() => NewMovement(new Vector2(5f, 0), 3), 80);
        FunctionTimer.Create(() => NewMovement(new Vector2(1f, 3f), 3), 100);
    }

    void NewMovement(Vector2 mov, float rotate) {
        movement = mov;
        rotation = rotate;
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + movement * Time.deltaTime);
        rb.MoveRotation(rb.rotation + rotation);
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
