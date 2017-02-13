using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whatsOpen : MonoBehaviour {

    public bool text = false;
    public bool pic = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject texting = GameObject.Find("textScreen");
        Vector3 textPos = texting.transform.position;
        if (textPos.z >= -5)
        {
            text = true;
        }
        else
        {
            text = false;
        }
        texting.transform.position = textPos;

        GameObject pictures = GameObject.Find("picScreen");
        Vector3 picPos = pictures.transform.position;
        if (picPos.z == -6)
        {
            pic = true;
            Debug.Log("we looking at pics");
        }
        else
        {
            pic = false;
        }
	}
}
