using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioQuestActivator : MonoBehaviour
{
    public bool activateOnTrigger;
    public bool triggerOnes;

    public bool StopMovementPlayer;

    public float delay;
    public float delayToActivateObject;

    public GameObject ObjectToActivate;
    public bool activate;

    public bool usenewBGM;
    public bool stopMusik = false;
    public int bgmToPlay;

    private bool canActivate;

    public bool shouldActivateQuest;
    public string questToMark;
    public bool markComplete;

    public bool shouldActivateQuest2;
    public string questToMark2;
    public bool markComplete2;

    public bool needActivatedQuest;
    public string questToCheck;

    private bool checkedQuest = true;
    private bool triggerOrKey = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeDelay();

    }

    public void TimeDelay()
    {
        StartCoroutine(CheckCompletionDelay());
    }

    IEnumerator CheckCompletionDelay()
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


        if (canActivate && triggerOrKey && checkedQuest)
        {
            if (StopMovementPlayer)
            {
                GameManager.instance.dialogActive = true;
            }



            if (triggerOnes)
            {
                triggerOrKey = false;
            }



            if (usenewBGM)
            {
               AudioManager.instance.PlayBGM(bgmToPlay);

            }

            if (delayToActivateObject > 0)
            {

                yield return new WaitForSeconds(delayToActivateObject);

                ObjectToActivate.SetActive(activate);
            }

            if (delay > 0f)
            {
                yield return new WaitForSeconds(delay);
            }

            if (stopMusik)
            {

                AudioManager.instance.StopMusik();
                GameManager.instance.dialogActive = false;
            }


            if (shouldActivateQuest)
            {
                if (markComplete)
                {
                    QuestManager.instance.MarkQuestComplete(questToMark);
                }
                else
                {
                    QuestManager.instance.MarkQuestIncomplete(questToMark);
                }
            }

            if (shouldActivateQuest2)
            {
                if (markComplete2)
                {
                    QuestManager.instance.MarkQuestComplete(questToMark2);
                }
                else
                {
                    QuestManager.instance.MarkQuestIncomplete(questToMark2);
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
