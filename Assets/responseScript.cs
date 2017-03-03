﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class responseScript : MonoBehaviour {

    TextMesh _text;

    public float scaleSpeed = 4f;




    // Use this for initialization
    void Start()
    {
        _text = GetComponent<TextMesh>();
        
        //transform.localScale = Vector3.zero;


    }

    // Update is called once per frame
    void Update()
    {
        string j = GameObject.Find("respond").GetComponent<yesButton>().currentResponse;
        _text.text = j;

        // First Method, text scales in. 
        float scale = transform.localScale.x;
        scale += scaleSpeed * Time.deltaTime;
        if (scale > 1f)
        {
            scale = 1;
        }
        transform.localScale = new Vector3(scale, scale, scale);

        // Second Method, scrolls from offscreen onto the screen.



    }
}
