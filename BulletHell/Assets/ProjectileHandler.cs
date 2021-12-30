using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    public Material material;
    public Sprite texture;

    private ParticleSpawner spawner;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<ParticleSpawner>();

        spawner = gameObject.GetComponent<ParticleSpawner>(); //= new ParticleSpawner();

        spawner.speed = 10;
        spawner.firerate = 0.2f;
        spawner.lifetime = 10;
        spawner.numberCols = 8;
        spawner.size = 0.5f;
        spawner.material = material;
        spawner.transform = this.transform;
        spawner.texture = texture;
        spawner.color = new Color(0, 0, 0, 1);

        spawner.Invoke("Summon", 7);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
