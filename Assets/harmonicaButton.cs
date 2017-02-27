using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harmonicaButton : MonoBehaviour {

    public AudioClip harmonica;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject screen = GameObject.Find("musicScreen");
        Transform mPos = screen.GetComponent<Transform>();
        if (mPos.position.z <= -5)
        {
            AudioSource audio = GameObject.Find("play").GetComponent<AudioSource>();
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos))
                {
                    bool playing = audio.isPlaying;
                    Debug.Log("harmonica pressed");
                    audio.clip = harmonica;
                    if (playing)
                    {
                        audio.Play();
                    }

                }
            }
        }
    }
}
