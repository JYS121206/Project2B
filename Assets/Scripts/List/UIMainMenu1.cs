using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu1 : MonoBehaviour
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
    public Button btnToShop;
    public Button btnToGame;
    public Button toCharacterList;
    public GameObject UICharacterList;

    public Button[] btnBookmark = new Button[3];

    bool isOpen;
    int myCoin;
    public Image fullHeart;

    public GameObject go;
    public GameObject curPick;

    CharacterManager1 characterManager;

    public int testNum;
    public Button btnTest;

    public UICharacterList1 uICharacterList;

    UIMainMenu1 uIMainMenu1;

    public GameObject imgGuide;
    public GameObject imgTab;

    public void FullHeart(float curExp)
    {
        fullHeart.rectTransform.sizeDelta = new Vector2(100, curExp);
    }

    void Start()
    {
        //CharacterManager �Ҵ�
        characterManager = CharacterManager1.GetInstance();

        uIMainMenu1 = this;


        Debug.Log($"���� ��ǥ ĳ���� �ֳ�?: {characterManager.Pick1st} | {characterManager.Pick}");

        if (characterManager.Pick1st)
        {
            uICharacterList.SetPick(characterManager.Pick);
            Debug.Log($"��ǥ ĳ���� ������ ������ | {characterManager.Pick}�� ĳ���� ������");
        }

        GameManager.GetInstance().SetHeart(uIMainMenu1);

        //GameManager�� Coin �ҷ�����
        SetCoin();


        //UI���� �ʱ�ȭ
        isOpen = false;
        MenuGroup.SetActive(false);
        ListGroup.SetActive(false);

        //��ư�� �Լ� �߰�
        btnOpenMenu.onClick.AddListener(OpenMenu);
        btnOpenList.onClick.AddListener(OpenList);
        btnCloseList.onClick.AddListener(CloseList);
        toCam.onClick.AddListener(() => { ScenesManager.GetInstance().ChangeScene(Scene.CamScene); });
        btnToShop.onClick.AddListener(() => { ScenesManager.GetInstance().ChangeScene(Scene.Shop); });
        btnToGame.onClick.AddListener(GameStart);
        toCharacterList.onClick.AddListener(OpenCharacterList);
        toCr.onClick.AddListener(OpenCharacterList);

        btnTest.onClick.AddListener(() => { TestGetCharacter(); });
    }

    public void GameStart()
    {
        if (characterManager.Pick1st)
            ScenesManager.GetInstance().ChangeScene(Scene.MiniGame);
        else
        {
            Debug.Log($"�÷��� ������ ĳ���Ͱ� �����ϴ�. ��ǥ ĳ���͸� �������ּ���.");
            imgGuide.SetActive(true);
            Invoke("CloseGuide", 0.7f);
        }
    }

    public void SetCoin()
    {
        myCoin = (int)GameManager.GetInstance().curCoin;
        txtCoin.text = $"x {myCoin}";
    }

    public void TestGetCharacter()
    {
        //////// ���� �׽�Ʈ ////////

        characterManager.Character[0].getCharacter = true;
        characterManager.Character[1].getCharacter = true;
        characterManager.Character[2].getCharacter = true;
        characterManager.Character[3].getCharacter = true;
        characterManager.Character[4].getCharacter = true;
        characterManager.Character[5].getCharacter = true;

        Debug.Log($"ĳ���͸� ��� ȹ���߽��ϴ�.");
    }

    /// <summary>
    /// �޴� ��� UI ����/�ݱ�
    /// </summary>
    public void OpenMenu()
    {
        if (MenuGroup == null)
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

        //�ϸ�ũ �̹���, ��ư �ʱ�ȭ
        for (int i = 0; i < btnBookmark.Length; i++)
        {
            btnBookmark[i].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/empty");
            btnBookmark[i].onClick.RemoveAllListeners();
        }

        //�ϸ�ũ �̹���, ��ư ����
        int x = 0;
        for (int i = 0; i < characterManager.Character.Count; i++)
        {
            if (characterManager.Character[i].isBookmark)
            {
                int idx = i;
                btnBookmark[x].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/{characterManager.Character[i].characterName}");
                btnBookmark[x].onClick.AddListener(() => { uICharacterList.SetPick(idx); });
                Debug.Log($"btnBookmark{x}���� PickUp{idx} ����");
                x++;
            }
            if (x >= 3)
                return;
        }

    }

    public void PickUp(int num)
    {
        characterManager.Pick = num;
        Debug.Log($"��ǥ ĳ����: {characterManager.Character[num].characterName}");

        if (go.GetComponentsInChildren<Transform>()[1])
            curPick = (GameObject)go.GetComponentsInChildren<Transform>()[1].gameObject;

        if (curPick)
        {
            Destroy(curPick.gameObject);
            curPick = null;
        }

        Object pickObj = Resources.Load($"GO3D/{characterManager.Character[characterManager.Pick].characterName}");
        GameObject pickCharacter = (GameObject)Instantiate(pickObj, go.transform);
        //pickCharacter.transform.SetParent(go.transform);
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
    }

    public void OpenCharacterList()
    {
        UICharacterList.gameObject.SetActive(true);
        uICharacterList.SetCharacterList();

        CloseList();
    }

    public void CloseGuide()
    {
        imgGuide.SetActive(false);
    }

    public void PopTabEffect()
    {
        imgTab.SetActive(true);
        Invoke("CloseTabEffect", 0.1f);
    }

    public void CloseTabEffect()
    {
        imgTab.SetActive(false);
    }
}
