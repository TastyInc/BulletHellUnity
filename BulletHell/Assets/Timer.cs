using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Awake()
    {
        timerText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.SetText(Time.timeSinceLevelLoad.ToString());
    }
}
