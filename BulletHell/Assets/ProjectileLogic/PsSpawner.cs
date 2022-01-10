using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsSpawner : MonoBehaviour
{



    public ProjSetup prSetup;
    public PsSetup psSetup;

    public Sprite texture;
    public Material material;
    public Transform bossTransform;

    public ParticleSystem psPrefab;
    
    //Rotation PS
    public bool isRotating = false;
    public float rotOffset = 0;

    //Laser PS
    public bool isLaser = false;
    public float warningTime = 0;
    public ProjSetup prLaser;

    private ParticleSystem system;


    private void Start()
    {
        if (psSetup.bossPos) {
            transform.position = bossTransform.position;
        } else {
            transform.position = psSetup.pos;
        }
    }


    public bool Summon()
    {
        if (psSetup.pos.x != 0 || psSetup.pos.y != 0)
        {
            transform.position = psSetup.pos;
        }

        for (int i = 0; i < psSetup.numberOfCols; i++) {
            // A simple particle material with no texture.
            Material particleMaterial = material;

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            go.layer = 8;
            go.transform.parent = transform;
            go.transform.localScale = new Vector3(1, 1, 1);
            go.transform.localPosition = new Vector3(0, 0, 0); //Position relative to Boss/ParticleSpawner
            go.transform.Rotate(psSetup.projSpacing * i + rotOffset, 90, 0); // Rotate so the system emits upwards.

            system = go.AddComponent<ParticleSystem>();

            var prefabRenderer = psPrefab.GetComponent<ParticleSystemRenderer>();
            var renderer = go.GetComponent<ParticleSystemRenderer>();

            renderer.material = particleMaterial;
            renderer.renderMode = ParticleSystemRenderMode.Stretch; //Nötig für Direction align 
            renderer.cameraVelocityScale = 0;
            renderer.lengthScale = 1; //Nötig für Direction align 
            renderer.sortingLayerID = prefabRenderer.sortingLayerID;

            //var mainn = ProjectilePreset.GetProjectilePreset(color, size, speed, 10000);

            SetMain(system.main);

            SetEmission(system.emission);

            SetShape(system.shape);

            if (!isLaser)
            {
                SetCollision(system.collision);
            }


            //Macht das Partikel zurück kommen...
            //var fol = system.forceOverLifetime;
            //fol.enabled = true;
            //fol.space = ParticleSystemSimulationSpace.World;
            //fol.x = Mathf.Cos(angle) * (speed / lifetime) * (-2);
            //fol.y = Mathf.Sin(angle) * (speed / lifetime) * (-2);



            var text = system.textureSheetAnimation;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.enabled = true;
            text.AddSprite(texture);
        }

        if (isLaser)
        {
            Invoke("LaserActivation", warningTime);
        }
        else
        {
            InvokeRepeating("DoEmit", 0, 60 / psSetup.firerate);
        }

        Invoke("StopEmitting", psSetup.stopEmitting);
        Invoke("DestroyItself", psSetup.stopEmitting + psSetup.destroyDelay);

        return true;
    }

    private void SetShape(ParticleSystem.ShapeModule shape) {
        shape.enabled = false;
        shape.shapeType = ParticleSystemShapeType.Sprite;
        shape.sprite = null;
        shape.alignToDirection = true;
    }

    private void SetCollision(ParticleSystem.CollisionModule col){

        LayerMask mask = LayerMask.GetMask("Player");

        col.enabled = true;
        col.sendCollisionMessages = true;
        col.collidesWith = mask;
        col.enableDynamicColliders = true;
        col.type = ParticleSystemCollisionType.World;
        col.mode = ParticleSystemCollisionMode.Collision2D;
        col.lifetimeLoss = 50;
    }


    private void SetMain(ParticleSystem.MainModule main)
    {
        main.startColor = prSetup.col;
        main.startSize = prSetup.size / 100;
        main.startSpeed = prSetup.speed;
        main.startLifetime = prSetup.lifetime;
        main.maxParticles = 10000;


        //Local ermöglicht rotation und sinus scheiss und return mit forceoverlifetime aber macht auch, dass das partikelsistem dem boss folgt oder dem emitterr...
        if (isRotating)
        {
            main.simulationSpace = ParticleSystemSimulationSpace.Local;
        }
        else
        {
            main.simulationSpace = ParticleSystemSimulationSpace.World;
        }

    }

    private void SetEmission(ParticleSystem.EmissionModule emission) {
        if (isLaser)
        {
            emission.enabled = true;
            emission.rateOverTime = 100;
        }
        else
        {
            emission.enabled = false;
        }


    }

    private void Update()
    {
        if (psSetup.bossMov)
        {
            transform.position = bossTransform.position;
        }
        else if (psSetup.mov != new Vector2()) 
        {
            transform.Translate(psSetup.mov);
        }

        if (psSetup.rotation != 0)
        {
            transform.Rotate(0, 0, psSetup.rotation * Time.deltaTime);
        }
    }

    void StopEmitting() {
        CancelInvoke("DoEmit");
    }

    void DestroyItself()
    {
        Destroy(gameObject);
    }

    void DoEmit()
    {
        foreach (Transform child in this.transform) {
            system = child.GetComponent<ParticleSystem>();

            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            var emitParams = new ParticleSystem.EmitParams();

            Debug.Log(system.transform.position.y);

            emitParams.rotation = prSetup.rotation;
            emitParams.startColor = prSetup.col;
            emitParams.startSize = prSetup.size / 100;
            emitParams.startLifetime = prSetup.lifetime;
            system.Emit(emitParams, 10);
            system.Play(); // Continue normal emissions
        }
    }

    void LaserActivation()
    {
        var main = system.main;
        main.startColor = prLaser.col;
        main.startSize = prLaser.size / 100;
        main.startSpeed = prLaser.speed;
        main.startLifetime = prLaser.lifetime;

        SetCollision(system.collision);
    }
}