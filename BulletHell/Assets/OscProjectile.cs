using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscProjectile : Projectile
{

    public override void SetSpeed()
    {
        base.SetSpeed();
        moveSpeed = 10f;
    }

    public override void translateProj()
    {
        base.translateProj();
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);

    }

    public override void SetMoveDir(Vector2 dir)
    {
        moveDir = dir;
    }
}
