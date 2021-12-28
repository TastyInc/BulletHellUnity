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
        Lingering = 1,
        Homing = 2,
        Oscillating = 3,
        Rotating = 4
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
