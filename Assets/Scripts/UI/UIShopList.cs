using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIShopList : MonoBehaviour
{
    public GameObject RoomGroup;  //������ ���
    public GameObject UIItem;     //���� ������

    public Button[] btnRoom = new Button[3];
                                  //�� ����

    public Button[] btnItem;      // ������ ��ư
    public Text[] txtItem;        //������ �̸�
    public Image[] imgItem;       //������ �̹���
    public Image[] imgGetItem;    //������ ������ ǥ�� �̹���

    public Image imgItemProfile;  //������ ���� �̹���
    public Text txtItemProfile;   //������ ���� �̸�
    public Text txtPrice;         //������ ���� ����
    public Text txtAbout;         //������ ���� ����

    public Button btnBuy;         //������ ����
    public Button btnToList;      //������� ���ư���

    public Text txtCoin;
    public Button btnTestCoin;

    OrnamentManager ornamentManager;
    public GameObject imgGuide;

    public void GetCoin()
    {
        GameManager.GetInstance().curCoin += 550;
        txtCoin.text = $"x {(int)GameManager.GetInstance().curCoin}";
    }

    void Start()
    {
        ornamentManager = OrnamentManager.GetInstance();

        ornamentManager.SetOrnaList(0);
        var OrnaList = ornamentManager.GetOrnaList();

        Debug.Log($"�迭ũ��: {OrnaList.Length}");
        Debug.Log($"�����̸�: {OrnaList[1].ornamentName}");
        //Debug.Log($"�迭ũ��: {ornamentManager._ornamentsList[1].Length}");
        //Debug.Log($"�迭ũ��: {ornamentManager._ornamentsList[2].Length}");

        btnItem = new Button[OrnaList.Length];
        txtItem = new Text[OrnaList.Length];
        imgItem = new Image[OrnaList.Length];
        imgGetItem = new Image[OrnaList.Length];

        for (int i = 0; i < OrnaList.Length; i++)
        {
            btnItem[i] = GetComponentsInChildren<Button>()[i];
            txtItem[i] = GetComponentsInChildren<Text>()[i];
            imgItem[i] = btnItem[i].GetComponentsInChildren<Image>()[2];
            imgGetItem[i] = btnItem[i].GetComponentsInChildren<Image>()[3];
            //��������Ʈ ������ ��� UI
        }

        SetOrnaList(0);

        for (int i = 0; i < btnRoom.Length; i++)
        {
            int idx = i;
            btnRoom[i].onClick.AddListener(() => { SetOrnaList(idx); });
        }

        btnToList.onClick.AddListener(ToList);
        btnTestCoin.onClick.AddListener(GetCoin);
    }

    public void SetOrnaList(int idx)
    {
        ornamentManager.SetOrnaList(idx);
        var OrnaList = ornamentManager.GetOrnaList();

        for (int i = 0; i < 7; i++)
        {
            btnItem[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < OrnaList.Length; i++)
        {
            int index = i;
            btnItem[i].gameObject.SetActive(true);
            imgItem[i].sprite = Resources.Load<Sprite>($"OrnaUI/{OrnaList[i].prefabName}");
            txtItem[i].text = $"{OrnaList[i].ornamentName}";
            btnItem[index].onClick.RemoveAllListeners();
            btnItem[index].onClick.AddListener(() => { OpenItemProfile(index); });

            SetGetUI(i);
        }
    }

    public void SetGetUI(int i)
    {
        var OrnaList = ornamentManager.GetOrnaList();
        if (OrnaList[i].getOrnament)
            imgGetItem[i].gameObject.SetActive(true);
        else
            imgGetItem[i].gameObject.SetActive(false);
    }

    public void OpenItemProfile(int num)
    {
        RoomGroup.SetActive(false);
        UIItem.SetActive(true);
        SetItemProfile(num);
        Debug.Log($"{num}�� ������ ������ ����");
    }

    public void SetItemProfile(int num)
    {
        var OrnaList = ornamentManager.GetOrnaList();
        imgItemProfile.sprite = Resources.Load<Sprite>($"OrnaUI/{OrnaList[num].prefabName}");
        txtItemProfile.text = $"{OrnaList[num].ornamentName}";
        txtPrice.text = $"{OrnaList[num].price}";
        txtAbout.text = $"���� ����!! made by �ֺ�";

        Debug.Log($"{num}�� ���� ����? {OrnaList[num].getOrnament}");

        if (OrnaList[num].getOrnament)
        {
            btnBuy.gameObject.GetComponentInChildren<Text>().text = $"���� �Ϸ�";
            btnBuy.onClick.RemoveAllListeners();
        }
        else
        {
            btnBuy.gameObject.GetComponentInChildren<Text>().text = $"Buy";
            btnBuy.onClick.AddListener(() => { BuyItem(num); });
        }
    }

    public void BuyItem(int num)
    {
        var OrnaList = ornamentManager.GetOrnaList();

        if ((int)GameManager.GetInstance().curCoin >= OrnaList[num].price)
        {
            Debug.Log($"[{OrnaList[num].ornamentName}] �������� �����Ͽ����ϴ�");

            GameManager.GetInstance().curCoin -= OrnaList[num].price;
            Debug.Log($"���� {OrnaList[num].price} ���� | ���� ����: {GameManager.GetInstance().curCoin}����");
            txtCoin.text = $"x {(int)GameManager.GetInstance().curCoin}";

            btnBuy.gameObject.GetComponentInChildren<Text>().text = $"���� �Ϸ�";
            OrnaList[num].getOrnament = true;
            imgGetItem[num].gameObject.SetActive(true);
            btnBuy.onClick.RemoveAllListeners();
        }
        else
        {
            Debug.Log($"������ �����մϴ�!!!");
            imgGuide.SetActive(true);
            Invoke("CloseGuide", 0.7f);
        }


    }
    public void CloseGuide()
    {
        imgGuide.SetActive(false);
    }

    public void ToList()
    {
        UIItem.SetActive(false);
        RoomGroup.SetActive(true);
    }
}
