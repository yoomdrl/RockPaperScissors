using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReGameCountdownExpert : MonoBehaviour
{
    public AudioClip rhythm1;
    public AudioClip rhythm2;
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public GameObject WinText;
    public GameObject LoseText;
    public GameObject TieText;
    public GameObject Rock;
    public GameObject Paper;
    public GameObject Scissors;
    public GameObject TieRock;
    public GameObject TiePaper;
    public GameObject TieScissors;
    public GameObject TieRock1;
    public GameObject TiePaper1;
    public GameObject TieScissors1;
    public GameObject ButtonRock;
    public GameObject ButtonPaper;
    public GameObject ButtonScissors;
    public GameObject RestartButton;
    public GameObject TitleScreenButton;
    public GameObject GameOverBlur;
    public GameObject GameOverText;
    public GameObject GameOverUI;
    public GameObject GameOverUI2;
    public GameObject RestartUI;
    public Text ScoreText;
    public Text TimeText;
    public Text GameOverScoreText;
    public Text GameOverHighScoreText;
    public int a = 0;
    public float handRandom;
    public int handShown = 0;
    public int WinLoseShown = 0;
    public int WinLoseRandom;
    public int score = 0;
    public int correctSoundPlayed = 0;
    public int incorrectSoundPlayed = 0;
    public int answered = 0;
    public int correct = 0;
    public int highScore = 0;
    public int restartActivated = 0;
    public int toTitleActivated = 0;
    public float GameOverDisplay = 0.0f;
    public float countdown = 3.0f;
    public float speedup;

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
      ButtonRock = GameObject.Find("ButtonRock");
      ButtonPaper = GameObject.Find("ButtonPaper");
      ButtonScissors = GameObject.Find("ButtonScissors");
      audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      speedup = Mathf.Pow(1.05f, score);
      ScoreText.text = score.ToString();
      TimeText.text = countdown.ToString();

      //タイマーが0になるまで問題ワンセット
      if(countdown > -0.3)
      {
        countdown -= speedup * Time.deltaTime;
        if(WinLoseShown == 0)
        {
          WinLoseRandom = Random.Range(0, 3);
          WinLoseShown++;
        }


        //勝敗の指定の表示
        if(countdown <= 2.0)
        {
          if(a == 0)
          {
            audioSource.PlayOneShot(rhythm1);
            a++;
          }
          if(handShown == 0)
          {
            if(WinLoseRandom == 0)
            {
              WinText.SetActive(true);
              handRandom = Random.Range(0.0f, 3.0f);
            }
            if(WinLoseRandom == 1)
            {
              LoseText.SetActive(true);
              handRandom = Random.Range(0.0f, 3.0f);
            }
            if(WinLoseRandom == 2)
            {
              TieText.SetActive(true);
              handRandom = Random.Range(3.0f, 4.0f);
            }
            handShown++;
          }
        }


        if(countdown <= 1.0)
        {
          if(a == 1)
          {
            audioSource.PlayOneShot(rhythm2);
            a++;
            //WinLoseRandomが0(勝て！)か1(負けろ！)だった場合
            if(WinLoseRandom == 0 || WinLoseRandom == 1)
            {
              if(handRandom >= 0.0f && handRandom < 1.0f)
              {
                Rock.SetActive(true);
                Debug.Log("RockShown");
              }
              if(handRandom >= 1.0f && handRandom < 2.0f)
              {
                Paper.SetActive(true);
                Debug.Log("PaperShown");
              }
              if(handRandom >= 2.0f && handRandom < 3.0f)
              {
                Scissors.SetActive(true);　
                Debug.Log("ScissorsShown");
              }
            }
            //WinLoseRandomが2(引き分けろ！)だった場合
            if(WinLoseRandom == 2)
            {
              if(handRandom >= 3.0f && handRandom < 3.16f)
              {
                TieRock.SetActive(true);
                Debug.Log("PaperScissorsShown");
              }
              if(handRandom >= 3.16f && handRandom < 3.33f)
              {
                TiePaper.SetActive(true);
                Debug.Log("RockScissorsShown");
              }
              if(handRandom >= 3.33f && handRandom < 3.50f)
              {
                TieScissors.SetActive(true);
                Debug.Log("PaperRockShown");
              }
              if(handRandom >= 3.50f && handRandom < 3.66f)
              {
                TieRock1.SetActive(true);
                Debug.Log("ScissorsPaperShown");
              }
              if(handRandom >= 3.66f && handRandom < 3.83f)
              {
                TiePaper1.SetActive(true);
                Debug.Log("ScissorsRockShown");
              }
              if(handRandom >= 3.83f && handRandom < 4.0f)
              {
                TieScissors1.SetActive(true);
                Debug.Log("RockPaperShown");
              }
            }
          }
        }

        //プレイヤーが正しい選択肢を選ぶと次の問題にいける、外したら負け
        if(countdown >= -0.2 && countdown <= 1.0)
        {
          //グーに勝て！だった場合
          if(handRandom >= 0.0f && handRandom < 1.0f && answered == 0 && WinLoseRandom == 0)
          {
            IfPaperCorrect();
          }
          //パーに勝て！だった時
          if(handRandom >= 1.0f && handRandom < 2.0f && answered == 0　&& WinLoseRandom == 0)
          {
            IfScissorsCorrect();
          }
        //チョキに勝て！だった時
          if(handRandom >= 2.0f && handRandom < 3.0f && answered == 0　&& WinLoseRandom == 0)
          {
            IfRockCorrect();
          }

          //グーに負けろ！だった時
          if(handRandom >= 0.0f && handRandom < 1.0f && answered == 0 && WinLoseRandom == 1)
          {
            IfScissorsCorrect();
          }
          //パーに負けろ！だった時
          if(handRandom >= 1.0f && handRandom < 2.0f && answered == 0 && WinLoseRandom == 1)
          {
            IfRockCorrect();
          }
          //チョキに負けろ！だった時
          if(handRandom >= 2.0f && handRandom < 3.0f && answered == 0 && WinLoseRandom == 1)
          {
            IfPaperCorrect();
          }

          //グーに引き分けろ！だった時
          if(handRandom >= 3.00f && handRandom < 3.16f && answered == 0 && WinLoseRandom == 2)
          {
            IfRockCorrect();
          }
          //パーに引き分けろ！だった場合
          if(handRandom >= 3.16f && handRandom < 3.33f && answered == 0 && WinLoseRandom == 2)
          {
            IfPaperCorrect();
          }
          //チョキに引き分けろ！だった場合
          if(handRandom >= 3.33f && handRandom < 3.50f && answered == 0 && WinLoseRandom == 2)
          {
            IfScissorsCorrect();
          }
          //グー1に引き分けろ！だった時
          if(handRandom >= 3.50f && handRandom < 3.66f && answered == 0 && WinLoseRandom == 2)
          {
            IfRockCorrect();
          }
          //パー1に引き分けろ！だった場合
          if(handRandom >= 3.66f && handRandom < 3.83f && answered == 0 && WinLoseRandom == 2)
          {
            IfPaperCorrect();
          }
          //チョキ1に引き分けろ！だった場合
          if(handRandom >= 3.83f && handRandom < 4.00f && answered == 0 && WinLoseRandom == 2)
          {
            IfScissorsCorrect();
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
        incorrectSoundPlayed = 0;
        GameOverDisplay = 0;
        score = 0;
        RestartButton.GetComponent<RestartPressed>().restartSelect = false;
      }

      //タイトルボタンが押された時
      if(TitleScreenButton.GetComponent<ToTitlePressed>().toTitleSelect == true)
      {
        toTitleActivated++;
        reset();
        GameOverBlur.SetActive(false);
        GameOverUI.SetActive(false);
        GameOverUI2.SetActive(false);
        RestartUI.SetActive(false);
        incorrectSoundPlayed = 0;
        GameOverDisplay = 0;
        score = 0;
        SceneManager.LoadScene("Title");
        TitleScreenButton.GetComponent<ToTitlePressed>().toTitleSelect = false;
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

    public void IfRockCorrect()
    {
      if(ButtonRock.GetComponent<RockPressed>().rockSelect == true)
      {
        answered++;
        CorrectOption();
        Debug.Log("グーにグーCorrect");
      }
      if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true)
      {
        answered++;
        InCorrectOption();
        Debug.Log("グーにパーInCorrectGameOver");
      }
      if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true)
      {
        answered++;
        InCorrectOption();
        Debug.Log("グーにチョキInCorrectGameOver");
      }
    }
    public void IfPaperCorrect()
    {
      if(ButtonRock.GetComponent<RockPressed>().rockSelect == true)
      {
        answered++;
        InCorrectOption();
        Debug.Log("パーにグーInCorrectGameOver");
      }
      if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true)
      {
        answered++;
        CorrectOption();
        Debug.Log("パーにパーCorrect");
      }
      if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true)
      {
        answered++;
        InCorrectOption();
        Debug.Log("パーにチョキInCorrectGameOver");
      }
    }

    public void IfScissorsCorrect()
    {
      if(ButtonRock.GetComponent<RockPressed>().rockSelect == true)
      {
        answered++;
        InCorrectOption();
        Debug.Log("チョキにグーInCorrectGameOver");
      }
      if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true)
      {
        answered++;
        InCorrectOption();
        Debug.Log("チョキにパーInCorrectGameOver");
      }
      if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true)
      {
        answered++;
        CorrectOption();
        Debug.Log("チョキCorrect");
      }
    }

    public void reset()
    {
      countdown = 3.0f;
      answered = 0;
      correct = 0;
      handShown = 0;
      WinLoseShown = 0;
      correctSoundPlayed = 0;
      Rock.SetActive(false);
      Paper.SetActive(false);
      Scissors.SetActive(false);
      TieRock.SetActive(false);
      TiePaper.SetActive(false);
      TieScissors.SetActive(false);
      TieRock1.SetActive(false);
      TiePaper1.SetActive(false);
      TieScissors1.SetActive(false);
      WinText.SetActive(false);
      LoseText.SetActive(false);
      TieText.SetActive(false);
      ButtonRock.GetComponent<RockPressed>().rockSelect = false;
      ButtonPaper.GetComponent<PaperPressed>().paperSelect = false;
      ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect = false;
      a = 0;
      restartActivated = 0;
      toTitleActivated = 0;
    }

}


//以下メモ
//answeredと言うint値は一度の問題に2回以上回答することができないように設定されている
//answeredとcorrectの両方の値が増えないと次の問題に行かない
