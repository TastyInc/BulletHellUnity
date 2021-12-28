using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateArc : MonoBehaviour
{
    public int projAmount = 1;
    public int projType = 1;
    public float startAngle = 90f, endAngle = 270f;

    private Vector2 projMoveDir;

    public void Init(int projId)
    {
        //Fire(projId);
    }

    void Start()
    {
        //InvokeRepeating("Fire", 0f, 2f);
    }

    private void Fire(int projId) {
        float angleStep = (endAngle - startAngle) / projAmount;
        float angle = startAngle;

        for (int i = 0; i < projAmount + 1; i++) {
            float projDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float projDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 projMoveVector = new Vector3(projDirX, projDirY, 0f);
            Vector2 projDir = (projMoveVector - transform.position).normalized;

            GameObject proj = ProjectilePool.ppInstance.GetProjectile(projId);
            proj.transform.position = transform.position;
            //proj.transform.rotation = transform.rotation;
            proj.SetActive(true);
            proj.GetComponent<Projectile>().SetMoveDir(projDir);


            angle += angleStep;

        }


    }

}
