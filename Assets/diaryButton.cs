using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diaryButton : MonoBehaviour {

    public GameObject homeScreen;
    public GameObject diary;

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
                    Debug.Log("click diary");
                    diary.SetActive(true);
                homeScreen.SetActive(false);

                }
            }
    }
    
}
