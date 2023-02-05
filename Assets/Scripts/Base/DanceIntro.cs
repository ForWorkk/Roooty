using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceIntro : MonoBehaviour
{
    private AudioSource audio;

    private int index = 0;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(index == 0 && !audio.isPlaying)
        {
            index++;
            audio.clip = GameAssets.i.musicList[3];
            audio.loop = true;
        }
    }
}
