using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{

    public string areaToLoad;

    public string areaTransitionName;

    public AreaEntrance theEntrance;

    public float waitToLoad = 0.2f;
    private bool shouldLoadAfterFade;

    // Use this for initialization
    void Start()
    {
        theEntrance.transitionName = areaTransitionName;

    }

    // Update is called once per frame
    void Update()
    {
        if (shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);

                AudioManager.instance.PlaySFX(1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //SceneManager.LoadScene(areaToLoad);
            shouldLoadAfterFade = true;

            UIFade.instance.FadeToBlack();
            GameManager.instance.fadingBetweenAreas = true;

            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}
