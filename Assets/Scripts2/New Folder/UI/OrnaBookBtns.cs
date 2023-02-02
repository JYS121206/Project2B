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

    private GameObject OrnaInfoUI;

    public Image[] lockImage;

    public Button[] lockBtn;

    public Button[] ornaBookBtn;

    private Text[] txtBtnOrnaName;

    [SerializeField] private Image[] imgBtnOrnaImage;

    bool isInit = false;

    private void Awake()
    {
        OrnaInfoUI = GameObject.FindGameObjectWithTag("OrnaInfoUI");
        ornaRoom = GameObject.FindGameObjectWithTag("OrnaRoom");
        
        ornaAllList.gameObject.SetActive(false);

        btnOrnaList.onClick.AddListener(OpenOrnaList);
        


        lockBtn = new Button[OrnamentManager.GetInstance()._ornamentsList[0].Length];

        for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[0].Length; j++)
        {
            lockBtn[j] = lockImages.GetComponentsInChildren<Button>()[j];
        }
        // for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
        // {
        //     if (ornaRoom.GetComponent<OrnaRoom>().room[i].activeSelf == true)
        //     {
        //         ornaBookBtn = new Button[OrnamentManager.GetInstance()._ornamentsList[i].Length];
        //         txtBtnOrnaName = new Text[OrnamentManager.GetInstance()._ornamentsList[i].Length];
        //         for (int k = 0; k < OrnamentManager.GetInstance()._ornamentsList[i].Length; k++)
        //         {
        // 
        //             ornaBookBtn[k].gameObject.SetActive(true);
        //         }
        //     }
        // }
        // ornaBookBtn = new Button[OrnamentManager.GetInstance()._ornamentsList[0].Length];
        // txtBtnOrnaName = new Text[OrnamentManager.GetInstance()._ornamentsList[0].Length];
        // 
        // for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[0].Length; j++)
        // {
        //     ornaBookBtn[j] = ornaBookBtns.GetComponentsInChildren<Button>()[j];
        //     txtBtnOrnaName[j] = ornaBookBtns.GetComponentsInChildren<Text>()[j];
        // }
    }
    private void Start()
    {
        Close.onClick.AddListener(CloseOrnaList); // ���� �ݱ� ��ưŬ��

        


        // for (int i = 0; i < ornaBookBtn.Length; i++) // ���� ���� ������ ��ưŬ��
        // {
        //     int bookBtnsidx = i;
        // 
        //     ornaBookBtn[bookBtnsidx].onClick.AddListener(() =>
        //     {
        //         OpenOrnaInfo(bookBtnsidx);
        //     });
        // }

        // OrnaListSet();

        //OrnaBookBtn();
    }




    private void Update()
    {
        if (isInit == false)
            return;

        
        OrnaBookBtn();
        SetOrnamentList();

    }


    public void SetOrnamentList()
    {
        for (int i = 0; i < ornaBookBtn.Length; i++) // ���� ���� ������ ��ưŬ��
        {
            int bookBtnsidx = i;

            ornaBookBtn[bookBtnsidx].onClick.AddListener(() =>
            {
                OpenOrnaInfo(bookBtnsidx);
            });
        }
    }
    public void OpenOrnaInfo(int bookBtnsidx) // ���� ���� ������
    {
        //OrnamentManager.GetInstance().SetOrnaList(bookBtnsidx);
        OrnaInfoUI.GetComponent<OrnaInfoUI>().LoadOrnaInfo(bookBtnsidx);
    }



    
    public void OpenOrnaList() // ���� ����
    {
        
        ornaAllList.gameObject.SetActive(true);

        OrnaInfoUI.GetComponent<OrnaInfoUI>().SetRoomData();
        isInit = true;
        // for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
        // {
        //     ornaBookBtn[j].gameObject.SetActive(true);
        //     txtBtnOrnaName[j].text = OrnamentManager.GetInstance()._ornamentsList[i][j].ornamentName;
        // }
    }




    public void CloseOrnaList() // ���� �ݱ�
    {
        ornaAllList.gameObject.SetActive(false);
    }
    



    public void OrnaBookBtn()
    {    // ���� ����Ʈ ��ư �迭 / �뿡 ���� �迭 ����
        //for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList[0].Length; i++)
        //{
        //    
        //
        //}
        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
        {
            if (ornaRoom.GetComponent<OrnaRoom>().room[i].activeSelf == true)
            {
                
                

                ornaBookBtn = new Button[OrnamentManager.GetInstance()._ornamentsList[i].Length];
                txtBtnOrnaName = new Text[OrnamentManager.GetInstance()._ornamentsList[i].Length];

               


                    for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
                {
                    
                    //ornaBookBtn[j].gameObject.SetActive(true);
                    ornaBookBtn[j] = ornaBookBtns.GetComponentsInChildren<Button>()[j];
                    txtBtnOrnaName[j] = ornaBookBtns.GetComponentsInChildren<Text>()[j];
                    
                    lockImage[j].sprite = Resources.Load<Sprite>($"Image/lock");
                }

                // for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
                // {
                //     lockImage[j].sprite = Resources.Load<Sprite>($"Image/lock");
                //     //ornaBookBtn[j].gameObject.SetActive(false);
                // }
            }
        }



        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
        {

            

            if (ornaRoom.GetComponent<OrnaRoom>().room[i].activeSelf == true)
            {
                for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
                {

                    if (i == 0)
                    {
                        if (OrnamentManager.GetInstance()._ornamentsList[i][j].getOrnament == true)
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


                    else if (i == 1)
                    {
                        if (OrnamentManager.GetInstance()._ornamentsList[i][j].getOrnament == true)
                        {
                            txtBtnOrnaName[j].text = OrnamentManager.GetInstance()._ornamentsList[i][j].ornamentName;
                            imgBtnOrnaImage[j].sprite = Resources.Load<Sprite>($"OrnaUI/{OrnamentManager.GetInstance()._ornamentsList[i][j].prefabName}");
                            //lockImage[j].gameObject.SetActive(false);
                            lockBtn[j].gameObject.SetActive(false);
                        }
                        else if(OrnamentManager.GetInstance()._ornamentsList[i][j].getOrnament == false)
                        {
                            txtBtnOrnaName[j].text = xxx;
                            //imgBtnOrnaImage[j].sprite = Resources.Load<Sprite>($"OrnaUI/{OrnamentManager.GetInstance()._ornamentsList[i][j].prefabName}");
                            lockBtn[j].gameObject.SetActive(true);
                        }

                    }

                    if (i == 2)
                    {
                        if (OrnamentManager.GetInstance()._ornamentsList[i][j].getOrnament == true)
                        {
                            txtBtnOrnaName[j].text = OrnamentManager.GetInstance()._ornamentsList[i][j].ornamentName;
                            imgBtnOrnaImage[j].sprite = Resources.Load<Sprite>($"OrnaUI/{OrnamentManager.GetInstance()._ornamentsList[i][j].prefabName}");
                            //lockImage[j].gameObject.SetActive(false);
                            lockBtn[j].gameObject.SetActive(false);
                        }
                        else if(OrnamentManager.GetInstance()._ornamentsList[i][j].getOrnament == false)
                        {
                            txtBtnOrnaName[j].text = xxx;
                            //imgBtnOrnaImage[j].sprite = Resources.Load<Sprite>($"OrnaUI/{OrnamentManager.GetInstance()._ornamentsList[i][j].prefabName}");
                            lockBtn[j].gameObject.SetActive(true);
                        }

                    }

                }
            }
        }




    }



    // public void OrnaActive(int num)
    // {
    //     for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
    //     {
    //         if (ornaRoom.GetComponent<OrnaRoom>().room[i].activeSelf == true)
    //         {
    // 
    // 
    //             
    //             lockImage[num].gameObject.SetActive(false);
    //             
    //             txtBtnOrnaName[num].text = OrnamentManager.GetInstance()._ornamentsList[i][num].ornamentName;
    //             imgBtnOrnaImage[num].sprite = Resources.Load<Sprite>($"OrnaUI/{OrnamentManager.GetInstance()._ornamentsList[i][num].prefabName}");
    // 
    //             
    //             
    //         }
    //     }
    // }

    public void Lock(int num)
    {
        Debug.Log($"ĳ���� {num + 1}�� ������ ������ �� �����ϴ�");
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

    public void OrnaListSet()
    {
       
    }
}

