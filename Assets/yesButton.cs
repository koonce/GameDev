using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yesButton : MonoBehaviour {
    public float counter = 1f;
    
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
                
                Debug.Log("Yes");
                TextMesh textObject = GameObject.Find("question").GetComponent<TextMesh>();
                textObject.text = "thank god.";

                TextMesh answer1 = GameObject.Find("yes").GetComponent<TextMesh>();

                TextMesh respond = GameObject.Find("response").GetComponent<TextMesh>();
                respond.text = answer1.text;

                answer1.text = "are you okay?";

                TextMesh answer2 = GameObject.Find("no").GetComponent<TextMesh>();
                answer2.text = "what?";

                counter = 3f;
            }

        }
    }
}
