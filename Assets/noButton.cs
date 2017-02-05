using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !textButton.atHome)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(mouseWorldPos))
            {

                Debug.Log("No");
                TextMesh textObject = GameObject.Find("question").GetComponent<TextMesh>();
                textObject.text = "wow, you're hilarious";

                TextMesh answer1 = GameObject.Find("yes").GetComponent<TextMesh>();
                answer1.text = "i'm aware";

                TextMesh answer2 = GameObject.Find("no").GetComponent<TextMesh>();

                TextMesh respond = GameObject.Find("response").GetComponent<TextMesh>();
                respond.text = answer2.text;

                answer2.text = "thank you!";
            }

        }
    }
}
