﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusic : MonoBehaviour {

    public AudioClip guitar;
    public Sprite pause, play;

    public AudioSource audio;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update()
    {
        audio = GameObject.Find("audioObject").GetComponent<AudioSource>();
        if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos))
                {
                    if (!audio.isPlaying)
                    {
                        audio.Play();
                        Debug.Log("turn on music");
                        //}

                        //}
                        //if (audio.isPlaying)
                        //{
                        GetComponent<SpriteRenderer>().sprite = pause;
                        //   audio.Pause();
                    }
                    else
                    {
                        audio.Pause();
                        GetComponent<SpriteRenderer>().sprite = play;
                    }
                }

        }
    }
}
