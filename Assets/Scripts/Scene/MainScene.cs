using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    //아직 사용하지 않는 스크립트입니다
    //나중에 Main 씬에서 적용할 예정!!

    void Start()
    {
        var uiManager = UIManager.GetInstance();
        uiManager.SetEventSystem();
        uiManager.OpenUI("UIMainMenu");
    }
}
