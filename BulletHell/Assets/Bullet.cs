using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 5;

    public float initTime;

    void Start()
    {
        initTime = Time.timeSinceLevelLoad;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        //float timeAlive = Time.timeSinceLevelLoad - initTime;

        //if (timeAlive > 0.5f && !gameObject.GetComponent<Renderer>().isVisible)
        //{
        //    gameObject.SetActive(false);  //Destroy(this.gameObject); // Destroy the gameobject
        //}
    }
}
