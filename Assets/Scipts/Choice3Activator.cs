using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice3Activator : MonoBehaviour
{


    public bool activateOnTrigger;
    public bool triggerOnes;

    private bool canActivate;
    private bool triggerOrKey = true;

    public bool withDialog;
    public string[] startText;
    public string NPCname;


    public string question;
    public string question2;
    public string text1;
    public string text2;
    public string text3;

    public string questToMark1;
    public string questToMark2;
    public string questToMark3;

    public bool needActivatedQuest;
    public string questToCheck;
    private bool checkedQuest = true;
    private bool leaveTriggerArea;

    public bool withQuestAfterDialog;

    public string questToMarkAfterDialog;
    public bool markQuestComplete;

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

        if (canActivate && triggerOrKey && !Choice3Manager.instance.ChoiceBox.activeInHierarchy && checkedQuest && leaveTriggerArea)
        {
            if (triggerOnes)
            {
                triggerOrKey = false;
            }

            if (withDialog)
            {

                DialogManager.instance.setName(NPCname);

                DialogManager.instance.ShowDialog(startText);


            }

            Choice3Manager.instance.ShowChoice(question, question2, text1, text2, text3, questToMark1, questToMark2, questToMark3);

            if (withQuestAfterDialog)
            {
                DialogManager.instance.ShouldActivateQuestAtEnd(questToMarkAfterDialog, markQuestComplete);

            }


        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = true;
            leaveTriggerArea = true;
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
