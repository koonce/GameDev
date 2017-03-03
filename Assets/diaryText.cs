using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diaryText : MonoBehaviour {
    int howMuch = 0;
    int howLittle = 40;


    string[] dEntries = new string[]
    {
        "Whose woods these are I \nthink I know.\nHis house is in the village though;\nHe will not see me stopping here\nTo watch his woods fill up with snow.",
        "My little horse must think it\nqueer\nTo stop without a farmhouse near\nBetween the woods and frozen lake\nThe darkest evening of the year.",
        "He gives his harness bells a\nshake\nTo ask if there is some mistake.\nThe only other sound’s the sweep\nOf easy wind and downy flake.",
        "The woods are lovely, dark\nand deep,\nBut I have promises to keep,\nAnd miles to go before I sleep,\nAnd miles to go before I sleep."
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
