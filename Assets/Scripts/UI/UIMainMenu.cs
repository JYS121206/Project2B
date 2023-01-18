using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    // UI프리팹 UIMainMenu에 적용되는 스크립트입니다.

    public Text txtCoin;
    public Button btnSetting;
    public Button btnOpenMenu;
    public GameObject MenuGroup;

    public Button btnRoom;
    public Button btnOpenList;
    public Button btnCloseList;
    public GameObject ListGroup;

    public Button toCam;
    public Button toCharacterList;

    bool isOpen;
    int myCoin;

    void Start()
    {
        //GameManager의 Coin 불러오기
        myCoin = GameManager.GetInstance().Coin;
        txtCoin.text = $"x {myCoin}";

        //UI세팅 초기화
        isOpen = false;
        MenuGroup.SetActive(false);
        ListGroup.SetActive(false);

        //버튼에 함수 추가
        btnOpenMenu.onClick.AddListener(OpenMenu);
        btnOpenList.onClick.AddListener(OpenList);
        btnCloseList.onClick.AddListener(CloseList);
        toCam.onClick.AddListener(() => { ScenesManager.GetInstance().ChangeScene(Scene.CamScene); });
        toCharacterList.onClick.AddListener(() => { ScenesManager.GetInstance().ChangeScene(Scene.CharacterList); });
    }

    /// <summary>
    /// 메뉴 목록 UI 열기/닫기
    /// </summary>
    public void OpenMenu()
    {
        if(MenuGroup == null)
            return;

        if (isOpen)
        {
            MenuGroup.SetActive(false);
            isOpen = false;
        }
        else
        {
            MenuGroup.SetActive(true);
            isOpen = true;
        }
    }

    /// <summary>
    /// 캐릭터 북마크 UI 열기
    /// </summary>
    public void OpenList()
    {
        if (ListGroup == null)
            return;

        ListGroup.SetActive(true);
        btnOpenList.gameObject.SetActive(false);
        btnRoom.gameObject.SetActive(false);
    }

    /// <summary>
    /// 캐릭터 북마크 UI 닫기
    /// </summary>
    public void CloseList()
    {
        if (ListGroup == null)
            return;

        ListGroup.SetActive(false);
        btnOpenList.gameObject.SetActive(true);
        btnRoom.gameObject.SetActive(true);
    }

}
