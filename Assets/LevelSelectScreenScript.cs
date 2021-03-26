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
    Button btnContinue;

    [SerializeField]
    AudioSource btnNewStartAudio;

    SaveManager saveManager;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = ScriptableObject.CreateInstance<SaveManager>();
        saveManager.Load();

        btnNewStart.onClick.AddListener(StartTheGame);
        
        if (saveManager.playerLevel == "Level1")
        {
            btnContinue.gameObject.SetActive(false);
        } else
        {
            btnContinue.onClick.AddListener(ContinueTheGame);
        }
    }

    void StartTheGame()
    {
        saveManager.Delete();
        saveManager.playerLevel = "Level1";
        ContinueTheGame();
    }

    void ContinueTheGame()
    {
        saveManager.Load();
        string levelID = saveManager.playerLevel;
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
