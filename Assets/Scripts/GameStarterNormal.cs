using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStarterNormal : MonoBehaviour
{
    public AudioClip start;
    public int a = 0;
    public float interval = 1.0f;
    public bool countdownNormal = false;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
      audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      if(countdownNormal == true)
      {
        if(interval > 0.0f)
        {
          interval -= Time.deltaTime;
        }
        if(interval < 0.0f)
        {
          interval = 1.0f;
          SceneManager.LoadScene("Normal");
        }
      }
    }

    public void LoadStart()
    {
      if(a == 0)
      {
        a++;
        audioSource.PlayOneShot(start);
        countdownNormal = true;
      }
    }
}
