using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picButton : MonoBehaviour {

    public bool picOpen = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Phone").GetComponent<openApp>().open)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<Collider2D>().OverlapPoint(mouseWorldPos))
                {
                    Debug.Log("Pic Clicked!");
                    GameObject pics = GameObject.Find("picScreen");
                    Transform picPos = pics.GetComponent<Transform>();
                    Vector3 picPosi = picPos.position;
                    picPosi.z = -5f;
                    picPos.position = picPosi;
                }
                picOpen = true;
            }
        }
    }

}
