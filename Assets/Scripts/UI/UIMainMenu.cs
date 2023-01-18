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
    public Button toCharacterList;

    bool isOpen;
    int myCoin;

    void Start()
    {
        //GameManager�� Coin �ҷ�����
        myCoin = GameManager.GetInstance().Coin;
        txtCoin.text = $"x {myCoin}";

        //UI���� �ʱ�ȭ
        isOpen = false;
        MenuGroup.SetActive(false);
        ListGroup.SetActive(false);

        //��ư�� �Լ� �߰�
        btnOpenMenu.onClick.AddListener(OpenMenu);
        btnOpenList.onClick.AddListener(OpenList);
        btnCloseList.onClick.AddListener(CloseList);
        toCam.onClick.AddListener(() => { ScenesManager.GetInstance().ChangeScene(Scene.CamScene); });
        toCharacterList.onClick.AddListener(() => { ScenesManager.GetInstance().ChangeScene(Scene.CharacterList); });
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

}
