using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Vector2 moveDir;
    private float moveSpeed;
    private int projType;

    private OscProj op;

    void Start()
    {
        moveSpeed = 10f;
    }


    private void FixedUpdate()
    {
        switch (projType) {
            case 1:
                transform.Translate(moveDir * moveSpeed * Time.fixedDeltaTime);
                break;
            case 2:
                transform.Translate(op.GetMoveDir(moveDir) * moveSpeed * Time.fixedDeltaTime);
                break;
        }

    }

    public void SetProjType(int type) {
        this.projType = type;

        switch (projType)
        {
            case 2:
                op = new OscProj();
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }
    }

    public void SetMoveDir(Vector2 dir)
    {
        this.moveDir = dir;
    }

    public void SetMoveSpeed(float speed)
    {
        this.moveSpeed = speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
