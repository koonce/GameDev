using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleScript : MonoBehaviour {

    public float paddleSpeed = 5f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        BoxCollider2D screen = GameObject.Find("screen").GetComponent<BoxCollider2D>();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (screen.OverlapPoint(mouseWorldPos))
        {
                Vector3 pos = transform.position;
            pos.x = mouseWorldPos.x;// * paddleSpeed;
                transform.position = pos;
        }
    }
}
