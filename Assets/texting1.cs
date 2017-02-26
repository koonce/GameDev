using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texting1 : MonoBehaviour {
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (_lastMessageObj != null)
            {
                Destroy(_lastMessageObj);
            }
            _lastMessageObj = Instantiate(messageText) as GameObject;
            _lastMessageObj.transform.parent = transform;
            _lastMessageObj.transform.localPosition = new Vector3(0, -2, 0);
            TextMesh text = _lastMessageObj.GetComponent<TextMesh>();
            text.text = messages[currentMessageIndex];
            currentMessageIndex++;
            if (currentMessageIndex >= messages.Length)
            {
                currentMessageIndex = 0;
            }
        }

        if (_lastMessageObj != null)
        {

            // The Move towards method (actually moving linearly)
            //_lastMessageObj.transform.localPosition 
            //= Vector3.MoveTowards(_lastMessageObj.transform.localPosition,
            //	Vector3.zero, messageMoveSpeed*Time.deltaTime);

            // The Lerp method (actually moving exponentially)
            _lastMessageObj.transform.localPosition
            = Vector3.Lerp(_lastMessageObj.transform.localPosition,
                Vector3.zero, messageMoveSpeed * Time.deltaTime);

        }

    }
}
