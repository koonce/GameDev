using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pictures : MonoBehaviour {

    public Sprite[] dogs = new Sprite[3];
    int i = 0;

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = dogs[i];
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos))
            {

                i++;
                if (i >= dogs.Length)
                {
                    i = 0;
                }

            }
            if (GetComponent<PolygonCollider2D>().OverlapPoint(mouseWorldPos))
            {
                if (i <= 0) 
                {
                    i = dogs.Length;
                }
                i--;
            }
        }
    }
}
