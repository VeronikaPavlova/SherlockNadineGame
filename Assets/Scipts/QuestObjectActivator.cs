using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjectActivator : MonoBehaviour
{

    public bool ObjectGetsDeactivated;
    public GameObject SelfToDeact;

    public bool activateOnTrigger;
    public bool triggerOnes;

    private bool canActivate;
    private bool triggerOrKey = true;


    public bool needQuestToCheck;
    public string questToCheck;
    private bool checkQuestToCheck;

    public bool useSoundAtStart;
    public int sfxToPlayStart;


    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;


    public bool withObjectAfterDialog;
    public GameObject objectsToActivateAfterDialog;
    public bool activateObject;
    public bool useSoundAtEnd;
    public int sfxToPlayEnd;

    public bool withObjectAfterDialog2;
    public GameObject objectsToActivateAfterDialog2;
    public bool activateObject2;
    public bool useSoundAtEnd2;
    public int sfxToPlayEnd2;

    public bool withObjectBeforeDialog;
    public GameObject objectsToActivateBeforeDialog;
    public bool activateObjectBefore;


    public bool withQuestWithoutDialog;

    public string questToMarkWithoutDialog;
    public bool markQuestCompleteWithoutDialog;

    public float timer;

    public bool withDialog;
    public string[] startText;
    public string NPCname;


    public bool withQuestAfterDialog;

    public string questToMarkAfterDialog;
    public bool markQuestComplete;

    public bool with2QuestAfterDialog;

    public string questToMark2AfterDialog;
    public bool markQuest2Complete;



    private bool initialCheckDone;




    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialCheckDone)
        {

            TimeDelay();
        }
    }

    public void TimeDelay()
    {
        StartCoroutine(CheckCompletionDelay());
    }
    IEnumerator CheckCompletionDelay()
    {
        if (!needQuestToCheck)
        {
            checkQuestToCheck = true;
        }
        else
        {
            checkQuestToCheck = QuestManager.instance.CheckIfComplete(questToCheck);
        }

        if (!activateOnTrigger)
        {
            triggerOrKey = Input.GetButtonDown("Jump");
        }
        else if (!activateOnTrigger && triggerOrKey)
        {
            triggerOrKey = true;
        }

        if (checkQuestToCheck) 
        {
           

            yield return new WaitForSeconds(timer);
            for (int i = 0; i < objectsToDeactivate.Length; i++)
            {
                objectsToDeactivate[i].SetActive(false);

            }

            for (int i = 0; i < objectsToActivate.Length; i++)
            {
                objectsToActivate[i].SetActive(true);
            }

            if (withQuestWithoutDialog)
            {
                if (markQuestCompleteWithoutDialog)
                {
                    QuestManager.instance.MarkQuestComplete(questToMarkWithoutDialog);
                }
                else
                {
                    QuestManager.instance.MarkQuestIncomplete(questToMarkWithoutDialog);
                }

                withQuestWithoutDialog = false;
            }

            if (triggerOrKey && canActivate)
            {
                if (useSoundAtStart)
                {
                    AudioManager.instance.PlaySFX(sfxToPlayStart);
                }

                if (triggerOnes)
                {
                    triggerOrKey = false;
                }
                

                if (withDialog && !DialogManager.instance.dialogBox.activeInHierarchy)
                {



                    if (withObjectAfterDialog)
                    {
                        DialogManager.instance.ShouldActivateObjectAtEnd(objectsToActivateAfterDialog, activateObject, useSoundAtEnd, sfxToPlayEnd);
                        
                    }
                    if (withObjectAfterDialog2)
                    {
                        DialogManager.instance.ShouldActivateObjectAtEnd(objectsToActivateAfterDialog2, activateObject2, useSoundAtEnd2, sfxToPlayEnd2);
                       
                    }

                    if (withObjectBeforeDialog)
                    {
                        DialogManager.instance.ShouldActivateObjectAtStart(objectsToActivateBeforeDialog, activateObjectBefore);
                        
                    }

                    if(startText.Length > 0)
                    {

                    DialogManager.instance.setName(NPCname);

                    DialogManager.instance.ShowDialog(startText);

                    }
                }

                yield return new WaitForSeconds(timer);

                if (withQuestAfterDialog)
                {
                    DialogManager.instance.ShouldActivateQuestAtEnd(questToMarkAfterDialog, markQuestComplete);

                }

                if (with2QuestAfterDialog)
                {
                    DialogManager.instance.ShouldActivateQuestAtEnd(questToMark2AfterDialog, markQuest2Complete);

                }

                if (ObjectGetsDeactivated)
                {
                    SelfToDeact.SetActive(false);
                    initialCheckDone = false;
                    canActivate = false;
                }
                else
                {
                    initialCheckDone = true;
                }
            }

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
