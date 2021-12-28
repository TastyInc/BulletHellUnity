using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpiral : MonoBehaviour
{
    [SerializeField]
    private int spiralAmount = 1;


    [SerializeField]
    private float shootingSpeed = 0.2f, angleStep = 5f;

    private Vector2 projMoveDir;
    private float currentAngle = 90f;

    void Start()
    {
        //InvokeRepeating("Fire", 0f, shootingSpeed);

        CreateArc ca = new CreateArc();
        ca.projAmount = 3;
        ca.projType = 1;
        ca.Init(1);
        

        //ca.pro

        
        //gameObject.AddComponent<CreateArc>();
        
        //CreateArc ca = new CreateArc();
    }

    private void Fire()
    {


        for (int i = 0; i < spiralAmount + 1; i++)
        {
            float projDirX = transform.position.x + Mathf.Sin(currentAngle * Mathf.PI / 180f);
            float projDirY = transform.position.y + Mathf.Cos(currentAngle * Mathf.PI / 180f);

            Vector3 projMoveVector = new Vector3(projDirX, projDirY, 0f);
            Vector2 projDir = (projMoveVector - transform.position).normalized;

            //GameObject proj = ProjectilePool.ppInstance.GetProjectile();
            //proj.transform.position = transform.position;
            ////proj.transform.rotation = transform.rotation;
            //proj.SetActive(true);
            //proj.GetComponent<Projectile>().SetMoveDir(projDir);

            

        }

        currentAngle += angleStep;
    }

}
