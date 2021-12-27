using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Vector2 moveDir;
    protected float moveSpeed;

    void Start()
    {
        SetSpeed();
    }

    public virtual void SetSpeed()
    {
        Debug.LogError("No Speed set");
    }

    void Update()
    {
        translateProj();
    }

    public virtual void translateProj()
    {
        
    }

    public virtual void SetMoveDir(Vector2 dir)
    {
        moveDir = dir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
