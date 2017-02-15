using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diaryButton : MonoBehaviour {

    bool isItOpen;


	// Use this for initialization
	void Start () {

        //isItOpen = GameObject.Find("Phone").GetComponent<openApp>().open;
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameObject.Find("Phone").GetComponent<openApp>().open)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<Collider2D>().OverlapPoint(mouseWorldPos))
                {
                    Debug.Log("click diary");
                    GameObject diaryScreen = GameObject.Find("diaryScreen");
                    Transform tPos = diaryScreen.GetComponent<Transform>();
                    Vector3 tPosi = tPos.position;
                    tPosi.z = -5f;
                    tPos.position = tPosi;
                }
            }

        }

    }
    
}
