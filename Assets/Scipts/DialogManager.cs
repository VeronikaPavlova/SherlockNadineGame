using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;

    public int currentLine;
    private bool justStarted;

    public static DialogManager instance;

    private string questToMark;
    private bool markQuestComplete;
    private bool shouldMarkQuest;


    private string questToMark2;
    private bool markQuestComplete2;
    private bool shouldMarkQuest2;

    private GameObject ObjectToShowUnshow;
    private bool shouldSHowUnshowObject;
    private bool show;
    private bool withSound;
    private int whichSoundToPlay;

    private GameObject ObjectToShowUnshowStart;
    private bool shouldSHowUnshowObjectStart;
    private bool showStart;

    private string NPCName;
    public bool isDone;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        dialogBox.SetActive(false);
        //dialogText.text = dialogLines[currentLine];

    }

    // Update is called once per frame
    void Update()
    {
        if (shouldSHowUnshowObjectStart)
        {
            shouldSHowUnshowObjectStart = false;
            ObjectToShowUnshowStart.SetActive(showStart);

        }

        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Jump"))
            {
                if (!justStarted)
                {
                    currentLine++;
                    if (currentLine >= dialogLines.Length)
                    {

                        dialogBox.SetActive(false);

                        GameManager.instance.dialogActive = false;

                    }
                    else
                    {
                        CheckWhatName();
                        if (nameText.text == "Nadine")
                        {
                            dialogText.fontStyle = FontStyle.Italic;
                        }
                        else
                        {
                            dialogText.fontStyle = FontStyle.Normal;
                        }
                        dialogText.text = dialogLines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;
                }
            }
        }
        else
        {   if (shouldMarkQuest)
            {
                if (markQuestComplete)
                {
                    QuestManager.instance.MarkQuestComplete(questToMark);
                }
                else
                {
                    QuestManager.instance.MarkQuestIncomplete(questToMark);
                }

                shouldMarkQuest = false;
            }

            if (shouldMarkQuest2)
            {
                if (markQuestComplete2)
                {
                    QuestManager.instance.MarkQuestComplete(questToMark2);
                }
                else
                {
                    QuestManager.instance.MarkQuestIncomplete(questToMark2);
                }

                shouldMarkQuest2 = false;
            }


            if (shouldSHowUnshowObject)
            {
                shouldSHowUnshowObject = false;
                if (withSound)
                {
                    AudioManager.instance.PlaySFX(whichSoundToPlay);                    
                }

                ObjectToShowUnshow.SetActive(show);

            }
        }
    }

    public void ShowDialog(string[] newLines)
    {
        dialogLines = newLines;

        currentLine = 0;

        CheckWhatName();
        if (nameText.text == "Nadine")
        {
            dialogText.fontStyle = FontStyle.Italic;
        }
        else
        {
            dialogText.fontStyle = FontStyle.Normal;
        }
        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);

        justStarted = true;

        GameManager.instance.dialogActive = true;
        
    }

    public void CheckWhatName()
    {
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = "Nadine";
            currentLine++;
        }
        else if (dialogLines[currentLine].StartsWith("f-"))
        {

            nameText.text = dialogLines[currentLine].Replace("f-", "");
            currentLine++;
        }
        else
        {
            nameText.text = NPCName;
        }
    }

    public void setName(string name)
    {
        NPCName = name;
    }

    public void ShouldActivateQuestAtEnd(string questName, bool markComplete)
    {
        questToMark = questName;
        markQuestComplete = markComplete;

        shouldMarkQuest = true;
    }
    public void ShouldActivate2QuestAtEnd(string questName, bool markComplete)
    {
        questToMark2 = questName;
        markQuestComplete2 = markComplete;

        shouldMarkQuest2 = true;
    }

    public void ShouldActivateObjectAtEnd(GameObject objectDeact, bool showObject, bool withSoundToPlay, int sfxSound)
    {
        withSound = withSoundToPlay;
        whichSoundToPlay = sfxSound;
        ObjectToShowUnshow = objectDeact;
        show = showObject;

        shouldSHowUnshowObject = true;
    }
    public void ShouldActivateObjectAtStart(GameObject objectDeact, bool showObject)
    {
        ObjectToShowUnshowStart = objectDeact;
        showStart = showObject;

        shouldSHowUnshowObjectStart = true;
    }
}
