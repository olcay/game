using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectScreenScript : MonoBehaviour
{
    [SerializeField]
    Button btnNewStart;

    [SerializeField]
    AudioSource btnNewStartAudio;

    // Start is called before the first frame update
    void Start()
    {
        
        btnNewStart.onClick.AddListener(StartTheGame);
    }

    void StartTheGame()
    {
        string levelID = "Level1";
        btnNewStartAudio.Play();
        SceneManager.LoadScene(levelID);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartTheGame();
        }
    }
}
