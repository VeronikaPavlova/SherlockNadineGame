using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice3Manager : MonoBehaviour
{


    public GameObject ChoiceBox;

    public Text question;
    public Text question2;
    
    public Text answer1;
    public Text answer2;
    public Text answer3;

    private string questToMark1;
    private string questToMark2;
    private string questToMark3;

    public static Choice3Manager instance;

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



    public void ShowChoice(string questionText1, string questionText2, string t1, string t2, string t3, string quest1, string quest2, string quest3)
    {
        question.text = questionText1;
        question2.text = questionText2;

        answer1.text = t1;
        answer2.text = t2;
        answer3.text = t3;
        questToMark1 = quest1;
        questToMark2 = quest2;
        questToMark3 = quest3;

        choiceMade = 0;
        ChoiceBox.SetActive(true);

        PlayerController.instance.canMove = false;
    }
}
