using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectScreenScript : MonoBehaviour
{
    [SerializeField]
    Button btnNewStart;

    // Start is called before the first frame update
    void Start()
    {
        btnNewStart.onClick.AddListener(StartTheGame);
    }

    void StartTheGame()
    {
        string levelID = "Level1";

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
