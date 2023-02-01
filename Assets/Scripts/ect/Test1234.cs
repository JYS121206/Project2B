using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test1234 : MonoBehaviour
{
    public GameObject[] testObj = new GameObject[4];
    //public Button btnTest;
    public Button btnJumpL;
    public Button btnJumpR;

    public GameObject player;

    public int x;

    public bool next;

    int curT;
    int curF;

    public TestTest[] boardList = new TestTest[4];

    void Start()
    {

        x = 3;
        next = true;
        curF = 0;

        for (int i = 0; i < testObj.Length; i++)
        {
            testObj[i] = GetComponentsInChildren<Button>()[i].gameObject;

            Debug.Log($"{i}");
        }

        //btnTest.onClick.AddListener(UpDown);
        btnJumpL.onClick.AddListener(JumpL);
        btnJumpR.onClick.AddListener(JumpR);
    }

    public void UpDown()
    {
        for (int i = 0; i < testObj.Length; i++)
        {
            float y = testObj[i].GetComponent<RectTransform>().anchoredPosition.y;
            y -= 800f;

            testObj[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y, 0);
            Debug.Log($"{testObj[i].GetComponent<RectTransform>().anchoredPosition}");
        }
        x = (x + 1) % (3 + 1);

        float y2 = testObj[x].GetComponent<RectTransform>().anchoredPosition.y;
        y2 += 3200f;
        testObj[x].GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y2, 0);

        LeftRight(x);

        if (next)
            next = false;
        else
            next = true;

    }

    public void LeftRight(int idx)
    {
        var curBoard = boardList[idx];
        Debug.Log($"curBoard = {idx}번");

        if (next) //다음 발판 3개
        {
            if (curF == 0) //0 => 0
            {
                curT = 0;
                Debug.Log($"현재 4 발판은 {curF}번 | 다음 3 발판은 {curT}번");
            }

            else if (curF <= 2) //1 => 0,1 //2 => 1,2
            {
                curT = Random.Range(curF - 1, curF + 1);
                Debug.Log($"현재 4 발판은 {curF}번 | 다음 3 발판은 {curT}번");
            }
            else //3 => 2
            {
                curT = 2;
                Debug.Log($"현재 4 발판은 {curF}번 | 다음 3 발판은 {curT}번");
            }


            for (int i = 0; i < 3; i++)
            {
                curBoard.boards[i].color = Color.white;

                if (i == curT)
                {
                    curBoard.boards[curT].color = Color.black;
                }
            }

        }

        else //다음 발판 4개
        {
            curF = Random.Range(curT, curT + 2);
            Debug.Log($"현재 3 발판은 {curT}번 | 다음 4 발판은 {curF}번");

            for (int i = 0; i < 4; i++)
            {
                curBoard.boards[i].color = Color.white;

                if (i == curF)
                {
                    curBoard.boards[curF].color = Color.black;
                }
            }
        }

    }

    public void JumpL()
    {
        float x = player.GetComponent<RectTransform>().anchoredPosition.x;
        x -= 140f;
        player.GetComponent<RectTransform>().anchoredPosition = new Vector3(x, -705, 0);
        UpDown();
    }
    public void JumpR()
    {
        float x = player.GetComponent<RectTransform>().anchoredPosition.x;
        x += 140f;
        player.GetComponent<RectTransform>().anchoredPosition = new Vector3(x, -705, 0);
        UpDown();
    }

}
