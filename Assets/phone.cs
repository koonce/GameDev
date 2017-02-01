using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phone : MonoBehaviour {

    bool phoneUp = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && phoneUp)
        {
            phoneUp = false;
            Vector3 location = transform.position;
            location.y = -10f;
            transform.position = location;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !phoneUp)
        {
            phoneUp = true;
            Vector3 location = transform.position;
            location.y = 0f;
            transform.position = location;
        }
	}
}
