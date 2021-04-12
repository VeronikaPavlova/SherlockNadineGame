using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClemensMusikPlaylist : MonoBehaviour
{
    public GameObject Playlist;
    public Dropdown dropdown1;
    public Dropdown dropdown2;
    public Dropdown dropdown3;
    public Dropdown dropdown4;
    public Dropdown dropdown5;

    public Button OkButton;

    public int rightCounter;

    public static ClemensMusikPlaylist instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Playlist.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Playlist.activeInHierarchy)
        {
            PlayerController.instance.canMove = false;
        }

    }

    public void OkClickButton()
    {
        rightCounter = 0;

        if (dropdown1.value == 3)
        {
            rightCounter++;
        }
        if (dropdown2.value == 0)
        {
            rightCounter++;
        }
        if (dropdown3.value == 2)
        {
            rightCounter++;
        }
        if (dropdown4.value == 1)
        {
            rightCounter++;
        }
        if (dropdown5.value == 4)
        {
            rightCounter++;
        }

        Debug.Log(rightCounter);

        if(rightCounter == 0)
        {
            QuestManager.instance.MarkQuestComplete("Clemens Richtig0");

        }else if(rightCounter == 1)
        {
            QuestManager.instance.MarkQuestComplete("Clemens Richtig1");

        }else if(rightCounter >=2 && rightCounter <= 4)
        {
            QuestManager.instance.MarkQuestComplete("Clemens Richtig2-4");
        } else if( rightCounter == 5)
        {
            QuestManager.instance.MarkQuestComplete("Clemens Richtig5");
        }
        else
        {
            Debug.Log("Right COunter groesser als 5");
        }

        Debug.Log(rightCounter);

        if (rightCounter >= 0)
        {
            Playlist.SetActive(false);

            PlayerController.instance.canMove = true;
        }
    }

    public void ShowPlaylist()
    {
        rightCounter = -1;
        Playlist.SetActive(true);

        PlayerController.instance.canMove = false;

    }
}
