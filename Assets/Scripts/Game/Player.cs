using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score = 0;
    public TestJump testJump;

    public float limitTime = 20.0f;
    bool isOver = false;

    private void Update()
    {
        if(limitTime>=0)
            limitTime -= Time.deltaTime;

        if (limitTime >= 20)
            limitTime = 20;

        testJump.SetTimer(limitTime);

        if (limitTime <= 0 && !isOver)
        {
            testJump.GameOver(score);
            isOver = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish" && !isOver)
        {
            testJump.GameOver(score);
            isOver = true;
            limitTime = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
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
