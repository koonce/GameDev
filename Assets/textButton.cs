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
                GameObject home = GameObject.Find("homeScreen");
                Transform homePos = home.GetComponent<Transform>();
                Vector3 homePosi = homePos.position;
                homePosi.x = 15f;
                homePos.position = homePosi;
                atHome = false;
            }
        }
    }
}
