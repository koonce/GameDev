using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicalButton : MonoBehaviour {

    public GameObject musicScreen;
    public GameObject homeScreen;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<Collider2D>().OverlapPoint(mouseWorldPos))
                {
                    Debug.Log("click music");
                musicScreen.SetActive(true);
                homeScreen.SetActive(false);
                }
            }
    }
}