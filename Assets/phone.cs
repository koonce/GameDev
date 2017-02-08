using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phone : MonoBehaviour {

    public bool phoneUp = true;
    public bool phoneMove = false;
    public float phoneSpeed = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Rigidbody2D body = GetComponent<Rigidbody2D>();
        Vector2 currentVel = body.velocity;

        if (transform.position.y >= 0.3999995 || transform.position.y <= -8.399996)
        {
            phoneMove = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && phoneUp)
        {
            phoneMove = true;
            phoneUp = false;
                currentVel.y = -phoneSpeed;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && !phoneUp)
        {
            phoneMove = true;
            phoneUp = true;
                currentVel.y = phoneSpeed;
        }

        else if (!phoneMove)
        {
            currentVel.y = 0f;
        }

        body.velocity = currentVel;
	}
}
