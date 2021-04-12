﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMarker : MonoBehaviour
{
    public string questToMark;
    public bool markComplete;

    public bool markOnEnter;
    private bool canMark;

    public bool deactivateOnMarking;


    public bool needActivatedQuest;
    public string questToCheck;

    private bool checkedQuest = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMark && Input.GetButtonDown("Jump"))
        {
            canMark = false;
            MarkQuest();
        }
        
    }

    public void MarkQuest()
    {
        if (needActivatedQuest)
        {
            checkedQuest = QuestManager.instance.CheckIfComplete(questToCheck);
        }

        if (checkedQuest)
        {
            if (markComplete)
            {
                QuestManager.instance.MarkQuestComplete(questToMark);
            }
            else
            {
                QuestManager.instance.MarkQuestIncomplete(questToMark);
            }

            gameObject.SetActive(!deactivateOnMarking);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (markOnEnter)
            {
                MarkQuest();
            }
            else
            {
                canMark = true;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canMark = false;
        }
    }
}
