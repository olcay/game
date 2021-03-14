using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour
{
    [SerializeField]
    GameObject nanyTalkCanvas;

    [SerializeField]
    string monologText;

    [SerializeField]
    int monologTextSize;

    TalkingScript talkingScript;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite openChestSprite;

    // Start is called before the first frame update
    void Start()
    {
        talkingScript = nanyTalkCanvas.GetComponent<TalkingScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.sprite = openChestSprite;

            if (monologTextSize > 0)
            {
                talkingScript.ShowMonolog(monologText, monologTextSize);
            }
            else
            {
                talkingScript.ShowMonolog(monologText);
            }

        }
    }
}
