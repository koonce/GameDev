using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texting2 : MonoBehaviour {

    public string[] messages;
    int currentMessageIndex = 0;

    public GameObject messageText;

    public float messageMoveSpeed = 10f;

    GameObject _lastMessageObj;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TextMesh responseText = GameObject.Find("response").GetComponent<TextMesh>();
        Vector3 yesPos = new Vector3(0.4767379f, -4.4f, -1);//GameObject.Find("yes").GetComponent<Transform>().position;
        Vector3 noPos = new Vector3(0.4767379f, -5f, -1);//GameObject.Find("no").GetComponent<Transform>().position;
        Vector3 pos = new Vector3();

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GameObject.Find("respond").GetComponent<BoxCollider2D>().OverlapPoint(mouseWorldPos) || GameObject.Find("respond").GetComponent<PolygonCollider2D>().OverlapPoint(mouseWorldPos))
            {
                if (_lastMessageObj != null)
                {
                    Destroy(_lastMessageObj);
                }

                TextMesh text = _lastMessageObj.GetComponent<TextMesh>();
                text.text = "this is a new text";//responseText.text;
                _lastMessageObj = Instantiate(messageText) as GameObject;
                _lastMessageObj.transform.parent = transform;
                if (GameObject.Find("respond").GetComponent<yesButton>().yesss)
                {
                    pos = yesPos;
                }
                else if (!GameObject.Find("respond").GetComponent<yesButton>().yesss)
                {
                    pos = noPos;
                }
                _lastMessageObj.transform.localPosition = pos; // new Vector3(0, -2, 0);
//messages[currentMessageIndex];
                                               //currentMessageIndex++;
                                               //if (currentMessageIndex >= messages.Length)
                                               //{
                                               //    currentMessageIndex = 0;
                                               //}
            }
        }

        if (_lastMessageObj != null)
        {

            // The Move towards method (actually moving linearly)
            _lastMessageObj.transform.localPosition 
            = Vector3.MoveTowards(_lastMessageObj.transform.localPosition,
            	Vector3.zero, messageMoveSpeed*Time.deltaTime);

        }

    }
}
