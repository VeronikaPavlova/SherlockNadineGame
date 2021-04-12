using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sfx;
    public AudioSource[] backgroundmusic;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySFX(4);
        }
    }

    public void PlaySFX(int soundToPlay)
    {
        if(soundToPlay < sfx.Length)
        {
            sfx[soundToPlay].Play();
        }
    }

    public void PlayBGM(int musicToPlay)
    {
        if (!backgroundmusic[musicToPlay].isPlaying)
        {
            StopMusik();

            if (musicToPlay < backgroundmusic.Length)
            {
                backgroundmusic[musicToPlay].Play();
            }
        }
    }

    public void StopMusik()
    {
        for(int i = 0; i < backgroundmusic.Length; i++)
        {
            backgroundmusic[i].Stop();
        }

    }
}
