using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButton4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject screen = GameObject.Find("diaryScreen");
        Transform mPos = screen.GetComponent<Transform>();
        if (mPos.position.z <= -5)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<Collider2D>().OverlapPoint(mouseWorldPos))
                {
                    Debug.Log("go back from diary");
                    Vector3 mPosi = mPos.position;
                    mPosi.z = 1f;
                    mPos.position = mPosi;
                }
            }
        }
    }
}
