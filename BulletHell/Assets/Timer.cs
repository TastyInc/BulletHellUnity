using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public AudioPlayer audioPlayer;

    private TextMeshProUGUI timerText;
    private AudioSource ass;

    // Start is called before the first frame update
    void Awake()
    {
        timerText = gameObject.GetComponent<TextMeshProUGUI>();
        ass = audioPlayer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.SetText(Time.timeSinceLevelLoad.ToString() + "\n" + (Time.timeSinceLevelLoad - ass.time).ToString());
    }
}
