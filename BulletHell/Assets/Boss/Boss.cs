using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxHp = 400;

    public BossHealthBar healthBar;

    private int currentHp;
    private Rigidbody2D rb;
    private Vector2 movement = new Vector2(0,0);
    private float rotation = 0;

    private BossAIs ai;
    //private ProjectileHandler ph;


    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        healthBar.SetMaxHealth(maxHp);

        rb = gameObject.GetComponent<Rigidbody2D>();

        ai = new BossAIs();
        ai.Setup(this);
    }

    public void NewMovementAndRotation(Vector2 mov, float rotate) {
        movement = mov;
        rotation = rotate;
    }

    public void NewRotation(float rotate)
    {
        rotation = rotate;
    }

    public void NewMovement(Vector2 mov)
    {
        movement = mov;
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
