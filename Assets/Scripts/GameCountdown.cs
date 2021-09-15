using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCountdown : MonoBehaviour
{
    public float countdown = 4.0f;
    public GameObject WinText;
    public GameObject LoseText;
    public GameObject Rock;
    public GameObject Paper;
    public GameObject Scissors;
    public Text CountDownText;
    public int random = Random.Range(0, 3);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      CountDownText.text = countdown.ToString();
      if(countdown < 0)
      {
        countdown -= Time.deltaTime;
        if(countdown <= 3)
        {
          WinText.SetActive(true);
        }
        if(countdown <= 2)
        {
          if(random == 0)
          {
            Rock.SetActive(true);
          }
          if(random == 1)
          {
            Paper.SetActive(true);
          }
          if(random == 2)
          {
            Scissors.SetActive(true);　
          }
        }
        if(countdown >= 0 && countdown <= 1)
        {

        }
      }

    }
}
