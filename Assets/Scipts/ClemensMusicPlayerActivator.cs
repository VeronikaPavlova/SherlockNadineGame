using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClemensMusicPlayerActivator : MonoBehaviour
{
    public bool activateOnTrigger;
    public bool triggerOnes;

    private bool canActivate;
    private bool triggerOrKey = true;


    public bool needActivatedQuest;
    public string questToCheck;
    private bool checkedQuest = true;
    private bool leaveTriggerArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

        if (needActivatedQuest)
        {
            checkedQuest = QuestManager.instance.CheckIfComplete(questToCheck);
        }

        if (!activateOnTrigger)
        {
            triggerOrKey = Input.GetButtonDown("Jump");
        }
        else if (!activateOnTrigger && triggerOrKey)
        {
            triggerOrKey = true;
        }

        if (canActivate && triggerOrKey && !ClemensMusikPlaylist.instance.Playlist.activeInHierarchy && checkedQuest)
        {

            if (triggerOnes)
            {
                triggerOrKey = false;
            }

            ClemensMusikPlaylist.instance.ShowPlaylist();


        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = false;
        }
    }
}
