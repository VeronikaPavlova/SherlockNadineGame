using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    private bool battleActive;

    public bool needQuestToCheck;
    public string questToCheck;
    private bool checkQuestToCheck;

    public GameObject battleScene;

    public GameObject DialogBox;
    public Text DialogText;
    public GameObject Menu;

    public GameObject SprungkickAnim;
    public string SprungkickText;

    public GameObject KopfnussAnim;
    public string KopfnussText;

    public GameObject TackleAnim;
    public string TackleText;

    public GameObject SchneckeAnim;
    public string SchneckeText;


    private bool canActivate;
    private int counter;

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
        if (canActivate && !battleScene.activeInHierarchy && checkQuestToCheck)
        {
            BattleStart();
        }
        if (counter >= 4)
        {

            QuestManager.instance.MarkQuestComplete("Battle1 Nadine");

            battleActive = false;
            GameManager.instance.battleActive = false;
            battleScene.SetActive(false);

        }
    }



        public void BattleStart()
    {
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


    public void TimeDelaySprungkick()
    {
        StartCoroutine(Sprungkick());
    }
    IEnumerator Sprungkick()
    {
        SprungkickAnim.SetActive(true);
        AudioManager.instance.PlaySFX(13);

        yield return new WaitForSeconds(1);

        SprungkickAnim.SetActive(false);

        Menu.SetActive(false);
        DialogText.text = SprungkickText;
        DialogBox.SetActive(true);

        yield return new WaitForSeconds(2);
        DialogBox.SetActive(false);

        Menu.SetActive(true);
        

        counter++;
    }


    public void TimeDelayKopfnuss()
    {
        StartCoroutine(Kopfnuss());
    }
    IEnumerator Kopfnuss()
    {
        KopfnussAnim.SetActive(true);
        AudioManager.instance.PlaySFX(14);

        yield return new WaitForSeconds(1);

        KopfnussAnim.SetActive(false);

        Menu.SetActive(false);

        DialogText.text = KopfnussText;
        DialogBox.SetActive(true);

        yield return new WaitForSeconds(2);
        DialogBox.SetActive(false);

        Menu.SetActive(true);


        counter++;
    }

    public void TimeDelayTackel()
    {
        StartCoroutine(Tackle());
    }
    IEnumerator Tackle()
    {
        TackleAnim.SetActive(true);
        AudioManager.instance.PlaySFX(13);

        yield return new WaitForSeconds(1);

        TackleAnim.SetActive(false);

        Menu.SetActive(false);

        DialogText.text = TackleText;
        DialogBox.SetActive(true);

        yield return new WaitForSeconds(2);
        DialogBox.SetActive(false);

        Menu.SetActive(true);


        counter++;
    }

    public void TimeDelaySchnecke()
    {
        StartCoroutine(Schnecke());
    }
    IEnumerator Schnecke()
    {
        SchneckeAnim.SetActive(true);
        AudioManager.instance.PlaySFX(13);

        yield return new WaitForSeconds(1);

        SchneckeAnim.SetActive(false);

        Menu.SetActive(false);

        DialogText.text = SchneckeText;
        DialogBox.SetActive(true);

        yield return new WaitForSeconds(2);
        DialogBox.SetActive(false);

        Menu.SetActive(true);

        counter++;
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
