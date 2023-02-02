using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSprite : MonoBehaviour
{
    float setSize;


    public GameObject player;
    public GameObject objGameOver;

    public GameObject[] objGroup = new GameObject[4];
    public board[] boardList = new board[4];

    public int x;

    public bool next;

    int curT;
    int curF;
    public float ChangeSize(float cursize)
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;

        float size = (width / 5.625f) * cursize;
        return size;
    }
    
    void Start()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;
        Debug.Log($"height: {height} | width: {width}");

        gameObject.transform.localScale = new Vector3(ChangeSize(1), ChangeSize(1), ChangeSize(1));
        gameObject.transform.position = new Vector3(0, 0, 0);


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
            y -= ChangeSize(4);
            
            objGroup[i].transform.position = new Vector3(-ChangeSize(0.6535448f), y, 0);
        }
        x = (x + 1) % (3 + 1);

        float y2 = objGroup[x].transform.position.y;
        y2 += ChangeSize(16);
        objGroup[x].transform.position = new Vector3(-ChangeSize(0.6535448f), y2, 0);

        LeftRight(x);

        if (next)
            next = false;
        else
            next = true;

    }

    public void LeftRight(int idx)
    {
        var curBoard = boardList[idx];
        //Debug.Log($"curBoard = {idx}��");

        if (next) //���� ���� 3��
        {
            if (curF == 0) //0 => 0
            {
                curT = 0;
                //Debug.Log($"���� 4 ������ {curF}�� | ���� 3 ������ {curT}��");
            }

            else if (curF <= 2) //1 => 0,1 //2 => 1,2
            {
                curT = Random.Range(curF - 1, curF + 1);
                //Debug.Log($"���� 4 ������ {curF}�� | ���� 3 ������ {curT}��");
            }
            else //3 => 2
            {
                curT = 2;
                //Debug.Log($"���� 4 ������ {curF}�� | ���� 3 ������ {curT}��");
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

        else //���� ���� 4��
        {
            curF = Random.Range(curT, curT + 2);
            //Debug.Log($"���� 3 ������ {curT}�� | ���� 4 ������ {curF}��");

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
        x -= ChangeSize(0.75f);
        player.transform.position = new Vector3(x, -ChangeSize(1.5f), 0);
        UpDown();
    }
    public void JumpR()
    {
        float x = player.transform.position.x;
        x += ChangeSize(0.75f);
        player.transform.position = new Vector3(x, -ChangeSize(1.5f), 0);
        UpDown();
    }

}
