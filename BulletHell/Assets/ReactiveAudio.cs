using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public ParticleSystem particleSystem;

    private float updateStep = 0.1f;
    private float currentUpdateTime = 0f;
    private float clipLoudness;
    private float[] clipSampleData;
    private int sampleDataLength = 1024;

    // Start is called before the first frame update
    void Start()
    {
        clipSampleData = new float[sampleDataLength];
    }

    // Update is called once per frame
    void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep) {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);
            clipLoudness = 0f;
            foreach (var sample in clipSampleData) {
                clipLoudness += Mathf.Abs(sample);
            }

            clipLoudness /= sampleDataLength;

            //Mathf.clamp(mid top)

            var main = particleSystem.main;

            main.gravityModifierMultiplier = clipLoudness;

            //Debug.Log(clipLoudness);
        }
    }
}
