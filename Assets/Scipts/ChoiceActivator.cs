using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceActivator : MonoBehaviour
{


    public bool activateOnTrigger;
    public bool triggerOnes;

    private bool canActivate;
    private bool triggerOrKey = true;

    public string question1;
    public string question2;
    public string question3;

    public string[] Answers;
    public string[] QuestsToAnswers;


    public bool needActivatedQuest;
    public string questToCheck;
    private bool checkedQuest = true;
    private bool leaveTriggerArea;

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

        if (canActivate && triggerOrKey && !ChoiceManager.instance.ChoiceBox.activeInHierarchy && checkedQuest && leaveTriggerArea)
        {
            if (triggerOnes)
            {
                triggerOrKey = false;
            }

            leaveTriggerArea = false;
            ChoiceManager.instance.ShowChoice(question1, question2, question3, Answers, QuestsToAnswers);

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
