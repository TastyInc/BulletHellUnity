using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuParticles : MonoBehaviour
{
    public AudioSource audioSource;

    private float updateStep = 0.05f;
    private float currentUpdateTime = 0f;
    private float clipLoudness;
    private float[] clipSampleData;
    private int sampleDataLength = 1024;

    private ParticleSystem.Particle[] particles;
    private ParticleSystem system;

    // Start is called before the first frame update
    void Start()
    {
        clipSampleData = new float[sampleDataLength];
    }

    // Update is called once per frame
    void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);

            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }

            clipLoudness /= sampleDataLength;

            //Mathf.clamp(mid top)
            InitializeIfNeeded();

            int numParticlesAlive = system.GetParticles(particles);

            // Change only the particles that are alive
            for (int i = 0; i < numParticlesAlive; i++)
            {
                particles[i].velocity = Vector3.up * clipLoudness * 35;
            }

            gameObject.GetComponent<ParticleSystem>().SetParticles(particles, numParticlesAlive);

        }

    }

    void InitializeIfNeeded()
    {
        if (system == null)
            system = GetComponent<ParticleSystem>();

        if (particles == null || particles.Length < system.main.maxParticles)
            particles = new ParticleSystem.Particle[system.main.maxParticles];
    }
}
