using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice7Activator : MonoBehaviour
{

    private bool canActivate;

    public string question;
    public string text1;
    public string text2;
    public string text3;
    public string text4;
    public string text5;
    public string text6;
    public string text7;

    public string questToMark1;
    public string questToMark2;
    public string questToMark3;
    public string questToMark4;
    public string questToMark5;
    public string questToMark6;
    public string questToMark7;

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

        if (canActivate && Input.GetButtonDown("Jump") && !Choice7Manager.instance.ChoiceBox.activeInHierarchy && checkedQuest && leaveTriggerArea)
        {
            leaveTriggerArea = false;
            Choice7Manager.instance.ShowChoice(question, text1, text2, text3, text4, text5, text6, text7, questToMark1, questToMark2, questToMark3, questToMark4, questToMark5, questToMark6, questToMark7);
            
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
