using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjSetup
{
    /// <summary>
    /// Grösse des Proj/Partikels
    /// </summary>
    public float size = 10;
    /// <summary>
    /// Geschwindigkeit vom partikel
    /// </summary>
    public float speed = 8;
    /// <summary>
    /// Rotation des Partikels um die eigene Achse
    /// </summary>
    public int rotation = 0;
    /// <summary>
    /// Lifetime des Partikels, falls leer dann 10s
    /// </summary>
    public float lifetime = 10;
    /// <summary>
    /// Farbe vom partikel, falls leer dann Black
    /// </summary>
    public Color col = Color.black;

    /// <summary>
    /// wird für Partikelsystem und Projektilbuilder gebraucht
    /// </summary>
    /// <param name="size"></param>
    /// <param name="speed"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    public ProjSetup(float size, float speed, Color col)
    {
        this.size = size;
        this.speed = speed;
        this.col = col;
    }

    public ProjSetup(float size, float speed, Color col, int rotation = 0, float lifetime = 10)
    {
        this.size = size;
        this.speed = speed;
        this.rotation = rotation;
        this.col = col;
        this.lifetime = lifetime;

    }

    public ProjSetup(float size, float speed, Color col, int rotation) {
        this.size = size;
        this.speed = speed;
        this.rotation = rotation;
        this.col = col;
    }
}
