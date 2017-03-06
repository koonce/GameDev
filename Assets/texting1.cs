using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texting1 : MonoBehaviour {
    public string[] messages;
    string j;
    public int currentMessageIndex = 0;
    public float moveTime;

    bool gameStarted = false;

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

    Vector3 firstResPos = new Vector3(.472f, -.06f, -3);
    Vector3 lastResPos = new Vector3(.472f, .36f, -3);
    Vector3 offResPos = new Vector3(.472f, .6f, -1);


    Vector3 firstPos = new Vector3(-.48f, -0.16f, -3);
    Vector3 lastPos = new Vector3(-.48f, .30f, -3);
    Vector3 offPos = new Vector3(-.48f, .42f, -1);

    int responseIndex = 0;
    bool getOff = true;
    bool getOff2 = false;

    //float timer = 0f;
    //float delay = .1f;

    // Use this for initialization
    void Start()
    {
 

    }

    // Update is called once per frame
    void Update()
    {
        textScreen = texter.GetComponent<Transform>();   
        int i = GameObject.Find("respond").GetComponent<yesButton>().i;
        currentMessageIndex = i;
        j = GameObject.Find("respond").GetComponent<yesButton>().currentResponse;
        Vector3 response = GameObject.Find("respond").GetComponent<yesButton>().response;
        Vector3 response2 = new Vector3(response.x * .1f, response.y * .1f, response.z * .1f);
        responseLocation = response2;

        if (!gameStarted)
        {
            _lastResponse = Instantiate(responseText) as GameObject;
            _lastResponse.transform.parent = textScreen;
            _lastResponse.transform.position = new Vector3(4.86f, 3.41f, -5);
            _lastMessageObj = Instantiate(messageText) as GameObject;
            _lastMessageObj.transform.position = new Vector3(-4.83f, -.90f, -5);
            _lastMessageObj.transform.parent = textScreen;
             _lastMessageObj.transform.localScale = new Vector3(1f, 1f, 1);
            
            currentMessageIndex = 1;
            gameStarted = true;
        }


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
        _lastMessageObj.transform.parent = textScreen;
        _lastMessageObj.transform.localScale = new Vector3(.1f, .1f, 1);
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
        _lastResponse.transform.parent = textScreen;
        _lastResponse.transform.localScale = new Vector3(.1f, .1f, 1);
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
    


    

