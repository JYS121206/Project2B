using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICamMenu : MonoBehaviour
{
    public Button btnToMain;
    public Button btnToMain2;
    public Button btnOpenCharacterList;
    public Button btnChangeMode;

    public Button btnOpenList;
    public Button btnCloseList;
    public GameObject ListGroup;
    //public GameObject getRabbitMode;
    //public GameObject setRabbitMode;
    public GameObject UIMenuGroup;

    

    public Button[] btnBookmark = new Button[3];

    bool camMode;

    bool isOpen;

    CharacterManager1 characterManager;
    public UICharacterList1 UICharacterList;

    public GetRabbitMode GetRabbitMode;

    void Start()
    {
        camMode = true;
        UIMenuGroup.SetActive(false);
        ListGroup.SetActive(false);
        btnOpenList.gameObject.SetActive(false);


        //btnChangeMode.onClick.AddListener(ChangeMode);
        //btnOpenList.onClick.AddListener(OpenList);
        //btnCloseList.onClick.AddListener(CloseList);

        btnToMain.onClick.AddListener(ToMainScene);
        btnToMain2.onClick.AddListener(ToMainScene);
        btnOpenCharacterList.onClick.AddListener(OpenCharacterList);
        btnChangeMode.onClick.AddListener(ToARSetScene);

    }

    void Update()
    {
        
    }

    public void OpenMenu()
    {
        if (UIMenuGroup == null)
            return;

        if (isOpen)
        {
            UIMenuGroup.SetActive(false);
            isOpen = false;
        }
        else
        {
            UIMenuGroup.SetActive(true);
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

        //북마크 이미지, 버튼 초기화
        for (int i = 0; i < btnBookmark.Length; i++)
        {
            btnBookmark[i].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/empty");
            btnBookmark[i].onClick.RemoveAllListeners();
        }

        //북마크 이미지, 버튼 세팅
        int x = 0;
        for (int i = 0; i < characterManager.Character.Count; i++)
        {
            if (characterManager.Character[i].isBookmark)
            {
                int idx = i;
                btnBookmark[x].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/{characterManager.Character[i].characterName}");
                //btnBookmark[x].onClick.AddListener(() => { UICharacterList.SetPick(idx); });
                Debug.Log($"btnBookmark{x}번에 PickUp{idx} 저장");
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
    }

    public void OpenCharacterList()
    {
        UIMenuGroup.SetActive(false);
        GetRabbitMode.OpenUICharacterList();
    }


    public void ToMainScene()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main1);
    }

    public void ToARSetScene()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.ARSetScene);
    }

}
