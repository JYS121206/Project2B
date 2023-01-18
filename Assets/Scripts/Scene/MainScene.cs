using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    //���� ������� �ʴ� ��ũ��Ʈ�Դϴ�
    //���߿� Main ������ ������ ����!!

    void Start()
    {
        var uiManager = UIManager.GetInstance();
        uiManager.SetEventSystem();
        uiManager.OpenUI("UIMainMenu");
    }
}
