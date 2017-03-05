using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickScript : MonoBehaviour {

    public GameObject reset;
 
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (reset.GetComponent<resetGameButton>().reset)
        {
            if (gameObject == null)
            {
                gameObject.SetActive(true);
                Debug.Log("weHearYou");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "ball")
        {
            gameObject.SetActive(false);
        }
    }
}
