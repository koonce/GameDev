using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texting1 : MonoBehaviour {
    public string[] messages;
    public int currentMessageIndex = 0;

    public GameObject messageText;

    public float messageMoveSpeed = 10f;
    public float messageLeaveSpeed = 5f;

    int currentText = 0;

    GameObject _lastMessageObj;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


            bool pressed = false;
            bool answered = GameObject.Find("respond").GetComponent<yesButton>().answer;
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GameObject.Find("respond").GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos) || GameObject.Find("respond").GetComponent<PolygonCollider2D>().OverlapPoint(mouseWorldPos))
            {
                if (currentText == 0)
                {
                    pressed = true;
                }
                if (currentText == 1)
                {
                    pressed = false;
                }
            }
            if (pressed) { 
            Invoke("bringInText", 0f);
        }
        else if (!pressed)
            { 
            Invoke("killOffText", 0f);
            }

        

        }

    }


        void bringInText()
    {

            _lastMessageObj = Instantiate(messageText) as GameObject;
            _lastMessageObj.transform.parent = transform;
            _lastMessageObj.transform.localPosition = new Vector3(0, -2, 0);
            TextMesh text = _lastMessageObj.GetComponent<TextMesh>();

            int whatMessage = GameObject.Find("respond").GetComponent<yesButton>().i;
            text.text = messages[whatMessage];
            //currentMessageIndex++;
            if (currentMessageIndex >= messages.Length)
            {
                currentMessageIndex = 0;
            }
        

        if (_lastMessageObj != null)
        {
            _lastMessageObj.transform.localPosition
            = Vector3.Lerp(_lastMessageObj.transform.localPosition,
                Vector3.zero, messageMoveSpeed * Time.deltaTime);
            Vector3 pos = _lastMessageObj.transform.localPosition;

            if (pos.y >= 0)
            {
                Debug.Log("does this ever fucking happen");
            }

            currentText = 1;
        }
    }

        void killOffText()
    {
        Vector3 pos = _lastMessageObj.transform.localPosition;
        Debug.Log("i'm here");
        bool clickedHim = false;
        //if (currentText == 1)
        //{
           // if (Input.GetMouseButtonDown(0))
            //{
              //  Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //if (GameObject.Find("respond").GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos) || GameObject.Find("respond").GetComponent<PolygonCollider2D>().OverlapPoint(mouseWorldPos))
                //{
                   // clickedHim = true;
               // }
           // }
            //if (clickedHim)
            //{
                bool weHere = false;
                if (_lastMessageObj != null)
                { 
                    pos
                        = Vector3.MoveTowards(pos,
                            Vector3.up, messageLeaveSpeed * Time.deltaTime);

            _lastMessageObj.transform.localPosition = pos;
                    if (pos == Vector3.up)
                    {
                        weHere = true;
                    }

                    if (weHere)
                    { 
              
                    Destroy(_lastMessageObj);
                    Debug.Log("delete me");
                    //currentText = 0;
                     }
                }
           // }
       // }
    }
}
    


    

