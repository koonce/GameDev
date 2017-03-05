using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livesScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int lives = GameObject.Find("forbidden").GetComponent<living>().life;
        TextMesh text = GetComponent<TextMesh>();
        text.text = "lives " + lives;

      //  lives = GameObject.Find("forbidden").GetComponent<living>().life;
    }
}
