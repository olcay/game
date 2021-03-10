using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NanyScript : MonoBehaviour
{
    [SerializeField]
    GameObject nanyTalkCanvas;

    // Start is called before the first frame update
    void Start()
    {
        nanyTalkCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            nanyTalkCanvas.SetActive(true);
            Invoke("RecoverHit", 10f);
        }
    }

    void RecoverHit()
    {
        nanyTalkCanvas.SetActive(false);
    }
}
