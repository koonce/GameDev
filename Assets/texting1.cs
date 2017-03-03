using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texting1 : MonoBehaviour {
    public string[] messages;
    public int currentMessageIndex = 0;
    public float moveTime;

    public GameObject messageText;
    public GameObject responseText;

    public float messageMoveSpeed = 10f;
    public float messageLeaveSpeed = 10f;
    public float responseMoveSpeed = 7f;
    public float responseLeaveSpeed = 7f;

    bool textEntering = false;
    bool textExiting = false;
    bool textOff = true;
    bool textOn = true;
    bool moveToSpot = false;

    bool pressed = false;

    bool move = false;

    GameObject _lastMessageObj;
    GameObject _lastResponse;

    Vector3 responseLocation;

    Vector3 firstResPos = new Vector3(4.47f, -.13f, -5);
    Vector3 lastResPos = new Vector3(4.47f, 1.91f, -5);
    Vector3 offResPos = new Vector3(4.47f, 2.7f, -4);


    Vector3 firstPos = new Vector3(-4.67f, -0.67f, -5);
    Vector3 lastPos = new Vector3(-4.67f, 1.51f, -5);
    Vector3 offPos = new Vector3(-4.67f, 2.35f, -4);

    int responseIndex = 0;
    bool getOff = true;

    //float timer = 0f;
    //float delay = .1f;

    // Use this for initialization
    void Start()
    {
        _lastResponse = Instantiate(responseText) as GameObject;
        _lastResponse.transform.position = lastResPos;
        _lastMessageObj = Instantiate(messageText) as GameObject;
        _lastMessageObj.transform.position = firstPos;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 response = GameObject.Find("respond").GetComponent<yesButton>().response;
        responseLocation = response;


        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GameObject.Find("respond").GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos) || GameObject.Find("respond").GetComponent<PolygonCollider2D>().OverlapPoint(mouseWorldPos))
            {
                pressed = true;
                Invoke("clicked", .5f);
            }
        }
        if (pressed)
        {
            textExiting = true;
            //timer += Time.deltaTime;


            // Invoke("killOffResponse", .1f);
            Invoke("killOffText", 1.3f);
            //Invoke("clicked", 0.1f);
        }
        if (_lastMessageObj != null)
        {
            if (textExiting)
            {
                // if (textOff)
                // {
                _lastMessageObj.transform.localPosition
                        = Vector3.MoveTowards(_lastMessageObj.transform.localPosition, lastPos, messageLeaveSpeed * Time.deltaTime);
                if (getOff)
                {
                    _lastResponse.transform.localPosition = Vector3.MoveTowards(_lastResponse.transform.localPosition, offResPos, responseMoveSpeed * Time.deltaTime);
                    Invoke("killOffResponse", .1f);
                }

                //  if (!move)
                //  {
                //    _lastResponse.transform.localPosition = Vector3.MoveTowards(_lastResponse.transform.localPosition, firstResPos, messageMoveSpeed * Time.deltaTime);

                Invoke("notExiting", 1f);

            }

            if (!getOff)
            {
                    _lastResponse.transform.localPosition = Vector3.MoveTowards(_lastResponse.transform.localPosition, firstResPos, messageMoveSpeed * Time.deltaTime);
                

                    _lastResponse.transform.localPosition = Vector3.MoveTowards(_lastResponse.transform.localPosition, lastResPos, messageMoveSpeed * Time.deltaTime);

                    Invoke("moveMe", moveTime);
            }

            if (textEntering)
            {
                _lastMessageObj.transform.localPosition
            = Vector3.Lerp(_lastMessageObj.transform.localPosition, firstPos, messageMoveSpeed * Time.deltaTime);
                _lastResponse.transform.localPosition = Vector3.MoveTowards(_lastResponse.transform.localPosition, lastResPos, messageMoveSpeed * Time.deltaTime);

                Invoke("notEntering", 1f);
                //   if (!getOff)
                // {
                //        _lastResponse.transform.localPosition = Vector3.MoveTowards(_lastResponse.transform.localPosition, lastResPos, responseMoveSpeed * Time.deltaTime);
                //  }
                //  if (getOff)
                //  {

                //   }
                //  }
                //  if (textOff)
                // {
                //    _lastResponse.transform.localPosition = Vector3.MoveTowards(_lastResponse.transform.localPosition, offResPos, messageMoveSpeed * Time.deltaTime);
                // }


            }

        }
    }



    void killOffText()
    {
        getOff = true;
        Destroy(_lastMessageObj);
        move = true;
        _lastMessageObj = Instantiate(messageText) as GameObject;
        _lastMessageObj.transform.localPosition = new Vector3(-4.65f, -1.20f, -3);
        // Apply the string to the text here probably // 
        textEntering = true;
        textOff = false;
        textExiting = false;
      //  moveToSpot = false;
    }

    void notEntering() 
    {
        textEntering = false;
    }

    void notExiting()
    {
        textOff = false;
    }

    void clicked()
    {
        pressed = false;
    }
    
    void killOffResponse()
    {
        Destroy(_lastResponse);
        _lastResponse = Instantiate(responseText) as GameObject;
        _lastResponse.transform.localPosition = responseLocation;
        getOff = false;
    }

    void moveMe()
    {
        moveToSpot = true;
    }

    void pleaseLeave()
    {
        getOff = false;
    }
    
    
}
    


    

