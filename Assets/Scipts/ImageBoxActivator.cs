using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageBoxActivator : MonoBehaviour
{

    public bool activateOnTrigger;
    public bool triggerOnes;

    public Sprite imageToUse;
    public string TitelImage;
    public string textOfImage1;
    public string textOfImage2;
    public string textOfImage3;


    public bool useSoundAtStart;
    public int sfxToPlayStart;


    public bool withQuest;
    public string questToMark;
    public bool markComplete;

    private bool canActivate;
    private bool triggerOrKey = true;

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

        if (canActivate && triggerOrKey && !ImageBoxManager.instance.imagebox.activeInHierarchy && checkedQuest && leaveTriggerArea)
        {

            if (triggerOnes)
            {
                triggerOrKey = false;
            }

             if(useSoundAtStart)
            {
                AudioManager.instance.PlaySFX(sfxToPlayStart);
            }

            leaveTriggerArea = false;
            ImageBoxManager.instance.ShowImage(imageToUse, TitelImage, textOfImage1, textOfImage2, textOfImage3, questToMark, withQuest, markComplete);
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
