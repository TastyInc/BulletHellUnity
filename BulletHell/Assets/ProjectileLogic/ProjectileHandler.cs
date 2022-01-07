using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    public Material material;
    public Sprite texture;
    public Boss boss;
    public ParticleSystem psPrefab;


    //ZWISCHEN DAS UND PsSPAWNER
    private PsBuilder builder;


    public void Setup(Boss boss)
    {
        this.boss = boss;

    }



    // Start is called before the first frame update
    void Start()
    {
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
        FunctionTimer.Create(() => CreateNewParticleSpawner(new ProjSetup(35, 16, GameCol.Grey7), new PsSetup(600, 16, 20, 0.5f, 3)), 7.2f);
        FunctionTimer.Create(() => CreateNewParticleSpawner(new ProjSetup(50, 12, GameCol.Grey5), new PsSetup(125, 10, 12, 29, 5)), 7.5f);
        FunctionTimer.Create(() => CreateNewParticleSpawner(new ProjSetup(60, 10, GameCol.Grey3), new PsSetup(125, 10, 30, 13, 5)), 23.5f);


    }

    bool CreateNewParticleSpawner(ProjSetup prSetup, PsSetup psSetup) {

        GameObject go = new GameObject("Particle Spawner");
        go.transform.parent = gameObject.transform;
        go.transform.localPosition = gameObject.transform.localPosition;
        PsSpawner spawner = go.AddComponent<PsSpawner>();

        //TODO NOCH SCHUAEEEEEEEEEn
        spawner.material = material;
        spawner.bossTransform = boss.transform;

        spawner.texture = texture;

        spawner.psPrefab = psPrefab;

        spawner.prSetup = prSetup;
        spawner.psSetup = psSetup;

        spawner.Summon();

        return true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
