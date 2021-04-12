using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManagerFinale : MonoBehaviour
{
    public static BattleManagerFinale instance;

    private bool battleActive;

    public GameObject battleScene;

    public GameObject DialogBox;
    public Text DialogText;
    public Text DialogName;
    public GameObject Menu;

    public GameObject animals;


    public bool needQuestToCheck;
    public string questToCheck;
    private bool checkQuestToCheck;

    public GameObject EisAnim;
    public string EisText;

    public GameObject FurchtAnim;
    public string FurchText;

    public GameObject FinsternisAnim;
    public string FinsternisText;

    public GameObject BauchwehAnim;
    public string BauchwehText;

    private int counter;

    private bool canActivate;
    private bool eisQuest;
    private bool furchtQuest;
    private bool finsternisQuest;
    private bool bauchwehQuest;
    private bool fertig;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!needQuestToCheck)
        {
            checkQuestToCheck = true;
        }
        else
        {
            checkQuestToCheck = QuestManager.instance.CheckIfComplete(questToCheck);
        }

        if (canActivate && checkQuestToCheck)
        {
            BattleStart();
        }

        if (counter >= 4 && fertig)
        {
            QuestManager.instance.MarkQuestComplete("Finale Christoph");

            battleActive = false;
            GameManager.instance.battleActive = false;
            battleScene.SetActive(false);
        }
    }



    public void BattleStart()
    {
            StartCoroutine(Battle());
   }
    IEnumerator Battle()
    {
        fertig = false;
        animals.SetActive(true);

        DialogBox.SetActive(true);
        DialogName.text = "Shadow Nadine";
        DialogText.text = "Denkst du ernsthaft das Tiere dir hier helfen koennen?! Gegen Eis hast du keine Chance!";


        yield return new WaitForSeconds(4);
        animals.SetActive(false);

        eisQuest = true;
        
        DialogBox.SetActive(false);
        Menu.SetActive(true);

        if (!battleActive)
        {
            battleActive = true;
        }

        GameManager.instance.battleActive = true;

        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);

        battleScene.SetActive(true);

        AudioManager.instance.PlayBGM(16);
        counter = 0;
    }


    public void TimeDelayEis()
    {
        StartCoroutine(Eis());
    }
    IEnumerator Eis()
    {
        if (eisQuest)
        {
            EisAnim.SetActive(true);
            AudioManager.instance.PlaySFX(13);

            yield return new WaitForSeconds(2);
            EisAnim.SetActive(false);

            Menu.SetActive(false);

            DialogText.text = "Was?! Wie ist das moeglich?! Das Schaf hat mein Eis aufgetaut?!";
            DialogBox.SetActive(true);

            yield return new WaitForSeconds(3);

            DialogName.text = "Nadine";
            DialogText.text = "Natuerlich! Denn im Inneren ist Schafi eine Waermeflasche, die gegen jedes Eis ankommt!";
            DialogBox.SetActive(true);

            yield return new WaitForSeconds(4);

            DialogName.text = "Shadow Nadine";
            DialogText.text = "Alles klar dann setz ich einfach Furcht ein!";


            yield return new WaitForSeconds(3);


            DialogBox.SetActive(true);

            DialogBox.SetActive(false);

            Menu.SetActive(true);
            counter++;
            furchtQuest = true;
            eisQuest = false;
        }
        else
        {
            TimeDelayWrong();
        }
    }

    public void TimeDelayFurcht()
    {
        StartCoroutine(Furcht());
    }
    IEnumerator Furcht()
    {
        if (furchtQuest)
        {
            FurchtAnim.SetActive(true);
            AudioManager.instance.PlaySFX(13);

            yield return new WaitForSeconds(2);
            FurchtAnim.SetActive(false);

            Menu.SetActive(false);
            DialogText.text = "Diesmal haelt mich eine Robbe auf?!";
            DialogBox.SetActive(true);

            yield return new WaitForSeconds(3);

            DialogName.text = "Nadine";
            DialogText.text = "Ja, denn Robbi macht mir Mut in diesem Kampf. Furcht hat hier keinen Platz!";
            DialogBox.SetActive(true);

            yield return new WaitForSeconds(4);

            DialogName.text = "Shadow Nadine";
            DialogText.text = "Denkst du das wars schon?! Als naechstes greife ich dich mit Finsternis an!";


            yield return new WaitForSeconds(4);


            DialogBox.SetActive(true);

            DialogBox.SetActive(false);

            Menu.SetActive(true);
            counter++;

            finsternisQuest = true;
            furchtQuest = false;
        }
        else
        {
            TimeDelayWrong();
        }
    }

    public void TimeDelayFinsternis()
    {
        StartCoroutine(Finsternis());
    }
    IEnumerator Finsternis()
    {
        if (finsternisQuest)
        {
            FinsternisAnim.SetActive(true);
            AudioManager.instance.PlaySFX(13);

            yield return new WaitForSeconds(2);
            FinsternisAnim.SetActive(false);

            Menu.SetActive(false);
            DialogText.text = "Das ist Laecherlich! Was hat ein T-Rex mit Finsternis zu tun?!";
            DialogBox.SetActive(true);

            yield return new WaitForSeconds(3);

            DialogName.text = "Nadine";
            DialogText.text = "Er erhellt einem den Tag! Schau dir doch seine kleinen Arme an!";
            DialogBox.SetActive(true);

            yield return new WaitForSeconds(4);

            DialogName.text = "Shadow Nadine";
            DialogText.text = "Ok, dann werde ich meine ultimative Waffe einsetzen! Bauchweh!";


            yield return new WaitForSeconds(4);


            DialogBox.SetActive(true);

            DialogBox.SetActive(false);

            Menu.SetActive(true);
            counter++;

            bauchwehQuest = true;
            finsternisQuest = false;
        }
        else
        {
            TimeDelayWrong();
        }
    }

    public void TimeDelayBauchweh()
    {
        StartCoroutine(Bauchweh());
    }
    IEnumerator Bauchweh()
    {
        if (bauchwehQuest)
        {
            BauchwehAnim.SetActive(true);
            AudioManager.instance.PlaySFX(13);

            yield return new WaitForSeconds(2);
            BauchwehAnim.SetActive(false);


            yield return new WaitForSeconds(2);


            DialogBox.SetActive(true);

            DialogBox.SetActive(false);

            Menu.SetActive(true);
            counter++;
            fertig = true;
            bauchwehQuest = false;

        }
        else
        {
            TimeDelayWrong();
        }
    }
    public void TimeDelayWrong()
    {
        StartCoroutine(Wrong());
    }
    IEnumerator Wrong()
    {
        Menu.SetActive(false);

        DialogName.text = "Shadow Nadine";
        DialogText.text = "Dachtest du wirklich das funktioniert?! Du hast keine Chance";
        DialogBox.SetActive(true);

        yield return new WaitForSeconds(2);

        Menu.SetActive(true);

        DialogBox.SetActive(false);
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
