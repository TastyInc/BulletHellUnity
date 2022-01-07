using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsSetup
{

    /// <summary>
    /// Gibt an, wie schnell die Projektile geschossen werden. Anzahl pro Minute
    /// </summary>
    public float firerate;
    /// <summary>
    /// Anzahl an Partikel welche abgeschossen werden
    /// </summary>
    public int numberOfCols;
    /// <summary>
    /// Zeit nachdem das System aufhört zu emitten. Nicht absolute Zeit sondern Zeit nach Start.
    /// </summary>
    public float stopEmitting;
    /// <summary>
    /// Zeit nachdem das system Destroyt werden soll. Zeit nach StopEmitting
    /// </summary>
    public float destroyDelay;
    /// <summary>
    /// rotationsgeschwindigkeit des Partikelsystems um die eigene achse. 
    /// </summary>
    public float rotation = 0;
    /// <summary>
    /// Spacing zwischen den PS. Falls 0 dann automatisch anhand der NumberOfCols
    /// </summary>
    public float projSpacing = 0;
    /// <summary>
    /// Zeigt System in richtung Spieler?
    /// </summary>
    public bool pointAtPlayer = false;
    /// <summary>
    /// spawnt das Sytem im Boss?
    /// </summary>
    public bool bossPos = true;
    /// <summary>
    /// Bewegt sich das System mit dem Boss?
    /// </summary>
    public bool bossMov = true;
    /// <summary>
    /// Spawnposition falls nicht im boss.
    /// </summary>
    public Vector2 pos = new Vector2();
    /// <summary>
    /// Bewegung falls nicht mit dem Boss
    /// </summary>
    public Vector2 mov = new Vector2();


    public PsSetup(float fr, int noc, float rotation, float stopEmitting, float destDelay, float projSpacing = 0, bool pap = false) {
        this.firerate = fr;
        this.numberOfCols = noc;
        this.rotation = rotation;
        this.stopEmitting = stopEmitting;
        this.destroyDelay = destDelay;

        if (projSpacing == 0)
        {
            //gleichmässiger abstand zwischen Partikelsystemen/Projektilen
            this.projSpacing = 360f / noc;
        }
        else {
            this.projSpacing = projSpacing;
        }

        this.pointAtPlayer = pap;


    }

    /// <summary>
    /// Overload wird gebraucht, falls Partikelsystem nicht dem Boss folgt und/oder iwo anders spawnt...
    /// </summary>
    public PsSetup(float fr, int noc, float rotation, float stopEmitting, float destDelay, Vector2 pos, Vector2 mov) {
        this.firerate = fr;
        this.numberOfCols = noc;
        this.rotation = rotation;
        this.stopEmitting = stopEmitting;
        this.destroyDelay = destDelay;

        if (pos != this.pos) {
            this.pos = pos;
            this.bossPos = false;
        }

        if (mov != this.mov)
        {
            this.mov = mov;
            this.bossMov = false;
        }
    }
    
}
