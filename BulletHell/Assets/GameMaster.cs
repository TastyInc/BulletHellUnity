using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public enum levels
    {
        Barge = 1,
        LordAndMaster = 2
    }

    public static GameMaster GM;

    public float volume = 0.3f;
    public bool isPlayerAlive = true;
    public bool debugMode = true;
    public int currentLevel = 0;

    void Awake()
    {
        if (GM != null)
            GameObject.Destroy(GM);
        else
            GM = this;

        DontDestroyOnLoad(this);
    }

    public void LoadAudioEffects()
    {
        switch (currentLevel) { 
            case 1:

            break;

            case 2:

            break;
        
        
        }
    }

}
