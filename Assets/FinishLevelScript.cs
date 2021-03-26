using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevelScript : MonoBehaviour
{

    [SerializeField]
    string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var saveManager = ScriptableObject.CreateInstance<SaveManager>();
            saveManager.SetPlayerLevel(nextSceneName);
            saveManager.Save();
            
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
