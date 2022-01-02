using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelLogic : MonoBehaviour
{

    public enum levels { 
        Barge = 1,
        LordAndMaster = 2
    }

    public static LoadLevelLogic LL;

    public float volume = 0.3f;
    public bool isPlayerAlive = true;
    public bool debugMode = true;

    void Awake()
    {
        if (LL != null)
            GameObject.Destroy(LL);
        else
            LL = this;
    }


    public void LoadAudioEffects(levels lvl) { 
        
        
    }

}
