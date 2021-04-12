using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageBoxManager : MonoBehaviour
{
    
    public GameObject imagebox;
    public GameObject OkButton;

    public Image ItemImage;
    public Text Titel;
    public Text ImageDescription1;
    public Text ImageDescription2;
    public Text ImageDescription3;

    private string questToMark;
    private bool withQuest = false;
    private bool markQuestComplete;

    public static ImageBoxManager instance;
    private bool clickedButton;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (imagebox.activeInHierarchy)
        {
            PlayerController.instance.canMove = false;

            if (clickedButton)
            {
                imagebox.SetActive(false);

                PlayerController.instance.canMove = true;

            }
        }

    }
    public void OkButtonClick()
    {
        clickedButton = true;

        if (withQuest)
        {
            if (markQuestComplete)
            {
                QuestManager.instance.MarkQuestComplete(questToMark);
            }
            else
            {

                QuestManager.instance.MarkQuestIncomplete(questToMark);
            }
        }
    }

    public void ShowImage(Sprite imageToShow,string title, string TextOfImage1, string TextOfImage2, string TextOfImage3, string questToMark1, bool wantToMarkquest, bool markQuest)
    {
        Titel.text = title;
        ImageDescription1.text = TextOfImage1;
        ImageDescription2.text = TextOfImage2;
        ImageDescription3.text = TextOfImage3;
        ItemImage.sprite = imageToShow;

        withQuest = wantToMarkquest;
        markQuestComplete = markQuest;
        questToMark = questToMark1;

        imagebox.SetActive(true);
        clickedButton = false;

        PlayerController.instance.canMove = false;
    }
}
