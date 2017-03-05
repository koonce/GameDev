using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickScript : MonoBehaviour {

    public GameObject reset;
    public GameObject game;
    public int bricks;
 
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //bricks = game.GetComponent<GM>().brickNumber;
    }

    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "ball")
        {
            game.GetComponent<GM>().brickNumber--;
            gameObject.SetActive(false);
        }
    }
}
