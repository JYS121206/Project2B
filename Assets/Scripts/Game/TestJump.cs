using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TestJump : MonoBehaviour
{
    public Button btnJumpL;
    public Button btnJumpR; 
    public Button btnPlay;
    bool isPlay;
    public Button btnToMain;
    public Text txtScore;
    public GameObject objPlaying;
    public Text txtScore2;
    public Image imgScore2;
    public GameObject gameOver;

    public TestSprite testSprite;
    public Slider timer;

    private void Start()
    {
        isPlay = true;
        btnJumpL.onClick.AddListener(testSprite.JumpL);
        btnJumpR.onClick.AddListener(testSprite.JumpR);
        btnPlay.onClick.AddListener(SetPlay);
        btnToMain.onClick.AddListener(() => { ScenesManager.GetInstance().ChangeScene(Scene.Main1); });
        gameOver.SetActive(false);
    }

    public void SetTimer(float time)
    {
        timer.value = time;
    }

    public void SetPlay()
    {
        if (isPlay)
        {
            gameOver.SetActive(true);
            btnPlay.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/imgPlay");
            Time.timeScale = 0;
            imgScore2.gameObject.SetActive(false);
            isPlay = false;
        }
        else
        {
            gameOver.SetActive(false);
            btnPlay.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/imgStop");
            Time.timeScale = 1;
            imgScore2.gameObject.SetActive(true);
            isPlay = true;
        }
    }

    public void SetScore(int num)
    {
        txtScore.text = $"{num}Á¡";
        txtScore2.text = $"{num}Á¡";
    }

    public void GameOver(int score)
    {
        Debug.Log($"Game Over");
        gameOver.SetActive(true);
        objPlaying.gameObject.SetActive(false);
        GameManager.GetInstance().curCoin += score;
    }
}
