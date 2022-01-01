using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour
{

    public static BulletPool ppInstance;

    public GameObject bulletPrefab;
    private bool notEnoughBulletsInPool = true;

    private List<GameObject> pool;

    private void Awake()
    {
        ppInstance = this;
    }

    private void Start()
    {
        pool = new List<GameObject>();

    }

    public GameObject GetBullet()
    {

        if (pool.Count > 0)
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].activeInHierarchy)
                {
                    return pool[i];
                }
            }
        }

        if (notEnoughBulletsInPool)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pool.Add(bullet);
            return bullet;
        }

        return null;
    }

}
