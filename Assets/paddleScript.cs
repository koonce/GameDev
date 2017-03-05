using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleScript : MonoBehaviour {

    public float paddleSpeed = 5f;
    public GameObject ball;
    GameObject newBall;
    public GameObject resetMe;

    bool ballInPlay;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        bool areWePlaying = GameObject.Find("gameManager").GetComponent<GM>().gamePlaying;
        Vector3 paddlePos = transform.position;
        BoxCollider2D screen = GameObject.Find("screen").GetComponent<BoxCollider2D>();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool resetting = resetMe.GetComponent<resetGameButton>().reset;
        if (newBall == null)
        {
            ballInPlay = false;
        }

        if (screen.OverlapPoint(mouseWorldPos))
        {
                Vector3 pos = transform.position;
            pos.x = mouseWorldPos.x;// * paddleSpeed;
                transform.position = pos;
            if (Input.GetMouseButtonDown(0) && !ballInPlay && areWePlaying)
            {
                resetting = false;
                    newBall = Instantiate(ball) as GameObject;
                ballInPlay = true;
                newBall.transform.position = new Vector3(paddlePos.x, -1.3f, -7);
            }
        }
    }
}
