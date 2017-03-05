using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript2 : MonoBehaviour {
    public GameObject scenes;
    float moveSpeed = 6f;
    bool moveLeft = false;
    bool moveLeft2 = false;
    public bool leftPressed;
    bool rightPressed;
    Vector3[] scene = new Vector3[3];
    int i = 1;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()

    {

        //  scenes = GameObject.Find("sceneHandling");
        Vector3 pos = scenes.GetComponent<Transform>().position;
        scene[0] = new Vector3(0, 0, 5);
        scene[1] = new Vector3(-15.11f, 0, 5);
        scene[2] = new Vector3(-30.3f, 0, 5);
        
        int index = scenes.GetComponent<sceneScript>().sceneIndex;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<CircleCollider2D>().OverlapPoint(mouseWorldPos))
            {
                if (index == 1)
                {
                    index = 2;
                    i = 1;
                }
                else if (index == 2)
                {
                    index = 3;
                    i = 2;
                }
            }
            if (GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos))
            {

                if (index == 2)
                {
                    index = 1;
                    i = 0;

                }
                else if (index == 3)
                {
                    index = 2;
                    i = 1;

                }
         

            }
        }


            pos = Vector3.MoveTowards(pos, scene[i], moveSpeed * Time.deltaTime);

        scenes.GetComponent<Transform>().position = pos;
        scenes.GetComponent<sceneScript>().sceneIndex = index;
    }
}
