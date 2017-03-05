using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    public int lives;
    public int brickNumber;
    public bool gamePlaying = true;
    public GameObject gameOver;
    public GameObject winGame;
    public GameObject resetter;
    public GameObject[] bricks;
    GameObject ball;


    // Use this for initialization
    void Start () {
        brickNumber = 12;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(brickNumber);
       ball = GameObject.Find("ball(Clone)");

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

     //   for (int i = 0; i < bricks.Length; i++)
      //  {
            //if (bricks[i] == null)
            if (brickNumber <= 0)
            {
                Debug.Log("you should win");
            Destroy(ball);
                winGame.SetActive(true);
            }
       // }
    }
}
