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
    public Button toCr;
    public Button toCharacterList;
    public GameObject UICharacterList;

    public Button[] btnBookmark = new Button[3];

    bool isOpen;
    int myCoin;

    CharacterManager characterManager;

    void Start()
    {
        //GameManager의 Coin 불러오기
        myCoin = GameManager.GetInstance().Coin;
        txtCoin.text = $"x {myCoin}";

        //CharacterManager 할당
        characterManager = CharacterManager.GetInstance();

        //UI세팅 초기화
        isOpen = false;
        MenuGroup.SetActive(false);
        ListGroup.SetActive(false);
        UICharacterList.gameObject.SetActive(false);

        //버튼에 함수 추가
        btnOpenMenu.onClick.AddListener(OpenMenu);
        btnOpenList.onClick.AddListener(OpenList);
        btnCloseList.onClick.AddListener(CloseList);
        toCam.onClick.AddListener(() => { ScenesManager.GetInstance().ChangeScene(Scene.CamScene); });
        toCharacterList.onClick.AddListener(OpenCharacterList);
        toCr.onClick.AddListener(OpenCharacterList);
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

        //북마크 이미지 초기화
        for (int i = 0; i < btnBookmark.Length; i++)
            btnBookmark[i].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/empty");

        //북마크 이미지 세팅
        int x = 0;
        for (int i = 0; i < characterManager.Character.Length; i++)
        {
            if (characterManager.Character[i].isBookmark)
            {
                btnBookmark[x].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/{characterManager.Character[i].characterName}");
                x++;
            }
            if (x >= 3)
                return;
        }
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

    public void OpenCharacterList()
    {
        UICharacterList.gameObject.SetActive(true);
        CloseList();
    }

}
