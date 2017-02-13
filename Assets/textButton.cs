using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textButton : MonoBehaviour {

    static public bool atHome = true;

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
                Debug.Log("clicked");
                GameObject textScreen = GameObject.Find("textScreen");
                Transform tPos = textScreen.GetComponent<Transform>();
                Vector3 tPosi = tPos.position;
                tPosi.z = -5f;
                tPos.position = tPosi;
            }
        }
    }
}
