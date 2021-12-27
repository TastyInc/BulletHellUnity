using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool ppInstance;

    [SerializeField]
    private GameObject pooledProjectile;
    private bool notEnoughProjectilesInPool = true;

    private List<GameObject> projectiles;

    private void Awake()
    {
        ppInstance = this;
    }

    private void Start()
    {
        projectiles = new List<GameObject>();
    }

    public GameObject GetProjectile()
    {
        if (projectiles.Count > 0) {
            for (int i = 0; i < projectiles.Count; i++) {
                if (!projectiles[i].activeInHierarchy) {
                    return projectiles[i];
                }
            }
        }

        if (notEnoughProjectilesInPool) {
            GameObject proj = Instantiate(pooledProjectile);
            proj.SetActive(false);
            projectiles.Add(proj);
            return proj;
        }

        return null;
    }
}
