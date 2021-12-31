using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    public Material material;
    public Sprite texture;
    public Boss boss;

    // Start is called before the first frame update
    void Start()
    {
        CreateNewParticleSpawner(16, 0.15f, 10, 16, 0.3f, Color.black, 7, 7.5f, 0);
        CreateNewParticleSpawner(10, 0.2f, 10, 8, 0.5f, Color.black, 7.5f, 36 , 3);
        CreateNewParticleSpawner(8, 0.48f, 10, 12, 0.6f, new Color(0.5f, 0.5f, 0.5f, 0.3f), 23.5f, 36, 3, false);
        CreateNewParticleSpawner(8, 0.48f, 10, 24, 0.4f, Color.black, 38.5f, 51, 3);
    }

    bool CreateNewParticleSpawner(float speed, float firerate, float lifetime, int numberOfCols, float size, Color col, float delay, float end, float destroyDelay, bool bossRot = true, bool bossPos = true) {

        GameObject go = new GameObject("Particle Spawner");
        go.transform.parent = gameObject.transform;
        go.transform.localPosition = gameObject.transform.localPosition;
        ParticleSpawner spawner = go.AddComponent<ParticleSpawner>();
        
        spawner.speed = speed;
        spawner.firerate = firerate;
        spawner.lifetime = lifetime;
        spawner.numberCols = numberOfCols;
        spawner.size = size;
        spawner.material = material;
        spawner.bossTransform = boss.transform;
        spawner.texture = texture;
        spawner.color = col;
        spawner.followBoss = bossPos;
        spawner.rotateWithBoss = bossRot;
        spawner.endEmittingTime = end - delay;

        spawner.Invoke("Summon", delay);

        return true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
