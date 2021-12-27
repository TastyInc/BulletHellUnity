using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 moveDir;
    private float moveSpeed;

    void Start()
    {
        moveSpeed = 10f;
    }


    void Update()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }


    public virtual void SetMoveDir(Vector2 dir)
    {
        moveDir = dir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //int test = collision.gameObject.GetComponent<Bullet>().damage;

        gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
