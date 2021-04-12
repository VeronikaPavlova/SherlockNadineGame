using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice4Manager : MonoBehaviour
{


    public GameObject ChoiceBox;

    public Text question;
    public Text question2;
    
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;

    private string questToMark1;
    private string questToMark2;
    private string questToMark3;
    private string questToMark4;

    public static Choice4Manager instance;

    public int choiceMade;

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
        QuestManager.instance.MarkQuestComplete(questToMark1);
    }

    public void ChoiceOption2()
    {
        choiceMade = 2;
        QuestManager.instance.MarkQuestComplete(questToMark2);
    }
    public void ChoiceOption3()
    {
        choiceMade = 3;
        QuestManager.instance.MarkQuestComplete(questToMark3);
    }
    public void ChoiceOption4()
    {
        choiceMade = 4;
        QuestManager.instance.MarkQuestComplete(questToMark4);
    }



    public void ShowChoice(string questionText1, string questionText2, string t1, string t2, string t3, string t4, string quest1, string quest2, string quest3, string quest4)
    {
        question.text = questionText1;
        question2.text = questionText2;

        answer1.text = t1;
        answer2.text = t2;
        answer3.text = t3;
        answer4.text = t4;
        questToMark1 = quest1;
        questToMark2 = quest2;
        questToMark3 = quest3;
        questToMark4 = quest4;

        choiceMade = 0;
        ChoiceBox.SetActive(true);

        PlayerController.instance.canMove = false;
    }
}
