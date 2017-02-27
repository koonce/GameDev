using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startConversation : MonoBehaviour
{

    public GameObject speech;
    bool cannotTalk;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cannotTalk = GameObject.Find("Phone").GetComponent<phone>().phoneUp;

        if (!cannotTalk)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos))
                {
                    Debug.Log("stranger is talking");
                    speech.SetActive(true);
                }
            }
        }
    }
}
