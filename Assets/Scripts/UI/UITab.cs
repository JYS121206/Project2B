using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITab : MonoBehaviour
{
    public Button btnTab;
    //public UIMainMenu uiMainMenu;
    public UIMainMenu1 uiMainMenu1;

    void Start()
    {
        btnTab = GetComponentInChildren<Button>();
        btnTab.onClick.AddListener(OnTab1);
        gameObject.SetActive(false);
    }

    void OnTab()
    {
        //GameManager.GetInstance().GetCoin(uiMainMenu);
    }
    void OnTab1()
    {
        GameManager.GetInstance().GetCoin1(uiMainMenu1);
    }
}
