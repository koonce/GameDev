using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guitarButton : MonoBehaviour {

    public AudioClip guitar;

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
                    Debug.Log("piano pressed");
                    audio.clip = guitar;
                    if (playing)
                    {
                        audio.Play();
                    }

                }
            }
        }
    }
}
