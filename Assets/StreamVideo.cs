using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StreamVideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        rawImage.color = Color.black;
        videoPlayer.Prepare();
        WaitForSeconds waitforseconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitforseconds;

        }
        
        

        rawImage.texture = videoPlayer.texture;

        rawImage.color = Color.white;
        videoPlayer.Play();
        WaitForSeconds delay = new WaitForSeconds(49);
        yield return delay;

        SceneManager.LoadScene("MainMenu");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
