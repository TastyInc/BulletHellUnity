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

    private ParticleSystem system;



    private void Start()
    {


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
            go.transform.Rotate(psSetup.projSpacing * i, 90, 0); // Rotate so the system emits upwards.
            go.transform.localScale = new Vector3(1, 1, 1);
            go.transform.localPosition = new Vector3(0, 0, 0); //Position relative to Boss/ParticleSpawner

            system = go.AddComponent<ParticleSystem>();

            var prefabRenderer = psPrefab.GetComponent<ParticleSystemRenderer>();
            var renderer = go.GetComponent<ParticleSystemRenderer>();

            renderer.material = particleMaterial;
            renderer.renderMode = ParticleSystemRenderMode.Stretch; //Nötig für Direction align 
            renderer.cameraVelocityScale = 0;
            renderer.lengthScale = 1; //Nötig für Direction align 
            renderer.sortingLayerID = prefabRenderer.sortingLayerID;

            //var mainn = ProjectilePreset.GetProjectilePreset(color, size, speed, 10000);

            var mainModule = system.main;

            mainModule.startColor = prSetup.col;
            mainModule.startSize = prSetup.size / 100;
            mainModule.startSpeed = prSetup.speed;
            mainModule.startLifetime = prSetup.lifetime;
            mainModule.maxParticles = 10000;

            //Local ermöglicht rotation und sinus scheiss und return mit forceoverlifetime aber macht auch, dass das partikelsistem dem boss folgt oder dem emitterr...
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            var emission = system.emission;
            emission.enabled = false;

            //Macht das Partikel zurück kommen...
            //var fol = system.forceOverLifetime;
            //fol.enabled = true;
            //fol.space = ParticleSystemSimulationSpace.World;
            //fol.x = Mathf.Cos(angle) * (speed / lifetime) * (-2);
            //fol.y = Mathf.Sin(angle) * (speed / lifetime) * (-2);

            var shape = system.shape;
            shape.enabled = false;
            shape.shapeType = ParticleSystemShapeType.Sprite;
            shape.sprite = null;
            shape.alignToDirection = true;

            LayerMask mask = LayerMask.GetMask("Player");

            var collision = system.collision;
            collision.enabled = true;
            collision.sendCollisionMessages = true;
            collision.collidesWith = mask;
            collision.enableDynamicColliders = true;
            collision.type = ParticleSystemCollisionType.World;
            collision.mode = ParticleSystemCollisionMode.Collision2D;
            collision.lifetimeLoss = 50;

            var text = system.textureSheetAnimation;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.enabled = true;
            text.AddSprite(texture);
        }

        InvokeRepeating("DoEmit", 0, 60 / psSetup.firerate);
        Invoke("StopEmitting", psSetup.stopEmitting);
        Invoke("DestroyItself", psSetup.stopEmitting + psSetup.destroyDelay);

        return true;
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

            emitParams.rotation = prSetup.rotation;
            emitParams.startColor = prSetup.col;
            emitParams.startSize = prSetup.size / 100;
            emitParams.startLifetime = prSetup.lifetime;
            system.Emit(emitParams, 10);
            system.Play(); // Continue normal emissions
        }
    }
}