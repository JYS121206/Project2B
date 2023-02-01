using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSprite : MonoBehaviour
{
    public GameObject player;
    public GameObject objGameOver;

    public GameObject[] objGroup = new GameObject[4];
    public board[] boardList = new board[4];

    public int x;

    public bool next;

    int curT;
    int curF;


    void Start()
    {
        for (int i = 0; i < objGroup.Length; i++)
        {
            boardList[i] = GetComponentsInChildren<board>()[i];
            objGroup[i] = boardList[i].gameObject;
        }

        x = 3;
        next = true;
        curF = 0;

        //btnJumpL.onClick.AddListener(JumpL);
        //btnJumpR.onClick.AddListener(JumpR);
    }

    public void UpDown()
    {
        for (int i = 0; i < objGroup.Length; i++)
        {
            float y = objGroup[i].transform.position.y;
            y -= 4;

            objGroup[i].transform.position = new Vector3(-0.6535448f, y, 0);
        }
        x = (x + 1) % (3 + 1);

        float y2 = objGroup[x].transform.position.y;
        y2 += 16;
        objGroup[x].transform.position = new Vector3(-0.6535448f, y2, 0);

        LeftRight(x);

        if (next)
            next = false;
        else
            next = true;

    }

    public void LeftRight(int idx)
    {
        var curBoard = boardList[idx];
        //Debug.Log($"curBoard = {idx}번");

        if (next) //다음 발판 3개
        {
            if (curF == 0) //0 => 0
            {
                curT = 0;
                //Debug.Log($"현재 4 발판은 {curF}번 | 다음 3 발판은 {curT}번");
            }

            else if (curF <= 2) //1 => 0,1 //2 => 1,2
            {
                curT = Random.Range(curF - 1, curF + 1);
                //Debug.Log($"현재 4 발판은 {curF}번 | 다음 3 발판은 {curT}번");
            }
            else //3 => 2
            {
                curT = 2;
                //Debug.Log($"현재 4 발판은 {curF}번 | 다음 3 발판은 {curT}번");
            }


            for (int i = 0; i < 3; i++)
            {
                curBoard.boards[i].GetComponent<SpriteRenderer>().color = Color.red;

                if (curBoard.boards[i].GetComponent<BoxCollider2D>())
                    curBoard.boards[i].GetComponent<BoxCollider2D>().enabled = false;

                if (i == curT)
                {
                    curBoard.boards[curT].GetComponent<SpriteRenderer>().color = Color.white;

                    if (curBoard.boards[curT].GetComponent<BoxCollider2D>())
                        curBoard.boards[curT].GetComponent<BoxCollider2D>().enabled = true;
                    else
                        curBoard.boards[curT].AddComponent<BoxCollider2D>();
                }
            }

        }

        else //다음 발판 4개
        {
            curF = Random.Range(curT, curT + 2);
            //Debug.Log($"현재 3 발판은 {curT}번 | 다음 4 발판은 {curF}번");

            for (int i = 0; i < 4; i++)
            {
                curBoard.boards[i].GetComponent<SpriteRenderer>().color = Color.red;

                if (curBoard.boards[i].GetComponent<BoxCollider2D>())
                    curBoard.boards[i].GetComponent<BoxCollider2D>().enabled = false;

                if (i == curF)
                {
                    curBoard.boards[curF].GetComponent<SpriteRenderer>().color = Color.white;

                    if (curBoard.boards[curF].GetComponent<BoxCollider2D>())
                        curBoard.boards[curF].GetComponent<BoxCollider2D>().enabled = true;
                    else
                        curBoard.boards[curF].AddComponent<BoxCollider2D>();
                }
            }
        }

    }

    public void JumpL()
    {
        float x = player.transform.position.x;
        x -= 0.75f;
        player.transform.position = new Vector3(x, -1.5f, 0);
        UpDown();
    }
    public void JumpR()
    {
        float x = player.transform.position.x;
        x += 0.75f;
        player.transform.position = new Vector3(x, -1.5f, 0);
        UpDown();
    }

}
