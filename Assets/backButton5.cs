using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButton5 : MonoBehaviour {

    public GameObject gameScreen, homeScreen;
    GameObject ball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ball = GameObject.Find("ball(Clone)");

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(mouseWorldPos))
            {
                Destroy(ball);
                Debug.Log("go back from pong");
                gameScreen.SetActive(false);
                homeScreen.SetActive(true);
            }
        }

    }
}
