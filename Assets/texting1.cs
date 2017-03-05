using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texting1 : MonoBehaviour {
    public string[] messages;
    string j;
    public int currentMessageIndex = 0;
    public float moveTime;

    public GameObject messageText;
    public GameObject responseText;

    public GameObject texter;
    Transform textScreen;

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
    bool getOff2 = false;

    //float timer = 0f;
    //float delay = .1f;

    // Use this for initialization
    void Start()
    {
        _lastResponse = Instantiate(responseText) as GameObject;
        //_lastResponse.transform.parent = textSceen;
        _lastResponse.transform.position = lastResPos;
        _lastMessageObj = Instantiate(messageText) as GameObject;
       // _lastMessageObj.transform.parent = textScreen;
        _lastMessageObj.transform.position = firstPos;
        currentMessageIndex = 1;

    }

    // Update is called once per frame
    void Update()
    {
        textScreen = texter.GetComponent<Transform>();   
        int i = GameObject.Find("respond").GetComponent<yesButton>().i;
        currentMessageIndex = i;
        j = GameObject.Find("respond").GetComponent<yesButton>().currentResponse;
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

            Invoke("killOffText", 1.3f);
        }
        if (_lastMessageObj != null)
        {
            if (textExiting)
            {
                
                Invoke("pleaseLeave", .1f);
                if (!getOff2)
                {
                    _lastMessageObj.transform.localPosition
                            = Vector3.MoveTowards(_lastMessageObj.transform.localPosition, lastPos, messageLeaveSpeed * Time.deltaTime);
                    Invoke("pleaseLeave2", .9f);
                }

                if (getOff2)
                {
                    _lastMessageObj.transform.localPosition
                     = Vector3.MoveTowards(_lastMessageObj.transform.localPosition, offPos, messageLeaveSpeed * Time.deltaTime);
                }

                if (getOff)
                {
                    _lastResponse.transform.localPosition = Vector3.MoveTowards(_lastResponse.transform.localPosition, offResPos, responseMoveSpeed * Time.deltaTime);
                    Invoke("killOffResponse", .1f);
                }


                Invoke("notExiting", 1f);

            }

            if (!getOff)
            {
                    _lastResponse.transform.localPosition = Vector3.MoveTowards(_lastResponse.transform.localPosition, firstResPos, messageMoveSpeed * Time.deltaTime);

                    Invoke("moveMe", moveTime);
            }

            if (textEntering)
            {
                _lastMessageObj.transform.localPosition
            = Vector3.Lerp(_lastMessageObj.transform.localPosition, firstPos, messageMoveSpeed * Time.deltaTime);
                _lastResponse.transform.localPosition = Vector3.MoveTowards(_lastResponse.transform.localPosition, lastResPos, messageMoveSpeed * Time.deltaTime);

                Invoke("notEntering", 1f);


            }

        }
    }



    void killOffText()
    {
        getOff = true;
        getOff2 = false;
        Destroy(_lastMessageObj);
        move = true;
        _lastMessageObj = Instantiate(messageText) as GameObject;
        //_lastMessageObj.transform.parent = textScreen;
        _lastMessageObj.transform.localPosition = new Vector3(-4.65f, -1.20f, -3);
        // Apply the string to the text here probably // 
        TextMesh text = _lastMessageObj.GetComponent<TextMesh>();
        text.text = messages[currentMessageIndex];
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
       // _lastResponse.transform.parent = textScreen;
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

    void pleaseLeave2()
    {
            getOff2 = true;
    }
    
    
}
    


    

