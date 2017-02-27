using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diaryText : MonoBehaviour {
    int howMuch = 0;
    int howLittle = 40;


    string[] dEntries = new string[]
    {
        "hello",
        "goodbye",
        "what up",
        "i feel great"
    };

	// Use this for initialization
	void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {
            TextMesh diary = GetComponent<TextMesh>();
            diary.text = dEntries[howMuch];
                //entries.Substring(howMuch, howLittle);
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos) && howMuch > 0)
                {

                    howMuch--;
                    //-= howLittle;

                }
                if (GetComponent<PolygonCollider2D>().OverlapPoint(mouseWorldPos) && howMuch < dEntries.Length-1)
                {
                        howMuch++;

                }

            }
        

    }
}
