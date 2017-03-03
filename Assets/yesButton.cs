using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yesButton : MonoBehaviour
{
    public float counter = 1f;
    public float scaleSpeed = 4f;
    public bool texting = false;
    public bool answer = false;
    public bool yesss;

    public int i;
    int g = 5;
    public string[] yResponses = new string[] { "alright", "okay", "yeah", "yes", "yep", "vegetables?", "don't peel", "eat!" };
    public string[] nResponses = new string[] { "no", "no sir", "nah", "never", "oh", "fruit?", "peel them", "don't eat!" };
    public string[] qS = new string[] { "blue", "red", "green", "orange", "purple", "apples", "bananas", "pears" };

    public Vector3 response;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos))
                {

                response = GameObject.Find("yes").GetComponent<Transform>().position;
                    Debug.Log("Yes");

                    TextMesh answer1 = GameObject.Find("yes").GetComponent<TextMesh>();

                    answer1.text = yResponses[i];

                    TextMesh answer2 = GameObject.Find("no").GetComponent<TextMesh>();
                    answer2.text = nResponses[i];

                    i++;
                yesss = true;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<PolygonCollider2D>().OverlapPoint(mouseWorldPos))
                {
                response = GameObject.Find("no").GetComponent<Transform>().position;
                yesss = false;
                    answer = true;

                    i = g;
                    g++;
                    Debug.Log("No");
                    TextMesh textObject = GameObject.Find("question").GetComponent<TextMesh>();
                    textObject.text = qS[i];

                    TextMesh answer1 = GameObject.Find("yes").GetComponent<TextMesh>();
                    answer1.text = yResponses[i];

                    TextMesh respond = GameObject.Find("response").GetComponent<TextMesh>();

                    TextMesh answer2 = GameObject.Find("no").GetComponent<TextMesh>();

                    answer2.text = nResponses[i];
                    if (g >= nResponses.Length)
                    {
                        g = 0;
                    }
                    i = g;
                }
            }
        
    }
}