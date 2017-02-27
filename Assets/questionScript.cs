using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questionScript : MonoBehaviour {

    TextMesh _text;

    public bool answered = false;

    public bool sent = false;

    public float scaleSpeed = 4f;

    int thisText = 0;
    int nextText = 1;

    public int currentText;


    // Use this for initialization
    void Start()
    {
        _text = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {

        currentText = thisText;

        if (GameObject.Find("respond").GetComponent<yesButton>().answer)
        {
            answered = true;
        }

            // First Method, text scales in. 
            float scale = transform.localScale.x;
        scale += scaleSpeed * Time.deltaTime;
        if (scale > 1f)
        {
            scale = 1;
        }
        transform.localScale = new Vector3(scale, scale, scale);
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GameObject.Find("respond").GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos) || GameObject.Find("respond").GetComponent<PolygonCollider2D>().OverlapPoint(mouseWorldPos))
            {
                 currentText = thisText;
                Debug.Log("thisText");
                if (GameObject.Find("respond").GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos) || GameObject.Find("respond").GetComponent<PolygonCollider2D>().OverlapPoint(mouseWorldPos))
                {
                    Debug.Log("nextText");
                    currentText = nextText;
                }
            }
        }
    }
}
