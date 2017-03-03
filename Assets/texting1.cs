using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texting1 : MonoBehaviour {
    public string[] messages;
    public int currentMessageIndex = 0;

    public GameObject messageText;

    public float messageMoveSpeed = 10f;
    public float messageLeaveSpeed = 10f;

    bool textEntering = false;
    bool textExiting = false;

    bool pressed = false;

    GameObject _lastMessageObj;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 firstPos = new Vector3(-4.5f, .20f, -5);
            Vector3 lastPos = new Vector3(-4.5f, 2, -5);

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GameObject.Find("respond").GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos) || GameObject.Find("respond").GetComponent<PolygonCollider2D>().OverlapPoint(mouseWorldPos))
            {
                pressed = true;
            }
        }
        if (pressed) { 
                textExiting = true;
                Invoke("killOffText", 1f);
            Invoke("clicked", 0.1f);
            }
            if (_lastMessageObj != null)
            {
                if (textExiting)
                {
                    _lastMessageObj.transform.localPosition
                            = Vector3.MoveTowards(_lastMessageObj.transform.localPosition, lastPos, messageLeaveSpeed * Time.deltaTime);
                }
                if (textEntering)
                {
                    _lastMessageObj.transform.localPosition
                = Vector3.Lerp(_lastMessageObj.transform.localPosition, firstPos, messageMoveSpeed * Time.deltaTime);
                Invoke("notEntering", 1f);
                }
            }

    }


    /*void bringInText()
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
}*/

    void killOffText()
    {
        Destroy(_lastMessageObj);
        _lastMessageObj = Instantiate(messageText) as GameObject;
        _lastMessageObj.transform.localPosition = new Vector3(-4.65f, -1.20f, -5);
        // Apply the string to the text here probably // 
        textEntering = true;
        textExiting = false;
        /*Vector3 pos = _lastMessageObj.transform.localPosition;
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
           // } */
    }

        void notEntering() 
            {
            textEntering = false;
            }
    void clicked()
    {
        pressed = false;
    }
    
    
}
    


    

