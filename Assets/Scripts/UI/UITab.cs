using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITab : MonoBehaviour
{
    Button btnTab;
    public UIMainMenu uiMainMenu;

    void Start()
    {
        btnTab = GetComponentInChildren<Button>();
        btnTab.onClick.AddListener(OnTab);
        gameObject.SetActive(false);
    }

    void OnTab()
    {
        GameManager.GetInstance().GetCoin(uiMainMenu);
    }
}
