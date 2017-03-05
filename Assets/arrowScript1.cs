using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript1 : MonoBehaviour {
    public GameObject scenes;
    float moveSpeed = 4f;
    bool moveRight1 = false;
    bool moveRight2 = false;
    public bool rightPressed;
    bool leftPressed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        leftPressed = GameObject.Find("leftArrow").GetComponent<arrowScript2>().leftPressed;
        //  scenes = GameObject.Find("sceneHandling");
        Vector3 pos = scenes.GetComponent<Transform>().position;
        Vector3 scene3 = new Vector3(-30.3f, 0, 5);
        Vector3 scene2 = new Vector3(-15.11f, 0, 5);

        int index = scenes.GetComponent<sceneScript>().sceneIndex;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(mouseWorldPos))
            {
                rightPressed = true;
                rightPressed = false;
                if (index == 2)
                {
                    index = 3;
                    moveRight2 = true;

                    Debug.Log("go to scene1 pleaaase");
                }
                else if (index == 1)
                {
                    index = 2;
                    moveRight1 = true;
                    Debug.Log("go to scene2, yo");
                }
                else
                {
                    moveRight1 = false;
                    moveRight2 = false;
                }

            }
        }
/*
        if (leftPressed)
        {
            moveRight2 = false;
            moveRight1 = false;
        }

    */

        if (moveRight1) 
        {
            pos = Vector3.MoveTowards(pos, scene2, moveSpeed * Time.deltaTime);
            if (pos == scene2)
            {
                moveRight1 = false;
                rightPressed = false;
            }

        }
        if (moveRight2)
        {
            pos = Vector3.MoveTowards(pos, scene3, moveSpeed * Time.deltaTime);
            if (pos == scene3)
            {
                rightPressed = false;
                moveRight2 = false;
            }
        }

        scenes.GetComponent<Transform>().position = pos;
        scenes.GetComponent<sceneScript>().sceneIndex = index;
    }
}
