using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButton3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(mouseWorldPos))
            {
                Debug.Log("go back from music");
                GameObject screen = GameObject.Find("musicScreen");
                Transform mPos = screen.GetComponent<Transform>();
                Vector3 mPosi = mPos.position;
                mPosi.z = 1f;
                mPos.position = mPosi;
            }
        }
    }
}
