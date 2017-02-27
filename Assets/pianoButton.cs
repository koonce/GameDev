using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pianoButton : MonoBehaviour {

    public AudioClip piano;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
            AudioSource audio = GameObject.Find("play").GetComponent<AudioSource>();
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos))
                {
                    bool playing = audio.isPlaying;
                    Debug.Log("piano pressed");
                    audio.clip = piano;
                    if (playing)
                    {
                        audio.Play();
                    }

                }
            }

    }
}
