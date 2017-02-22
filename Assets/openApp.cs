using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openApp : MonoBehaviour {
    public bool open = false;

    Transform texting;
    Transform pictures;
    Transform music;
    Transform diary;


    // Use this for initialization
    void Start () {
        texting = GameObject.Find("textScreen").GetComponent<Transform>();
        pictures = GameObject.Find("picScreen").GetComponent<Transform>();
        music = GameObject.Find("musicScreen").GetComponent<Transform>();
        diary = GameObject.Find("diaryScreen").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		if (texting.position.z <= -5 || pictures.position.z <= -5 || music.position.z <= -5 || diary.position.z <= -5)
        {
            open = true;
        }
        else
        {
            open = false;
        }
	}
}
