using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    public Material material;
    public Sprite texture;
    public ParticleSystem psPrefab;
    public Boss boss;


    //ZWISCHEN DAS UND PsSPAWNER
    private PsBuilder builder;


    // Start is called before the first frame update
    void Start()
    {
        builder = new PsBuilder();
        builder.boss = boss;
        builder.material = material;
        builder.texture = texture;
        builder.psPrefab = psPrefab;
        builder.trans = gameObject.transform;

        switch (GameMaster.GM.currentLevel)
        {
            case 1:
                HandleProjectiles_Barge();
                break;

        }

        //CreateNewParticleSpawner(10, 0.5f, 10, 32, 0.3f, new Color(0.7f, 0.7f, 0.7f), 0, 30, 1, 20);




        //CreateNewParticleSpawner(10, 0.2f, 10, 9, 0.5f, new Color(0.3f, 0.3f, 0.3f), 7.5f, 36.5f , 5, 60);
        //CreateNewParticleSpawner(8, 0.48f, 10, 12, 0.6f, new Color(0.5f, 0.5f, 0.5f, 0.3f), 23.5f, 36.5f, 5, -25);
        //CreateNewParticleSpawner(6, 0.48f, 10, 30, 0.4f, Color.black, 38.5f, 51, 3, 120);
        //
        //
        ////speed / Firerate / liftime / number of cols / size, color, starttime, stopemitting, destroydelay, rotation vom ps, bosspos, pos  
        //
        //CreateNewParticleSpawner(12, 0.2f, 10, 6, 0.3f, new Color(0.5f, 0.5f, 0.5f), 54, 67, 5, 120);
        //CreateNewParticleSpawner(6, 0.5f, 30, 9, 0.8f, new Color(0.3f, 0.3f, 0.3f), 53, 64, 10, 60, false, new Vector2(6, 16));
        //
        //CreateNewParticleSpawner(16, 0.48f, 10, 16, 0.4f, new Color(0.4f, 0.4f, 0.4f), 69.5f, 100, 5, 25);
        //CreateNewParticleSpawner(14, 0.24f, 10, 12, 0.5f, new Color(0.5f, 0.5f, 0.5f), 69.5f, 100, 5, 45);
        //
        //CreateNewParticleSpawner(12, 0.24f, 10, 8, 0.4f, Color.black, 100, 117, 5, 40);
        //CreateNewParticleSpawner(12, 0.24f, 10, 8, 0.4f, Color.black, 100, 117, 5, -40);


    }

    public void HandleProjectiles_Barge() {

        FunctionTimer.Create(() => builder.CreateNormalPS(new ProjSetup(35, 16, GameCol.Grey7), new PsSetup(600, 16, 20, 0.5f, 3)), 7.2f);

        FunctionTimer.Create(() => builder.CreateRotatingPS(new ProjSetup(50, 10, GameCol.Grey5), new PsSetup(125, 12, 15, 29, 5)), 7.5f);
        FunctionTimer.Create(() => builder.CreateRotatingPS(new ProjSetup(50, 10, GameCol.Grey5), new PsSetup(125, 12, 15, 29, 5), 15), 7.77f);

        FunctionTimer.Create(() => builder.CreateNormalPS(new ProjSetup(60, 12, GameCol.Grey3), new PsSetup(125, 12, 30, 13, 5)), 23.5f);


    }

    //bool CreateNewParticleSpawner(ProjSetup prSetup, PsSetup psSetup) {

    //    GameObject go = new GameObject("Particle Spawner");
    //    go.transform.parent = gameObject.transform;
    //    go.transform.localPosition = gameObject.transform.localPosition;
    //    PsSpawner spawner = go.AddComponent<PsSpawner>();

    //    //TODO NOCH SCHUAEEEEEEEEEn
    //    spawner.material = material;
    //    spawner.bossTransform = boss.transform;

    //    spawner.texture = texture;

    //    spawner.psPrefab = psPrefab;

    //    spawner.prSetup = prSetup;
    //    spawner.psSetup = psSetup;

    //    spawner.Summon();

    //    return true;
    //}


    // Update is called once per frame
    void Update()
    {
        
    }
}
