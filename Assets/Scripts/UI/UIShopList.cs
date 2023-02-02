using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIShopList : MonoBehaviour
{
    public GameObject RoomGroup;  //아이템 목록
    public GameObject UIItem;     //세부 프로필

    public Button[] btnRoom = new Button[3];
                                  //방 선택

    public Button[] btnItem;      // 아이템 버튼
    public Text[] txtItem;        //아이템 이름
    public Image[] imgItem;       //아이템 이미지
    public Image[] imgGetItem;    //구매한 아이템 표시 이미지

    public Image imgItemProfile;  //아이템 세부 이미지
    public Text txtItemProfile;   //아이템 세부 이름
    public Text txtPrice;         //아이템 세부 가격
    public Text txtAbout;         //아이템 세부 설명

    public Button btnBuy;         //아이템 구매
    public Button btnToList;      //목록으로 돌아가기

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

        Debug.Log($"배열크기: {OrnaList.Length}");
        Debug.Log($"가구이름: {OrnaList[1].ornamentName}");
        //Debug.Log($"배열크기: {ornamentManager._ornamentsList[1].Length}");
        //Debug.Log($"배열크기: {ornamentManager._ornamentsList[2].Length}");

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
            //겟컴포넌트 아이템 목록 UI
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
        Debug.Log($"{num}의 아이템 프로필 열람");
    }

    public void SetItemProfile(int num)
    {
        var OrnaList = ornamentManager.GetOrnaList();
        imgItemProfile.sprite = Resources.Load<Sprite>($"OrnaUI/{OrnaList[num].prefabName}");
        txtItemProfile.text = $"{OrnaList[num].ornamentName}";
        txtPrice.text = $"{OrnaList[num].price}";
        txtAbout.text = $"멋진 가구!! made by 솔빈";

        Debug.Log($"{num}이 가구 있음? {OrnaList[num].getOrnament}");

        if (OrnaList[num].getOrnament)
        {
            btnBuy.gameObject.GetComponentInChildren<Text>().text = $"구매 완료";
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
            Debug.Log($"[{OrnaList[num].ornamentName}] 아이템을 구매하였습니다");

            GameManager.GetInstance().curCoin -= OrnaList[num].price;
            Debug.Log($"코인 {OrnaList[num].price} 차감 | 남은 코인: {GameManager.GetInstance().curCoin}코인");
            txtCoin.text = $"x {(int)GameManager.GetInstance().curCoin}";

            btnBuy.gameObject.GetComponentInChildren<Text>().text = $"구매 완료";
            OrnaList[num].getOrnament = true;
            imgGetItem[num].gameObject.SetActive(true);
            btnBuy.onClick.RemoveAllListeners();
        }
        else
        {
            Debug.Log($"코인이 부족합니다!!!");
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
