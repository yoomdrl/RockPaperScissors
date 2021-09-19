using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCountdown : MonoBehaviour
{
    private float countdown = 3.0f;
    public GameObject WinText;
    public GameObject LoseText;
    public GameObject Rock;
    public GameObject Paper;
    public GameObject Scissors;
    public int random;
    public GameObject ButtonRock;
    public GameObject ButtonPaper;
    public GameObject ButtonScissors;
    public GameObject ScoreText;

    public int answered = 0;


    // Start is called before the first frame update
    void Start()
    {
//      random = Random.Range(0, 3);
      random = 0;
      ButtonRock = GameObject.Find("ButtonRock");
      ButtonPaper = GameObject.Find("ButtonPaper");
      ButtonScissors = GameObject.Find("ButtonScissors");
      ScoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
      //タイマーが0になるまで問題ワンセット
      if(countdown > 0.0)
      {
        countdown -= Time.deltaTime;

        //勝敗の指定の表示
        if(countdown <= 2.0)
        {
          WinText.SetActive(true);
          answered = 0;
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
              Debug.Log("Incorrect");
            }
            if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true)
            {
              answered++;
              ScoreText.GetComponent<ScoreScript>().addScore();
              Debug.Log("Correct");
            }
            if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true)
            {
              answered++;
              Debug.Log("Incorrect");
            }
          }
        }
        //未回答だった場合負け
        if(countdown < 0 && answered == 0)
        {
          Debug.Log("GameOver");
        }
      }
          // if(random == 1)
          // {
          //
          // }
          // if(random == 2)
          // {
          //
          // }

    }

}
