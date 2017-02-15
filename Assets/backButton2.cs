using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButton2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject screen = GameObject.Find("picScreen");
        Transform tPos = screen.GetComponent<Transform>();

        if (tPos.position.z <= -5)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<Collider2D>().OverlapPoint(mouseWorldPos))
                {
                    Debug.Log("go back from pictures");
                    Vector3 tPosi = tPos.position;
                    tPosi.z = 1;
                    tPos.position = tPosi;
                }
            }
        }
    }
}
