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
    public AudioClip Fanfare;
    public AudioClip gamebgm;
    public AudioClip start;
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
    public GameObject HighScoreUpdated;
    public GameObject BGMPlayer;
    public Text ScoreText;
    public Text TimeText;
    public Text GameOverScoreText;
    public Text GameOverHighScoreText;
    public bool answered = false;
    public bool correct = false;
    public bool correctSoundPlayed = false;
    public bool incorrectSoundPlayed = false;
    public bool startActivated = false;
    public int a = 0;
    public int fanfareAwake = 0;
    public int handShown = 0;
    public int WinLoseShown = 0;
    public int WinLoseRandom;
    public int score = 0;
    public int highScore = 0;
    public int restartActivated = 0;
    public int toTitleActivated = 0;
    public int highScoreUpdated = 0;
    public float handRandom;
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
      speedup = Mathf.Pow(1.025f, score);
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
          if(countdown > 1.0)
          {
            ButtonRock.GetComponent<RockPressed>().rockSelect = false;
            ButtonPaper.GetComponent<PaperPressed>().paperSelect = false;
            ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect = false;
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
              if(handRandom >= 3.0f && handRandom < 3.111f)
              {
                TieRock.SetActive(true);
                Debug.Log("PaperScissorsShown");
              }
              if(handRandom >= 3.111f && handRandom < 3.222f)
              {
                TiePaper.SetActive(true);
                Debug.Log("RockScissorsShown");
              }
              if(handRandom >= 3.222f && handRandom < 3.333f)
              {
                TieScissors.SetActive(true);
                Debug.Log("PaperRockShown");
              }
              if(handRandom >= 3.333f && handRandom < 3.444f)
              {
                TieRock1.SetActive(true);
                Debug.Log("ScissorsPaperShown");
              }
              if(handRandom >= 3.444f && handRandom < 3.555f)
              {
                TiePaper1.SetActive(true);
                Debug.Log("ScissorsRockShown");
              }
              if(handRandom >= 3.555f && handRandom < 3.666f)
              {
                TieScissors1.SetActive(true);
                Debug.Log("RockPaperShown");
              }
              if(handRandom >= 3.666f && handRandom < 3.777f)
              {
                Rock.SetActive(true);
                Debug.Log("RockShown");
              }
              if(handRandom >= 3.777f && handRandom < 3.888f)
              {
                Paper.SetActive(true);
                Debug.Log("PaperShown");
              }
              if(handRandom >= 3.888f && handRandom < 4.00f)
              {
                Scissors.SetActive(true);
                Debug.Log("ScissorsShown");
              }
            }
          }
        }

        //プレイヤーが正しい選択肢を選ぶと次の問題にいける、外したら負け
        if(countdown >= -0.2 && countdown <= 1.0)
        {
          //グーに勝て！だった場合
          if(handRandom >= 0.0f && handRandom < 1.0f && answered == false && WinLoseRandom == 0)
          {
            IfPaperCorrect();
          }
          //パーに勝て！だった時
          if(handRandom >= 1.0f && handRandom < 2.0f && answered == false　&& WinLoseRandom == 0)
          {
            IfScissorsCorrect();
          }
        //チョキに勝て！だった時
          if(handRandom >= 2.0f && handRandom < 3.0f && answered == false && WinLoseRandom == 0)
          {
            IfRockCorrect();
          }

          //グーに負けろ！だった時
          if(handRandom >= 0.0f && handRandom < 1.0f && answered == false && WinLoseRandom == 1)
          {
            IfScissorsCorrect();
          }
          //パーに負けろ！だった時
          if(handRandom >= 1.0f && handRandom < 2.0f && answered == false && WinLoseRandom == 1)
          {
            IfRockCorrect();
          }
          //チョキに負けろ！だった時
          if(handRandom >= 2.0f && handRandom < 3.0f && answered == false && WinLoseRandom == 1)
          {
            IfPaperCorrect();
          }

          //チョキパーに引き分けろ！だった時
          if(handRandom >= 3.00f && handRandom < 3.111f && answered == false && WinLoseRandom == 2)
          {
            IfRockCorrect();
          }
          //グーチョキに引き分けろ！だった場合
          if(handRandom >= 3.111f && handRandom < 3.222f && answered == false && WinLoseRandom == 2)
          {
            IfPaperCorrect();
          }
          //グーパーに引き分けろ！だった場合
          if(handRandom >= 3.222f && handRandom < 3.333f && answered == false && WinLoseRandom == 2)
          {
            IfScissorsCorrect();
          }
          //パーチョキに引き分けろ！だった時
          if(handRandom >= 3.333f && handRandom < 3.444f && answered == false && WinLoseRandom == 2)
          {
            IfRockCorrect();
          }
          //チョキぐーに引き分けろ！だった場合
          if(handRandom >= 3.444f && handRandom < 3.555f && answered == false && WinLoseRandom == 2)
          {
            IfPaperCorrect();
          }
          //パーグーに引き分けろ！だった場合
          if(handRandom >= 3.555f && handRandom < 3.666f && answered == false && WinLoseRandom == 2)
          {
            IfScissorsCorrect();
          }
          //グーに引き分けろ！だった場合
          if(handRandom >= 3.666f && handRandom < 3.777f && answered == false && WinLoseRandom == 2)
          {
            IfRockCorrect();
          }
          //パーに引き分けろ！だった場合
          if(handRandom >= 3.777f && handRandom < 3.888f && answered == false && WinLoseRandom == 2)
          {
            IfPaperCorrect();
          }
          //チョキに引き分けろ！だった場合
          if(handRandom >= 3.888f && handRandom < 4.000f && answered == false && WinLoseRandom == 2)
          {
            IfScissorsCorrect();
          }
      }
    }


    //正解を出せた場合、次の問題に移行　要するにリセット
    if(countdown < 0.2 && answered == true && correct == true)
    {
      reset();
    }


      //未回答の場合負け
      if(countdown < -0.2 && answered == false)
      {
        Debug.Log("TimeOutGameOver");
        InCorrectOption();
        BGMPlayer.GetComponent<BGMPlayer>().bgmPlaying = false;
      }

      //ゲームオーバー画面の表示
      if(incorrectSoundPlayed == true)
      {
        startActivated = false;
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
            highScoreUpdated++;
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
          if(highScoreUpdated == 1 && fanfareAwake == 0)
          {
            audioSource.PlayOneShot(Fanfare);
            HighScoreUpdated.SetActive(true);
            fanfareAwake++;
          }
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
        incorrectSoundPlayed = false;
        GameOverDisplay = 0;
        score = 0;
        RestartButton.GetComponent<RestartPressed>().restartSelect = false;
        BGMPlayer.GetComponent<BGMPlayer>().a = 0;
        BGMPlayer.GetComponent<BGMPlayer>().bgmPlaying = true;
        if(startActivated == false)
        {
          audioSource.PlayOneShot(start);
          startActivated = true;
        }
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
        incorrectSoundPlayed = false;
        GameOverDisplay = 0;
        score = 0;
        SceneManager.LoadScene("Title");
        TitleScreenButton.GetComponent<ToTitlePressed>().toTitleSelect = false;
      }

  }

  public void InCorrectOption()
    {
      if(incorrectSoundPlayed == false)
      {
        incorrectSoundPlayed = true;
        audioSource.PlayOneShot(incorrectSound);
      }

    }

    public void CorrectOption()
    {
      correct = true;
      score++;
      if(correctSoundPlayed == false)
      {
        correctSoundPlayed = true;
        audioSource.PlayOneShot(correctSound);
      }
    }

    public void IfRockCorrect()
    {
      if(ButtonRock.GetComponent<RockPressed>().rockSelect == true || Input.GetKeyDown(KeyCode.S))
      {
        answered = true;
        CorrectOption();
        Debug.Log("グーにグーCorrect");
      }
      if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true || Input.GetKeyDown(KeyCode.D))
      {
        answered = true;
        InCorrectOption();
        Debug.Log("グーにパーInCorrectGameOver");
        BGMPlayer.GetComponent<BGMPlayer>().bgmPlaying = false;
      }
      if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true || Input.GetKeyDown(KeyCode.A))
      {
        answered = true;
        InCorrectOption();
        Debug.Log("グーにチョキInCorrectGameOver");
        BGMPlayer.GetComponent<BGMPlayer>().bgmPlaying = false;
      }
    }
    public void IfPaperCorrect()
    {
      if(ButtonRock.GetComponent<RockPressed>().rockSelect == true || Input.GetKeyDown(KeyCode.S))
      {
        answered = true;
        InCorrectOption();
        BGMPlayer.GetComponent<BGMPlayer>().bgmPlaying = false;
        Debug.Log("パーにグーInCorrectGameOver");
      }
      if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true || Input.GetKeyDown(KeyCode.D))
      {
        answered = true;
        CorrectOption();
        Debug.Log("パーにパーCorrect");
      }
      if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true || Input.GetKeyDown(KeyCode.A))
      {
        answered = true;
        InCorrectOption();
        Debug.Log("パーにチョキInCorrectGameOver");
        BGMPlayer.GetComponent<BGMPlayer>().bgmPlaying = false;
      }
    }

    public void IfScissorsCorrect()
    {
      if(ButtonRock.GetComponent<RockPressed>().rockSelect == true || Input.GetKeyDown(KeyCode.S))
      {
        answered = true;
        InCorrectOption();
        Debug.Log("チョキにグーInCorrectGameOver");
        BGMPlayer.GetComponent<BGMPlayer>().bgmPlaying = false;
      }
      if(ButtonPaper.GetComponent<PaperPressed>().paperSelect == true || Input.GetKeyDown(KeyCode.D))
      {
        answered = true;
        InCorrectOption();
        Debug.Log("チョキにパーInCorrectGameOver");
        BGMPlayer.GetComponent<BGMPlayer>().bgmPlaying = false;
      }
      if(ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect == true || Input.GetKeyDown(KeyCode.A))
      {
        answered = true;
        CorrectOption();
        Debug.Log("チョキCorrect");
      }
    }

    public void reset()
    {
      countdown = 3.0f;
      answered = false;
      correct = false;
      handShown = 0;
      WinLoseShown = 0;
      correctSoundPlayed = false;
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
      GameOverText.SetActive(false);
      HighScoreUpdated.SetActive(false);
      ButtonRock.GetComponent<RockPressed>().rockSelect = false;
      ButtonPaper.GetComponent<PaperPressed>().paperSelect = false;
      ButtonScissors.GetComponent<ScissorsPressed>().scissorsSelect = false;
      a = 0;
      restartActivated = 0;
      toTitleActivated = 0;
      highScoreUpdated = 0;
      fanfareAwake = 0;
    }

}


//以下メモ
//answeredと言うint値は一度の問題に2回以上回答することができないように設定されている
//answeredとcorrectの両方の値が増えないと次の問題に行かない
