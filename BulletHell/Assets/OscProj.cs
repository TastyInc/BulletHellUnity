using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscProj : MonoBehaviour
{
    private Vector2 moveDir;
    private float moveSpeed;
    private int projType;


    public void SetProjType(int type) {
        this.projType = type;
    }

    public Vector2 GetMoveDir(Vector2 dir)
    {
        return dir;
    }

}
