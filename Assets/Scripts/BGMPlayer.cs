using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public AudioClip gamebgm;
    public bool bgmPlaying = true;
    public int a = 0;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
      audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      if(bgmPlaying == true && a == 0)
      {
        audioSource.PlayOneShot(gamebgm);
        a++;
      }
      if(bgmPlaying == false)
      {
        audioSource.Stop();
      }
    }
}
