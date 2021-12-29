using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private float updateStep = 0.02f;
    private float currentUpdateTime = 0f;
    private float clipLoudness;
    private float[] clipSampleData;
    private int sampleDataLength = 1024;

    private float shakeAmount = 0.2f;

    private Vector3 idleCameraPos;

    public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.volume = volumeSlider.value;

        clipSampleData = new float[sampleDataLength];

        idleCameraPos = mainCam.transform.position;
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


            float shade;
            if (clipLoudness < 0.1f)
            {
                shade = 0;
            }
            else {
                shade = Mathf.Clamp(clipLoudness, 0, 1) / 2;

                if (clipLoudness > 0.3f) {
                    shakeAmount = clipLoudness / 2;
                    InvokeRepeating("DoShake", 0, 0.01f);
                    Invoke("StopShake", updateStep);
                }
            }


            Color col = new Color(shade, shade, shade);

            mainCam.backgroundColor = col;


            //Mathf.clamp(mid top)

        }

    }

    public void DoShake()
    {
        if (shakeAmount > 0) {
            Vector3 camPos = mainCam.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;

            mainCam.transform.position = camPos;
        }
    }

    public void StopShake()
    {
        CancelInvoke("DoShake");
        mainCam.transform.position = idleCameraPos;
    }

}
