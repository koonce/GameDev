using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<Collider2D>().OverlapPoint(mouseWorldPos))
                {
                    Debug.Log("clicked");
                    GameObject textScreen = GameObject.Find("textScreen");
                    //var textScript = textScreen.GetComponent<yesButton>();
                    Transform tPos = textScreen.GetComponent<Transform>();
                    Vector3 tPosi = tPos.position;
                    tPosi.z = 1;
                    tPos.position = tPosi;
                    //textScript.texting = false;
                }
            }
    }
}
