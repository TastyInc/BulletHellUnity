using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{

    public static ProjectilePool ppInstance;

    public enum ProjectileTypes
    {
        Normal = 0,
        Bullet = 1
    }

    [SerializeField]
    private GameObject pooledProjectile;
    private bool notEnoughProjectilesInPool = true;

    private List<GameObject>[] pool;
    private int pTypeCount;

    private void Awake()
    {
        ppInstance = this;
    }

    private void Start()
    {
        pTypeCount = Enum.GetNames(typeof(ProjectileTypes)).Length;
        pool = new List<GameObject>[pTypeCount];

        for(int i = 0; i < pool.Count(); i++) {
            pool[i] = new List<GameObject>();
        }

    }

    public GameObject GetProjectile(int id)
    {

        if (pool[id].Count > 0)
        {
            for (int i = 0; i < pool[id].Count; i++)
            {
                if (!pool[id][i].activeInHierarchy)
                {
                    return pool[id][i];
                }
            }
        }
 
        if (notEnoughProjectilesInPool)
        {
            GameObject proj = Instantiate(pooledProjectile);
            proj.SetActive(false);
            pool[id].Add(proj);
            return proj;
        }

        return null;
    }

}
