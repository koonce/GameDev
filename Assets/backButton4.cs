using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButton4 : MonoBehaviour {

    public GameObject homeScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject screen = GameObject.Find("diaryScreen");
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<Collider2D>().OverlapPoint(mouseWorldPos))
                {
                    Debug.Log("go back from diary");
                screen.SetActive(false);
                homeScreen.SetActive(true);
                }
            }
        
    }
}
