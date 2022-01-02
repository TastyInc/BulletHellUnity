using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 3;
    public float hpRegen = 5;
    public ParticleSystem damageParticles = null;

    private int currentHP;
    private float invisFrames = 0.5f;
    private float invisFramesCD = 0;
    private float hpReplenishCD;
    private bool neverTookDmg = true;

    // Start is called before the first frame update
    void Start()
    {
        GameMaster.GM.isPlayerAlive = true;
        hpReplenishCD = hpRegen;
        currentHP = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP < maxHealth) {
            hpReplenishCD -= Time.deltaTime;
            invisFramesCD -= Time.deltaTime;

            if (hpReplenishCD < 0)
            {
                ReplenishHealth();
            }

            if (invisFramesCD < 0) {
                PlayerInvisFrames(false);
            }
        } else {
            hpReplenishCD = hpRegen;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("collision");
        TakeDamage();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO Checken was genau, hier kommt auch rand, sollte nichts machen :/

        //Debug.Log("CAKJSF LKASF");
        //TakeDamage();
    }

    void ReplenishHealth() {
        currentHP++;
        hpReplenishCD = hpRegen;

        if (damageParticles != null) 
        {
            var main = damageParticles.main;
            main.startColor = new Color(0.2f, 0.7f, 0.2f, 0.7f);
            damageParticles.Play();
        }
    }

    void TakeDamage()
    {
        if (invisFramesCD <= 0 && GameMaster.GM.isPlayerAlive && !GameMaster.GM.debugMode) {
            neverTookDmg = false;

            if (damageParticles != null)
            {

                ParticleSystem.MinMaxGradient mmg = new ParticleSystem.MinMaxGradient();
                mmg.colorMin = Color.white;
                mmg.colorMax = Color.black;
                mmg.mode = ParticleSystemGradientMode.TwoColors;

                var main = damageParticles.main;
                main.startColor = mmg;
                damageParticles.Play();
            }
        
            currentHP--;

            if (currentHP <= 0) {
                PlayerDeath();
            }

            hpReplenishCD = hpRegen;

            invisFramesCD = invisFrames;

            PlayerInvisFrames(true);
        }
    }

    void PlayerInvisFrames(bool isInvis) {

        SpriteRenderer ps = gameObject.GetComponent<SpriteRenderer>();

        if (isInvis)
        {
            ps.color = new Color(ps.color.r, ps.color.g, ps.color.b, 0.5f);
        }
        else
        {
            ps.color = new Color(ps.color.r, ps.color.g, ps.color.b, 1);
        }
    }

    void PlayerDeath()
    {
        Time.timeScale = 0.3f;

        Camera.main.orthographicSize /= 2;
        FunctionTimer.Create(() => PlayerDied(), 1);

    }

    void PlayerDied() {
        GameMaster.GM.isPlayerAlive = false;
        Camera.main.orthographicSize *= 2;
    }
}
