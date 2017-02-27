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
        GameObject screen = GameObject.Find("diaryScreen");
        Transform mPos = screen.GetComponent<Transform>();

        if (mPos.position.z <= -5f)
        {

            //string entries = "A scrub is a guy that thinks \n he's fly  He's also known as a busta \n           Always talkin' about what he wants \n And just sits on his broke ass \n So no, I  don't want your number \n No, I don't want to give you mine and \n No, I don't want to meet you nowhere \n No, I don't want none of your time and \n No, i don't want no scrubs \n A scrub is a guy who can't get no love from me";
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


                   /* if (howMuch + howLittle < entries.Length)
                    {
                       howMuch += howLittle;
                       if ( howMuch + howLittle >= entries.Length)
                        {
                            howLittle = entries.Length - howMuch;
                        }
                        else if (howMuch + howLittle < entries.Length)
                        {
                            howLittle = 40;
                        }
                    }
                    */

                }

            }
        }

    }
}
