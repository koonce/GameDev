using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetGameButton2 : MonoBehaviour {

    public GameObject[] bricks;
    public GameObject gameOver;
    public bool reset = false;
    public bool reset2 = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //  bool game = GameObject.Find("gameManager").GetComponent<GM>().gamePlaying;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(mouseWorldPos))
            {

                for (int i = 0; i < bricks.Length; i++)
                {
                    bricks[i].SetActive(true);
                }
                reset = true;
                reset2 = true;
                GameObject.Find("forbidden").GetComponent<living>().ableToBeReset = true;
                Debug.Log("definitely clicking");
                //  gameOver.SetActive(false);

            }
        }
    }
}
