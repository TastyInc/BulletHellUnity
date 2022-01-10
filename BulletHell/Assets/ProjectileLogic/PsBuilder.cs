using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsBuilder : MonoBehaviour
{
    public Material material;
    public Sprite texture;
    public Boss boss;
    public ParticleSystem psPrefab;
    public Transform trans;


    private PsSpawner PsSetup(ProjSetup prSetup, PsSetup psSetup) {

        GameObject go = new GameObject("Particle Spawner");
        go.transform.parent = trans;
        go.transform.localPosition = trans.localPosition;
        PsSpawner spawner = go.AddComponent<PsSpawner>();

        //TODO NOCH SCHUAEEEEEEEEEn
        spawner.material = material;
        spawner.bossTransform = boss.transform;

        spawner.texture = texture;
        spawner.psPrefab = psPrefab;

        spawner.prSetup = prSetup;
        spawner.psSetup = psSetup;

        return spawner;
    }

    public bool CreateNormalPS(ProjSetup prSetup, PsSetup psSetup)
    {
        PsSpawner spawner = PsSetup(prSetup, psSetup);

        spawner.Summon();

        return true;
    }

    public bool CreateRotatingPS(ProjSetup prSetup, PsSetup psSetup, float rotOffset = 0)
    {
        PsSpawner spawner = PsSetup(prSetup, psSetup);

        spawner.isRotating = true;
        spawner.rotOffset = rotOffset;

        spawner.Summon();

        return true;
    }

    public bool CreateLaserPS(ProjSetup preLaser, ProjSetup prSetup, PsSetup psSetup, float warningTime)
    {
        PsSpawner spawner = PsSetup(prSetup, psSetup);

        spawner.prLaser = prSetup;

        spawner.isLaser = true;
        spawner.warningTime = warningTime;

        spawner.Summon();

        return true;
    }

}
