using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    public int lives;
    public bool gamePlaying = true;
    public GameObject gameOver;
    public GameObject resetter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lives = GameObject.Find("forbidden").GetComponent<living>().life;
        bool resetting = resetter.GetComponent<resetGameButton>().reset;
       
        if (resetting == true)
        {
            gamePlaying = true;
          //  resetting = false;
        }

		if (lives <= 0)
        {
            gamePlaying = false;
            gameOver.SetActive(true);
            resetter.SetActive(true);
        }
	}
}
