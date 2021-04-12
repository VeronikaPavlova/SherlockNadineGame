using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    public bool activateOnTrigger;
    public string[] lines;
    public string NPCName;

    private bool canActivate;

    public bool shouldActivateQuest;
    public string questToMark;
    public bool markComplete;

    public bool shouldActivate2Quest;
    public string questToMark2;
    public bool markComplete2;

    public bool needActivatedQuest;
    public string questToCheck;

    private bool checkedQuest = true;
    private bool triggerOrKey = true;
    private bool deacttObjectMyself;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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


        if (canActivate && triggerOrKey && !DialogManager.instance.dialogBox.activeInHierarchy && checkedQuest && deacttObjectMyself)
        {
            triggerOrKey = false;
            deacttObjectMyself = false;

            if (!string.IsNullOrEmpty(NPCName))
            {

                DialogManager.instance.setName(NPCName);
            }

            DialogManager.instance.ShowDialog(lines);

            if (shouldActivateQuest)
            {
                DialogManager.instance.ShouldActivateQuestAtEnd(questToMark, markComplete);
            }

            if (shouldActivate2Quest)
            {
                DialogManager.instance.ShouldActivateQuestAtEnd(questToMark2, markComplete2);
            }

        }
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = true;
            deacttObjectMyself = true;
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
