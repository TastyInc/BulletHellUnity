using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    public Material material;
    public Sprite texture;
    public Boss boss;
    public ParticleSystem psPrefab;

    // Start is called before the first frame update
    void Start()
    {

        CreateNewParticleSpawner(16, 0.1f, 10, 16, 0.3f, new Color(0.7f, 0.7f, 0.7f), 7.2f, 7.7f, 1, 300);
        CreateNewParticleSpawner(10, 0.2f, 10, 9, 0.5f, new Color(0.3f, 0.3f, 0.3f), 7.5f, 36.5f , 5, 60);
        CreateNewParticleSpawner(8, 0.48f, 10, 12, 0.6f, new Color(0.5f, 0.5f, 0.5f, 0.3f), 23.5f, 36.5f, 5, -25);
        CreateNewParticleSpawner(6, 0.48f, 10, 30, 0.4f, Color.black, 38.5f, 51, 3, 120);
        
        CreateNewParticleSpawner(12, 0.2f, 10, 6, 0.3f, new Color(0.5f, 0.5f, 0.5f), 54, 67, 5, 120);
        CreateNewParticleSpawner(6, 0.5f, 30, 9, 0.8f, new Color(0.3f, 0.3f, 0.3f), 53, 64, 10, 60, false, new Vector2(6, 16));
        
        CreateNewParticleSpawner(16, 0.48f, 10, 16, 0.4f, new Color(0.4f, 0.4f, 0.4f), 69.5f, 100, 5, 25);
        CreateNewParticleSpawner(14, 0.24f, 10, 12, 0.5f, new Color(0.5f, 0.5f, 0.5f), 69.5f, 100, 5, 45);
        
        CreateNewParticleSpawner(12, 0.24f, 10, 8, 0.4f, Color.black, 100, 117, 5, 40);
        CreateNewParticleSpawner(12, 0.24f, 10, 8, 0.4f, Color.black, 100, 117, 5, -40);
    }

    bool CreateNewParticleSpawner(float speed, float firerate, float lifetime, int numberOfCols, float size, Color col, float delay, float end, float destroyDelay, float rotation = 0, bool bossPos = true, Vector2 pos = new Vector2()) {

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
        spawner.rotation = rotation;
        spawner.endEmittingTime = end - delay;
        spawner.destroyDelay = destroyDelay;
        spawner.pos = pos;

        spawner.psPrefab = psPrefab;

        spawner.Invoke("Summon", delay);

        return true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
