using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yesButton : MonoBehaviour
{
    public float counter = 1f;
    public float scaleSpeed = 4f;
    public bool texting = false;

    public static Color blue = new Color(0, 0, 1, 1);
    public static Color black = new Color(0, 0, 0, 1);

    public int strangerIndex = 0;

    bool clicked = false;

    public int i = 1;
    int g = 5;
    string[] yResponses = new string[] {
        "yes button", "yes", "no, I'm actually busy", "someone's in a great mood", "YOU'RE the bitch", "wtf?", "thanks", "you're hilarious", "[CLICK TO END]"
    };
    string[] nResponses = new string[] {
       "no button", "no", "thank you", "bitch", "thanks", "dungarees", "i know", "don't call me Jesus", "[CLICK TO END]"
    };

    public string currentResponse;


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
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Color textColor = GameObject.Find("yes").GetComponent<TextMesh>().color;
        Color textColor2 = GameObject.Find("no").GetComponent<TextMesh>().color;

       /* if (GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos))
        {
            Debug.Log("overlapping");
            textColor = blue;
        }
        else
        {
            textColor = black;
        }

        if (GetComponent<PolygonCollider2D>().OverlapPoint(mouseWorldPos))
        {
            textColor2 = blue;
        }
        else
        {
            textColor2 = black;
        }

    */

        if (Input.GetMouseButtonDown(0))
            {
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
                    i = 8;
                    strangerIndex = 1;
                }
                else if (i == 8)
                {
                    strangerIndex = 1;
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
                    i = 8;
                }
                else if (i == 8)
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