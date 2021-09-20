using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCountdown : MonoBehaviour
{
    public AudioClip rhythm1;
    public AudioClip rhythm2;
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public GameObject WinText;
    public GameObject LoseText;
    public GameObject Rock;
    public GameObject Paper;
    public GameObject Scissors;
    public GameObject ButtonRock;
    public GameObject ButtonPaper;
    public GameObject ButtonScissors;
    public GameObject RestartButton;
    public GameObject GameOverBlur;
    public GameObject GameOverText;
    public GameObject GameOverUI;
    public GameObject GameOverUI2;
    public GameObject RestartUI;
    public Text ScoreText;
    public Text GameOverScoreText;
    public Text GameOverHighScoreText;
    public int a = 0;
    public int handRandom;
    public int WinLoseRandom;
    public int score = 0;
    public int correctSoundPlayed = 0;
    public int incorrectSoundPlayed = 0;
    public int answered = 0;
    public int correct = 0;
    public int highScore = 0;
    public int restartActivated = 0;
    public float GameOverDisplay = 0.0f;
    public float countdown = 3.0f;

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
      handRandom = Random.Range(0, 3);
      WinLoseRandom = Random.Range(0, 2);
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
      if(countdown > -0.3)
      {
        countdown -= Time.deltaTime;


        //勝敗の指定の表示
        if(countdown <= 2.0)
        {
          if(a == 0)
          {
            audioSource.PlayOneShot(rhythm1);
            a++;
          }
          if(WinLoseRandom == 0)
          {
            WinText.SetActive(true);
          }
          if(WinLoseRandom == 1)
          {
            LoseText.SetActive(true);
          }
          incorrectSoundPlayed = 0;
        }


        //相手の手がグーチョキパーの三択から出る
        if(countdown <= 1.0)
        {
          if(a == 1)
          {
            audioSource.PlayOneShot(rhythm2);
            a++;
          }
          if(handRandom == 0)
          {
            Rock.SetActive(true);
          }
          if(handRandom == 1)
          {
            Paper.SetActive(true);
          }
          if(handRandom == 2)
          {
            Scissors.SetActive(true);　
          }
        }

        //プレイヤーが正しい選択肢を選ぶと次の問題にいける、外したら負け
        if(countdown >= -0.2 && countdown <= 1.0)
        {
          //グーに勝て！だった時
          if(handRandom == 0 && answered == 0　&& WinLoseRandom == 0)
          {
            if(ButtonRock.GetComponent<RockPressed>().rockSelect == true)
            {
              answered++;
              InCorrectOption();
              Debug.Log("グーに勝つグーInCorrectGameOver");
            }
            if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true)
            {
              answered++;
              CorrectOption();
              Debug.Log("グーに勝つパーCorrect");
            }
            if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true)
            {
              answered++;
              InCorrectOption();
              Debug.Log("グーに勝つチョキInCorrectGameOver");
            }
          }

        //パーに勝て！だった時
        if(handRandom == 1 && answered == 0　&& WinLoseRandom == 0)
        {
          if(ButtonRock.GetComponent<RockPressed>().rockSelect == true)
          {
            answered++;
            InCorrectOption();
            Debug.Log("パーに勝つグーInCorrectGameOver");
          }
          if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true)
          {
            answered++;
            InCorrectOption();
            Debug.Log("パーに勝つパーInCorrectGameOver");
          }
          if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true)
          {
            answered++;
            CorrectOption();
            Debug.Log("パーに勝つチョキCorrect");
          }
        }

        //チョキに勝て！だった時
        if(handRandom == 2 && answered == 0　&& WinLoseRandom == 0)
        {
          if(ButtonRock.GetComponent<RockPressed>().rockSelect == true)
          {
            answered++;
            CorrectOption();
            Debug.Log("チョキに勝つグーCorrect");
          }
          if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true)
          {
            answered++;
            InCorrectOption();
            Debug.Log("チョキに勝つパーInCorrectGameOver");
          }
          if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true)
          {
            answered++;
            InCorrectOption();
            Debug.Log("チョキに勝つチョキInCorrectGameOver");
          }
        }


        //グーに負けろ！だった時
        if(handRandom == 0 && answered == 0 && WinLoseRandom == 1)
        {
          if(ButtonRock.GetComponent<RockPressed>().rockSelect == true)
          {
            answered++;
            InCorrectOption();
            Debug.Log("グーに負けるグーInCorrectGameOver");
          }
          if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true)
          {
            answered++;
            InCorrectOption();
            Debug.Log("グーに負けるパーInCorrectGameOver");
          }
          if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true)
          {
            answered++;
            CorrectOption();
            Debug.Log("グーに負けるチョキCorrect");
          }
        }

        //パーに負けろ！だった時
        if(handRandom == 1 && answered == 0 && WinLoseRandom == 1)
        {
          if(ButtonRock.GetComponent<RockPressed>().rockSelect == true)
          {
            answered++;
            CorrectOption();
            Debug.Log("パーに負けるグーCorrect");
          }
          if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true)
          {
            answered++;
            InCorrectOption();
            Debug.Log("パーに負けるパーInCorrectGameOver");
          }
          if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true)
          {
            answered++;
            InCorrectOption();
            Debug.Log("パーに負けるチョキInCorrectGameOver");
          }
        }

          //チョキに負けろ！だった時
          if(handRandom == 2 && answered == 0 && WinLoseRandom == 1)
          {
            if(ButtonRock.GetComponent<RockPressed>().rockSelect == true)
            {
              answered++;
              InCorrectOption();
              Debug.Log("チョキに負けるグーInCorrectGameOver");
            }
            if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true)
            {
              answered++;
              CorrectOption();
              Debug.Log("チョキに負けるパーCorrect");
            }
            if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true)
            {
              answered++;
              InCorrectOption();
              Debug.Log("チョキに負けるチョキInCorrectGameOver");
            }
          }
      }
    }


    //正解を出せた場合、次の問題に移行　要するにリセット
    if(countdown < 0.2 && answered >= 1 && correct == 1)
    {
      reset();
    }


      //未回答の場合負け
      if(countdown < -0.2 && answered == 0)
      {
        Debug.Log("TimeOutGameOver");
        InCorrectOption();
      }

      //ゲームオーバー画面の表示
      if(incorrectSoundPlayed >= 1)
      {
        GameOverDisplay += Time.deltaTime;
        if(GameOverDisplay > 1.0f)
        {
          GameOverBlur.SetActive(true);
        }
        if(GameOverDisplay > 2.0f)
        {
          GameOverText.SetActive(true);
        }
        if(GameOverDisplay > 3.0f)
        {
        GameOverUI.SetActive(true);
        GameOverScoreText.text = "Score: " + score.ToString();
        }
        if(GameOverDisplay > 4.0f)
        {
          if(score > highScore)
          {
            highScore = score;
            GameOverHighScoreText.text = "HighScore: " + highScore.ToString();
          }
          else
          {
            GameOverHighScoreText.text = "HighScore: " + highScore.ToString();
          }
          GameOverUI2.SetActive(true);
        }
        if(GameOverDisplay > 5.0f)
        {
          RestartUI.SetActive(true);
        }
      }

      //リスタートボタンが押された時
      if(RestartButton.GetComponent<RestartPressed>().restartSelect == true)
      {
        restartActivated++;
        reset();
        GameOverBlur.SetActive(false);
        GameOverUI.SetActive(false);
        GameOverUI2.SetActive(false);
        RestartUI.SetActive(false);
      }

  }

  public void InCorrectOption()
    {
      if(incorrectSoundPlayed == 0)
      {
        incorrectSoundPlayed++;
        audioSource.PlayOneShot(incorrectSound);
      }

    }

    public void CorrectOption()
    {
      correct++;
      score++;
      if(correctSoundPlayed == 0)
      {
        correctSoundPlayed++;
        audioSource.PlayOneShot(correctSound);
      }
    }

    public void reset()
    {
      countdown = 3.0f;
      answered = 0;
      correct = 0;
      correctSoundPlayed = 0;
      Rock.SetActive(false);
      Paper.SetActive(false);
      Scissors.SetActive(false);
      WinText.SetActive(false);
      LoseText.SetActive(false);
      ButtonRock.GetComponent<RockPressed>().rockSelect = false;
      ButtonPaper.GetComponent<PaperPressed>().paperSelect = false;
      ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect = false;
      handRandom = Random.Range(0, 3);
      WinLoseRandom = Random.Range(0, 2);
      a = 0;
      restartActivated = 0;
    }

}


//以下メモ
//answeredと言うint値は一度の問題に2回以上回答することができないように設定されている
//answeredとcorrectの両方の値が増えないと次の問題に行かない
