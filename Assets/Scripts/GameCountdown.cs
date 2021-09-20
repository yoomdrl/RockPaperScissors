using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCountdown : MonoBehaviour
{
    public AudioClip start;
    public AudioClip rhythm1;
    public AudioClip rhythm2;
    public AudioClip correct;
    public AudioClip incorrect;
    public GameObject WinText;
    public GameObject LoseText;
    public GameObject Rock;
    public GameObject Paper;
    public GameObject Scissors;
    public GameObject ButtonRock;
    public GameObject ButtonPaper;
    public GameObject ButtonScissors;
    public Text ScoreText;
    public int a = 0;
    public int random;
    public int score = 0;
    public int answered = 0;
    public float countdown = 3.0f;

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
      random = Random.Range(0, 3);
      ButtonRock = GameObject.Find("ButtonRock");
      ButtonPaper = GameObject.Find("ButtonPaper");
      ButtonScissors = GameObject.Find("ButtonScissors");
      audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      ScoreText.text = score.ToString();

      //タイマーが0になるまで問題ワンセット
      if(countdown > -0.1)
      {
        // if(countdown == 3.0)
        // {
        //   answered = 0;
        // }
        countdown -= Time.deltaTime;

        //勝敗の指定の表示
        if(countdown <= 2.0)
        {
          WinText.SetActive(true);
        }

        //相手の手がグーチョキパーの三択から出る
        if(countdown <= 1.0)
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

        //プレイヤーが正しい選択肢を選ぶと次の問題にいける、外したら負け
        if(countdown >= 0.0 && countdown <= 1.0)
        {
          //グーだった時
          if(random == 0 && answered == 0)
          {
            if(ButtonRock.GetComponent<RockPressed>().rockSelect == true)
            {
              answered++;
              Debug.Log("グーグーIncorrectGameOver");
            }
            if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true)
            {
              answered++;
              score++;
              Debug.Log("グーパーCorrect");
            }
            if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true)
            {
              answered++;
              Debug.Log("グーチョキIncorrectGameOver");
            }
          }
          //パーだった時
        if(random == 1 && answered == 0)
        {
          if(ButtonRock.GetComponent<RockPressed>().rockSelect == true)
          {
            answered++;
            Debug.Log("パーグーIncorrectGameOver");
          }
          if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true)
          {
          answered++;
            Debug.Log("パーパーInCorrectGameOver");
          }
          if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true)
          {
            answered++;
            score++;
            Debug.Log("パーチョキCorrect");
          }
        }

        //チョキだった時
        if(random == 2 && answered == 0)
        {
          if(ButtonRock.GetComponent<RockPressed>().rockSelect == true)
          {
            answered++;
            score++;
            Debug.Log("チョキグーCorrect");
          }
          if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true)
          {
            answered++;
            Debug.Log("チョキパーInCorrectGameOver");
          }
          if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true)
          {
            answered++;
            Debug.Log("チョキチョキInCorrectGameOver");
          }
        }
      }
    }
      //未回答の場合負け
      if(countdown < -0.1 && answered == 0)
      {
        Debug.Log("TimeOutGameOver");
      }
      //正解を出せた場合、次の問題に移行　要するにリセット
      if(countdown < 0.0 && answered >= 1)
      {
        countdown = 3.0f;
        answered = 0;
        Rock.SetActive(false);
        Paper.SetActive(false);
        Scissors.SetActive(false);
        WinText.SetActive(false);
        ButtonRock.GetComponent<RockPressed>().rockSelect = false;
        ButtonPaper.GetComponent<PaperPressed>().paperSelect = false;
        ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect = false;
        random = Random.Range(0, 3);
        a = 0;
      }
    }

}
