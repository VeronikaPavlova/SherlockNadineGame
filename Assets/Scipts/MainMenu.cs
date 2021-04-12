using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string newGameScene;

    public GameObject continueButton;

    public string loadGameScene;
    // Start is called before the first frame update
    void Start()
    {
        //Check if we have saved Data
        if (PlayerPrefs.HasKey("CurrentScene"))
        {
            continueButton.SetActive(true);

        }
        else
        {
            continueButton.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        SceneManager.LoadScene(loadGameScene);

    }

    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
}
