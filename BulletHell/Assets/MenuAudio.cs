using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAudio : MonoBehaviour
{
    private AudioSource audioSource;

    private float updateStep = 0.05f;
    private float currentUpdateTime = 0f;
    private float clipLoudness;
    private float[] clipSampleData;
    private int sampleDataLength = 1024;

    private ParticleSystem.Particle[] particles;

    public ParticleSystem system;
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = volumeSlider.value;
        GameMaster.GM.volume = volumeSlider.value;

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
            InitializeParticleSystemIfNeeded();
            int numParticlesAlive = system.GetParticles(particles);

            // Change only the particles that are alive
            for (int i = 0; i < numParticlesAlive; i++)
            {
                particles[i].velocity = Vector3.up * clipLoudness * 35;
            }

            system.SetParticles(particles, numParticlesAlive);

        }

    }

    public void VolumeChanged() {
        audioSource.volume = volumeSlider.value;
        GameMaster.GM.volume = volumeSlider.value;
    }

    void InitializeParticleSystemIfNeeded()
    {
        if (system == null)
            Debug.Log("No Particle System Found");

        if (particles == null || particles.Length < system.main.maxParticles)
            particles = new ParticleSystem.Particle[system.main.maxParticles];
    }
}
