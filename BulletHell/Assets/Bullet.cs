using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 5;

    private Vector2 initPos;

    void Start()
    {
        initPos = gameObject.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.transform.position = initPos;
        gameObject.SetActive(false);
    }

    private void Update()
    {

        //Debug.Log(gameObject.transform.position.x);

        //float timeAlive = Time.timeSinceLevelLoad - initTime;

        //if (timeAlive > 0.5f && !gameObject.GetComponent<Renderer>().isVisible)
        //{
        //    gameObject.SetActive(false);  //Destroy(this.gameObject); // Destroy the gameobject
        //}
    }
}
