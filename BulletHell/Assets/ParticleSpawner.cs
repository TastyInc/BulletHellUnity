using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public int numberCols;
    public float speed;
    public Texture texture;
    public Color color;
    public float lifetime;
    public float firerate;
    public float size;
    private float angle;
    public Material material; 

    public ParticleSystem system;

    private void Awake()
    {
        Summon();
    }

    void Summon()
    {
        angle = 360f / numberCols;

        for (int i = 0; i < numberCols; i++) {
            // A simple particle material with no texture.
            Material particleMaterial = new Material(Shader.Find("Particles/Standard Unlit"));

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;

            var emission = system.emission;
            emission.enabled = false;
            
            var shape = system.shape;
            shape.enabled = false;
            shape.shapeType = ParticleSystemShapeType.Sprite;
            shape.sprite = null;

        }



        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", 2.0f, 2.0f);
    }

    void DoEmit()
    {
        foreach (Transform child in transform) {
            system = child.GetComponent<ParticleSystem>();

            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = Color.red;
            emitParams.startSize = 0.2f;
            system.Emit(emitParams, 10);
            system.Play(); // Continue normal emissions
        }


    }
}