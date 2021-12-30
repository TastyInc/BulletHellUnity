using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public int numberCols;
    public float speed;
    public Sprite texture;
    public Color color;
    public float lifetime;
    public float firerate;
    public float size;
    public Material material;

    public Transform transform;

    private float angle;
    private float bossRotation;
    private ParticleSystem system;

    private void Start()
    {

    }


    public bool Summon()
    {

        angle = 360f / numberCols;

        for (int i = 0; i < numberCols; i++) {
            // A simple particle material with no texture.
            Material particleMaterial = material;

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.
            go.transform.parent = transform;
            go.transform.localScale = new Vector3(1, 1, 1);
            go.transform.position = transform.position;
            
            system = go.AddComponent<ParticleSystem>();

            var renderer = go.GetComponent<ParticleSystemRenderer>();
            renderer.material = particleMaterial;
            renderer.renderMode = ParticleSystemRenderMode.Stretch; //Nötig für Direction align 
            renderer.cameraVelocityScale = 0;
            renderer.lengthScale = 1; //Nötig für Direction align 
            //renderer.sortingLayerName = "Projectile";

            var mainModule = system.main;
            mainModule.startColor = color;
            mainModule.startSize = size;
            mainModule.startSpeed = speed;
            mainModule.maxParticles = 10000;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            var emission = system.emission;
            emission.enabled = false;
            
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
            collision.lifetimeLoss = 20;

            var text = system.textureSheetAnimation;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.enabled = true;
            text.AddSprite(texture);
        }

        InvokeRepeating("DoEmit", 0.1f, firerate);

        return true;

        //CancelInvoke("");
    }

    void DoEmit()
    {
        foreach (Transform child in transform) {
            system = child.GetComponent<ParticleSystem>();

            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            var emitParams = new ParticleSystem.EmitParams();

            emitParams.startColor = color;
            emitParams.startSize = size;
            emitParams.startLifetime = lifetime;
            system.Emit(emitParams, 10);
            system.Play(); // Continue normal emissions
        }
    }
}