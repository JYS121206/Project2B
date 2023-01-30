using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopMenu : MonoBehaviour
{
    // UI프리팹 UIShopMenu에 적용되는 스크립트입니다.

    public Text txtCoin;
    int myCoin;

    public Button btnToMain;

    public GameObject UIItemList;
    public GameObject UIItem;

    public Button btnTestOpen;
    public Button btnTestClose;
    public GameObject objTest;

    void Start()
    {
        SetCoin();
        btnToMain.onClick.AddListener(() => { ScenesManager.GetInstance().ChangeScene(Scene.Main1); });
        btnTestOpen.onClick.AddListener(TestOpen);
        btnTestClose.onClick.AddListener(TestClose);
    }

    public void SetCoin()
    {
        myCoin = (int)GameManager.GetInstance().curCoin;
        txtCoin.text = $"x {myCoin}";
    }

    public void TestOpen()
    {
        objTest.SetActive(true);
    }
    public void TestClose()
    {
        objTest.SetActive(false);
    }
}
