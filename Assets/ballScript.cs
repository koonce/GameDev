﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {

    public float ballInitialVelocity = 5f;
    public float ballVelocity = 8f;


    private Rigidbody2D rb;
    private bool ballInPlay;
    bool noCollisions = true;
    bool collisions = false;
    bool hitRight = false;
    bool hitLeft = false;

    

    GameObject game;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

       // if (Input.GetMouseButtonDown(1) && ballInPlay == false)
       // {
           // transform.parent = null;
          //  ballInPlay = true;
            rb.isKinematic = false;
        if (noCollisions)
        {
            if (!collisions)
            {
                rb.AddForce(new Vector3(0, ballInitialVelocity, 0));
                collisions = true;
            }

            if (collisions)
            {
                rb.velocity = new Vector3(0, ballVelocity, 0);
            }
            noCollisions = false;
        }

        if (hitRight)
        {
            rb.AddForce(new Vector3(5, 0, 0));
            hitRight = false;
        }

        if (hitLeft)
        {
            rb.AddForce(new Vector3(-5, 0, 0));
            hitLeft = false;
        }


        // if (!noCollisions)
        // {
        //   rb.velocity = new Vector3(ballVelocity, ballVelocity, 0);
        // }

        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (tag == "right")
        {
            hitRight = true;
            Debug.Log("move right");
        }

        if (tag == "left")
        {
            hitLeft = true;
            Debug.Log("move left");
        }
    }

    void OnCollisionEnter2D(Collision2D otherCollider)
    {

        if (otherCollider.gameObject.tag == "lose")
        {
            Destroy(gameObject);
        }
    }


}
