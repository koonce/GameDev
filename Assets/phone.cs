using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phone : MonoBehaviour {

    public bool phoneUp = true;
    public bool phoneMove = false;
    public float phoneSpeed = 10f;
    public float messageMoveSpeed = 4f;
    bool goingDown = false;
    bool goingUp = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.localPosition;
        Vector3 offScreen = new Vector3(0, -8, 1);
        Vector3 onScreen = new Vector3(0, 0, 1);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (phoneUp)
            {
                goingDown = true;
            }
            if (!phoneUp)
            {
                goingUp = true;
            }
        }
        if (goingDown)
        {
            pos = Vector3.MoveTowards(pos, offScreen, messageMoveSpeed * Time.deltaTime);
        }
        if (goingUp)
        {
            pos = Vector3.MoveTowards(pos, onScreen, messageMoveSpeed * Time.deltaTime);
        }


        if (pos == offScreen)
        {
            phoneUp = false;
                goingDown = false;
                goingUp = false;
        }
        if (pos == onScreen)
        {
            phoneUp = true;
                goingDown = false;
                goingUp = false;
        }            

        //else if (Input.GetKeyDown(KeyCode.Space) && !phoneUp)
        // {

        //}
        transform.position = pos;
	}
}
