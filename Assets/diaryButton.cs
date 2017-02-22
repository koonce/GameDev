﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diaryButton : MonoBehaviour {


    // Use this for initialization
    void Start () {

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
                    GameObject musicScreen = GameObject.Find("diaryScreen");
                    Transform tPos = musicScreen.GetComponent<Transform>();
                    Vector3 tPosi = tPos.position;
                    tPosi.z = -5f;
                    tPos.position = tPosi;
                }
            }
        }
    }
    
}
