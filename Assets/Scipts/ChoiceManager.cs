using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{

    public GameObject ChoiceBox;
    public Text question1;
    public Text question2;
    public Text question3;

    public Text[] Answers;
    public GameObject[] Buttons;
    private string[] questToMark;

    public int choiceMade;

    public static ChoiceManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ChoiceBox.activeInHierarchy)
        {
            PlayerController.instance.canMove = false;

            if (choiceMade >= 1)
            {
                ChoiceBox.SetActive(false);

                PlayerController.instance.canMove = true;
            }
        }

    }

    public void ChoiceOption1()
    {
        choiceMade = 1;
        QuestManager.instance.MarkQuestComplete(questToMark[0]);
    }

    public void ChoiceOption2()
    {
        choiceMade = 2;
        QuestManager.instance.MarkQuestComplete(questToMark[1]);
    }

    public void ChoiceOption3()
    {
        QuestManager.instance.MarkQuestComplete(questToMark[2]);
        choiceMade = 3;
    }

    public void ChoiceOption4()
    {
        QuestManager.instance.MarkQuestComplete(questToMark[3]);
        choiceMade = 4;
    }

    public void ChoiceOption5()
    {
        QuestManager.instance.MarkQuestComplete(questToMark[4]);
        choiceMade = 5;
    }
    public void ChoiceOption6()
    {
        QuestManager.instance.MarkQuestComplete(questToMark[5]);
        choiceMade = 6;
    }
    public void ChoiceOption7()
    {
        QuestManager.instance.MarkQuestComplete(questToMark[6]);
        choiceMade = 7;
    }
    public void ChoiceOption8()
    {
        QuestManager.instance.MarkQuestComplete(questToMark[7]);
        choiceMade = 8;
    }

    public void ShowChoice(string questionText1, string questionText2, string questionText3, string[] text, string[] quests)
    {
        question1.text = questionText1;
        question2.text = questionText2;
        question3.text = questionText3;

        questToMark = new string[quests.Length];

        for (int i = 0; i < text.Length; i++)
        {
            Answers[i].text = text[i];
            Answers[i].gameObject.SetActive(true);
            Buttons[i].SetActive(true);

            questToMark[i] = quests[i];
        }
        
        choiceMade = 0;
        ChoiceBox.SetActive(true);

        PlayerController.instance.canMove = false;
    }
}
