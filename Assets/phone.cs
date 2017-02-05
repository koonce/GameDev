using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phone : MonoBehaviour {

    public bool phoneUp = true;
    public float phoneSpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Rigidbody2D body = GetComponent<Rigidbody2D>();
        Vector2 currentVel = body.velocity;

        if (Input.GetKeyDown(KeyCode.Space) && phoneUp)
        {
            phoneUp = false;
                currentVel.y = -phoneSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !phoneUp)
        {
            phoneUp = true;
                currentVel.y = phoneSpeed;
        }
        else if (transform.position.y >= 0 || transform.position.y <= -8)
        {
            currentVel.y = 0f;
        }

        body.velocity = currentVel;
	}
}
