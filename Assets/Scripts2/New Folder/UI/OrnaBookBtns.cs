using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrnaBookBtns : MonoBehaviour
{

    private string xxx = "xxx";
    [SerializeField] private GameObject ornaBookBtns;

    [SerializeField] private Button btnOrnaList;

    [SerializeField] private GameObject ornaAllList;

    [SerializeField] private Button Close;

    // [SerializeField] private GameObject ornaRoomObj;

    [SerializeField] private GameObject lockImages;

    private GameObject ornaRoom;

    private GameObject ornaInfoUI;

    public Image[] lockImage;

    public Button[] lockBtn;

    public Button[] ornaBookBtn;

    private Text[] txtBtnOrnaName;

    [SerializeField] private Image[] imgBtnOrnaImage;

    bool isInit = false;


    private void Awake()
    {
        OrnaBookBtnSetting();
        
    }
    private void Start()
    {
        Close.onClick.AddListener(CloseOrnaList); // 도감 닫기 버튼클릭
    }




    private void Update()
    {
        if (isInit == false)
            return;

        OrnaBookBtn();
        SetOrnamentList();
        // ornaInfoUI.GetComponent<OrnaInfoUI>().SetRoomData();
    }


    public void SetOrnamentList()
    {
        for (int i = 0; i < ornaBookBtn.Length; i++) // 도감 가구 설명열기 버튼클릭
        {
            int bookBtnsidx = i;

            ornaBookBtn[bookBtnsidx].onClick.AddListener(() =>
            {
                OpenOrnaInfo(bookBtnsidx);
            });
        }
    }
    public void OpenOrnaInfo(int bookBtnsidx) // 도감 가구 설명열기
    {
        //OrnamentManager.GetInstance().SetOrnaList(bookBtnsidx);
        ornaInfoUI.GetComponent<OrnaInfoUI>().LoadOrnaInfo(bookBtnsidx);
    }



    
    public void OpenOrnaList() // 도감 열기
    {
        
        ornaAllList.gameObject.SetActive(true);
        OrnaBookBtn();
        ornaInfoUI.GetComponent<OrnaInfoUI>().SetRoomData();
        isInit = true;
    }




    public void CloseOrnaList() // 도감 닫기
    {
        ornaInfoUI.GetComponent<OrnaInfoUI>().CloseOrnaInfo();
        ornaAllList.gameObject.SetActive(false);
    }
    



    public void OrnaBookBtn()
    {    // 가구 리스트 버튼 배열 / 룸에 따라 배열 갱신

        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
        {
            if (ornaRoom.GetComponent<OrnaRoom>().room[i].activeSelf == true)
            {
                // for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
                // {
                //     ornaBookBtn[j].gameObject.SetActive(true);
                //     lockBtn[j].gameObject.SetActive(true);
                // }
                ornaBookBtn = new Button[OrnamentManager.GetInstance()._ornamentsList[i].Length];
                txtBtnOrnaName = new Text[OrnamentManager.GetInstance()._ornamentsList[i].Length];
                //lockBtn = new Button[OrnamentManager.GetInstance()._ornamentsList[0].Length];


                for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[0].Length; j++)
                {
                    lockBtn[j].gameObject.SetActive(true);
                    lockImage[j].sprite = Resources.Load<Sprite>($"Image/lock");
                }
                for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
                {
                    
                    ornaBookBtn[j] = ornaBookBtns.GetComponentsInChildren<Button>()[j];
                    txtBtnOrnaName[j] = ornaBookBtns.GetComponentsInChildren<Text>()[j];
                    //lockBtn[j] = lockImages.GetComponentsInChildren<Button>()[j];
                    
                    
                  
                }

                // for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
                // {
                //     ornaBookBtn[j].gameObject.SetActive(true);
                //     lockBtn[j].gameObject.SetActive(true);
                // }

            }
        }

        


        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
        {

            

            if (ornaRoom.GetComponent<OrnaRoom>().room[i].activeSelf == true)
            {
                for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
                {
                        if (OrnamentManager.GetInstance()._ornamentsList[i][j].getOrnament == true )
                        {
                            txtBtnOrnaName[j].text = OrnamentManager.GetInstance()._ornamentsList[i][j].ornamentName;
                            imgBtnOrnaImage[j].sprite = Resources.Load<Sprite>($"OrnaUI/{OrnamentManager.GetInstance()._ornamentsList[i][j].prefabName}");
                            //lockImage[j].gameObject.SetActive(false);
                            lockBtn[j].gameObject.SetActive(false);
                        }

                        else if (OrnamentManager.GetInstance()._ornamentsList[i][j].getOrnament == false)
                        {
                            txtBtnOrnaName[j].text = xxx;
                            //imgBtnOrnaImage[j].sprite = Resources.Load<Sprite>($"OrnaUI/{OrnamentManager.GetInstance()._ornamentsList[i][j].prefabName}");
                            lockBtn[j].gameObject.SetActive(true);
                        }
                }
            }
        }




    }

    public void OrnaBookBtnSetting()  // 시작전 가구 도감 버튼세팅
    {
        ornaInfoUI = GameObject.FindGameObjectWithTag("OrnaInfoUI");
        ornaRoom = GameObject.FindGameObjectWithTag("OrnaRoom");

        ornaBookBtn = new Button[OrnamentManager.GetInstance()._ornamentsList[0].Length];
        lockBtn = new Button[OrnamentManager.GetInstance()._ornamentsList[0].Length];

        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList[0].Length; i++)
        {
            // for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
            // {
            // 
            // }
            
            ornaBookBtn[i] = ornaBookBtns.GetComponentsInChildren<Button>()[i];
            lockBtn[i] = lockImages.GetComponentsInChildren<Button>()[i];
        }
       //  for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList[0].Length; i++)
       //  {
       //      ornaBookBtn[i].gameObject.SetActive(false);
       //      lockBtn[i].gameObject.SetActive(false);
       //  }

    // ornaInfoUI.GetComponent<OrnaInfoUI>().ornaUIfrofile.gameObject.SetActive(false); // 임시



    // for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[0].Length; j++)
    // {
    //     
    // }

        ornaAllList.gameObject.SetActive(false);

        btnOrnaList.onClick.AddListener(OpenOrnaList);
    }


    


    #region OrnaBtnsActive
    // public void OrnaBtnsActive()
    // {
    //     for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
    //     {
    //         for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
    //         {
    //             if (i == 0)
    //             {
    //                 if (OrnamentManager.GetInstance()._ornamentsList[i][j].getOrnament == true)
    //                 {
    //                     lockImage[j].gameObject.SetActive(false);
    // 
    //                 else { }
    //             }
    //             else if (i == 1)
    //             {
    //                 if (OrnamentManager.GetInstance()._ornamentsList[i][j].getOrnament == true)
    //                 {
    //                     lockImage[j].gameObject.SetActive(false);
    //                 }
    //                 else { }
    //             }
    //             else if (i == 2)
    //             {
    //                 if (OrnamentManager.GetInstance()._ornamentsList[i][j].getOrnament == true)
    //                 {
    //                     lockImage[j].gameObject.SetActive(false);
    //                 }
    //                 else { }
    //             }
    //         }
    //     }
    // }

    #endregion


}

