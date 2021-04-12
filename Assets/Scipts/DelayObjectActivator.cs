using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayObjectActivator : MonoBehaviour
{
    public float delay;

    public GameObject ObjectToActivate;
    public bool activate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeDelay();

    }

    public void TimeDelay()
    {
        StartCoroutine(CheckCompletionDelay());
    }


    IEnumerator CheckCompletionDelay()
    {

        yield return new WaitForSeconds(delay);

        ObjectToActivate.SetActive(activate);

    }
}