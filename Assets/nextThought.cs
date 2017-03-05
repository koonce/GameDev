using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextThought : MonoBehaviour {

    int saying = 0;
        public GameObject words;

    public string[] talk = new string[]
{
        "hey good \n lookin'",
        "the weather \n is fine \n today",
        "politics... \n am i right?",
        "take \n care now"
};


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        TextMesh thought = words.GetComponent<TextMesh>();
        thought.text = talk[saying];

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos))
            {
                saying++;
            }
            if (saying > talk.Length-1)
        {
                saying = talk.Length - 1;
            GameObject speech = GameObject.Find("bubble");
            speech.SetActive(false);
        }
        }


    }
}
