using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameMenuOpen, dialogActive, fadingBetweenAreas, battleActive;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMenuOpen || dialogActive || fadingBetweenAreas || battleActive)
        {
            PlayerController.instance.canMove = false;
        }
        else
        {
            PlayerController.instance.canMove = true;
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadData();
        }
    }

    public void SaveData()
    {
        //Save active Scene
        PlayerPrefs.SetString("CurrentScene", SceneManager.GetActiveScene().name);
        
        //Save Player Position
        PlayerPrefs.SetFloat("PlayerPosition_X", PlayerController.instance.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosition_Y", PlayerController.instance.transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosition_Z", PlayerController.instance.transform.position.z);
    }

    public void LoadData()
    {
        PlayerController.instance.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerPosition_X"), PlayerPrefs.GetFloat("PlayerPosition_Y"), PlayerPrefs.GetFloat("PlayerPosition_Z"));

        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentScene"));
    }
}
