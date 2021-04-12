using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice7Manager : MonoBehaviour
{

    public GameObject ChoiceBox;
    public Text question;

    public Text Answer1;
    private string questToMark1;

    public Text Answer2;
    private string questToMark2;

    public Text Answer3;
    private string questToMark3;

    public Text Answer4;
    private string questToMark4;

    public Text Answer5;
    private string questToMark5;

    public Text Answer6;
    private string questToMark6;

    public Text Answer7;
    private string questToMark7;

    public static Choice7Manager instance;

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
            
            if(choiceMade >= 1)
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
        QuestManager.instance.MarkQuestComplete(questToMark3);
        choiceMade = 3;
    }

    public void ChoiceOption4()
    {
        QuestManager.instance.MarkQuestComplete(questToMark4);
        choiceMade = 4;
    }

    public void ChoiceOption5()
    {
        QuestManager.instance.MarkQuestComplete(questToMark5);
        choiceMade = 5;
    }
    public void ChoiceOption6()
    {
        QuestManager.instance.MarkQuestComplete(questToMark6);
        choiceMade = 6;
    }
    public void ChoiceOption7()
    {
        QuestManager.instance.MarkQuestComplete(questToMark7);
        choiceMade = 7;
    }

    public void ShowChoice(string questionText, string t1, string t2, string t3, string t4, string t5, string t6, string t7, string quest1, string quest2, string quest3, string quest4, string quest5, string quest6, string quest7)
    {
        question.text = questionText;
        Answer1.text = t1;
        Answer2.text = t2;
        Answer3.text = t3;
        Answer4.text = t4;
        Answer5.text = t5;
        Answer6.text = t6;
        Answer7.text = t7;

        questToMark1 = quest1;
        questToMark2 = quest2;
        questToMark3 = quest3;
        questToMark4 = quest4;
        questToMark5 = quest5;
        questToMark6 = quest6;
        questToMark7 = quest7;

        choiceMade = 0;
        ChoiceBox.SetActive(true);

        PlayerController.instance.canMove = false;
    }
}
