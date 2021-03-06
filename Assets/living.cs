﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class living : MonoBehaviour {

    public int life = 3;
    public GameObject resetter;
    public GameObject gameOver;
    public GameObject winGame;
    public bool ableToBeReset = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool resetting = resetter.GetComponent<resetGameButton>().reset2;

        if (resetting == true)
        {
            if (ableToBeReset)
            {
                life = 3;
                GameObject.Find("gameManager").GetComponent<GM>().brickNumber = 12;
                gameOver.SetActive(false);
                winGame.SetActive(false);
                ableToBeReset = false;
            }
            resetting = false;
        }
        
    }

    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "ball")
        {
            life--;
        }
    }
}
