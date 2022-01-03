using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class ProjectilePreset
{
    public static ParticleSystem.MainModule main;

    // Start is called before the first frame update
    public static ParticleSystem.MainModule GetProjectilePreset(Color col, float size, float speed, int maxParticles)
    {
        main.startColor = col;
        main.startSize = size;
        main.startSpeed = speed;
        main.maxParticles = maxParticles;

        return main;
    }

}
