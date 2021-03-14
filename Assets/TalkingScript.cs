using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingScript : MonoBehaviour
{
    Canvas talkBox;

    Text talkText;

    // Start is called before the first frame update
    void Start()
    {
        talkBox = GetComponent<Canvas>();
        talkText = GetComponentInChildren<Text>();
        HideTalkingBox();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowMonolog(string text, int fontSize = 20)
    {
        var isNewText = talkText.text != text;
        
        if (isNewText)
        {
            talkText.text = text;
            talkText.fontSize = fontSize;
            talkBox.enabled = true;
            CancelInvoke("HideTalkingBox");
            Invoke("HideTalkingBox", 4f);
        }
    }

    void HideTalkingBox()
    {
        talkBox.enabled = false;
    }
}
