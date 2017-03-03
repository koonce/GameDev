using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yesButton : MonoBehaviour
{
    public float counter = 1f;
    public float scaleSpeed = 4f;
    public bool texting = false;

    bool clicked = false;

    public int i = 1;
    int g = 5;
    string[] yResponses = new string[] {
        "yes button", "yes", "no, I'm actually busy", "someone's in a great mood", "YOU'RE the bitch", "wtf?", "thanks", "you're hilarious"
    };
    string[] nResponses = new string[] {
       "no button", "no", "thank you", "bitch", "thanks", "dungarees", "i know", "don't call me Jesus"
    };

    public string currentResponse;

    //public string[] qS = new string[] { "blue", "red", "green", "orange", "purple", "apples", "bananas", "pears" };

    public Vector3 response;

    // Use this for initialization
    void Start()
    {
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {
        TextMesh text = GameObject.Find("yes").GetComponent<TextMesh>();
        text.text = yResponses[i];
        TextMesh text2 = GameObject.Find("no").GetComponent<TextMesh>();
        text2.text = nResponses[i];

        if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos))
                {
                currentResponse = yResponses[i];
                response = GameObject.Find("yes").GetComponent<Transform>().position;

                    Debug.Log("Yes");
               // Invoke("nextMessage", 1.5f);

                if (i == 1)
                {
                    i = 5;
                }
                else if (i == 2)
                {
                    i = 4;
                }
                else if (i == 3 || i == 4 || i == 6 || i == 7)
                {
                    Invoke("endOfGame", 3f);
                    Debug.Log("end");
                }
                else if (i == 5)
                {
                    i = 7;
                }
                


            }
        }
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<PolygonCollider2D>().OverlapPoint(mouseWorldPos))
                {
                currentResponse = nResponses[i];
              //  Invoke("nextMessage2", 1.5f);
                response = GameObject.Find("no").GetComponent<Transform>().position;

                    Debug.Log("No");
                  //  TextMesh textObject = GameObject.Find("question").GetComponent<TextMesh>();

                if (i == 1)
                {
                    i = 2;
                    Debug.Log("wow, you're funny");
                }
                else if (i == 2)
                {
                    i = 3;
                }
                else if (i == 3 || i == 4 || i == 6 || i == 7)
                {
                    Invoke("endOfGame", 3f);
                    Debug.Log("end");
                }
                else if (i == 5)
                {
                    i = 6;
                }
            }
            }
        
    }

    void endOfGame()
    {
        SceneManager.LoadScene("gameOver");
    }

    void nextMessage()
    {

        clicked = true;

        TextMesh answer1 = GameObject.Find("yes").GetComponent<TextMesh>();
        answer1.text = yResponses[i];

        TextMesh answer2 = GameObject.Find("no").GetComponent<TextMesh>();
        answer2.text = nResponses[i];

    }

    void nextMessage2()
    {

        clicked = true;

        TextMesh answer1 = GameObject.Find("yes").GetComponent<TextMesh>();
        answer1.text = yResponses[i];

        TextMesh answer2 = GameObject.Find("no").GetComponent<TextMesh>();
        answer2.text = nResponses[i];
        clicked = false;
    }
}