using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score = 0;
    public TestJump testJump;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            Debug.Log($"Game Over");
            testJump.gameOver.SetActive(true);
            testJump.objPlaying.gameObject.SetActive(false);
            GameManager.GetInstance().curCoin += score;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "board")
        {
            score++;
            Debug.Log($"score: {score}");
            testJump.SetScore(score);
        }
    }
}
