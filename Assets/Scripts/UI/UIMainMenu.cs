using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    // UI������ UIMainMenu�� ����Ǵ� ��ũ��Ʈ�Դϴ�.

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
        //GameManager�� Coin �ҷ�����
        myCoin = GameManager.GetInstance().Coin;
        txtCoin.text = $"x {myCoin}";

        //CharacterManager �Ҵ�
        characterManager = CharacterManager.GetInstance();

        //UI���� �ʱ�ȭ
        isOpen = false;
        MenuGroup.SetActive(false);
        ListGroup.SetActive(false);
        UICharacterList.gameObject.SetActive(false);

        //��ư�� �Լ� �߰�
        btnOpenMenu.onClick.AddListener(OpenMenu);
        btnOpenList.onClick.AddListener(OpenList);
        btnCloseList.onClick.AddListener(CloseList);
        toCam.onClick.AddListener(() => { ScenesManager.GetInstance().ChangeScene(Scene.CamScene); });
        toCharacterList.onClick.AddListener(OpenCharacterList);
        toCr.onClick.AddListener(OpenCharacterList);
    }

    /// <summary>
    /// �޴� ��� UI ����/�ݱ�
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
    /// ĳ���� �ϸ�ũ UI ����
    /// </summary>
    public void OpenList()
    {
        if (ListGroup == null)
            return;

        ListGroup.SetActive(true);
        btnOpenList.gameObject.SetActive(false);
        btnRoom.gameObject.SetActive(false);

        //�ϸ�ũ �̹��� �ʱ�ȭ
        for (int i = 0; i < btnBookmark.Length; i++)
            btnBookmark[i].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/empty");

        //�ϸ�ũ �̹��� ����
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
    /// ĳ���� �ϸ�ũ UI �ݱ�
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
