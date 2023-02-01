using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrnaBookBtns : MonoBehaviour
{
    [SerializeField] private GameObject ornaBookBtns;

    [SerializeField] private Button btnOrnaList;

    [SerializeField] private Button btnOrnaList2;

    [SerializeField] private GameObject ornaAllList;

    [SerializeField] private Button Close;

    [SerializeField] private GameObject ornaRoomObj;

    private GameObject ornaRoom;

    private GameObject OrnaInfoUI;

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
        btnOrnaList2.onClick.AddListener(OpenOrnaList);

        

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

        OrnaBookBtn();
        // for (int i = 0; i < ornaBookBtn.Length; i++) // ���� ���� ������ ��ưŬ��
        // {
        //     int bookBtnsidx = i;
        // 
        //     ornaBookBtn[bookBtnsidx].onClick.AddListener(() =>
        //     {
        //         OpenOrnaInfo(bookBtnsidx);
        //     });
        // }
    }




    private void Update()
    {
        if (isInit == false)
            return;

        OrnaBookBtn();

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
        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++) 
        {
            if (ornaRoom.GetComponent<OrnaRoom>().room[i].activeSelf == true)
            {
                //ornaBookBtn[OrnamentManager.GetInstance()._ornamentsList[i].Length].gameObject.SetActive(true);
                ornaBookBtn = new Button[OrnamentManager.GetInstance()._ornamentsList[i].Length];
                txtBtnOrnaName = new Text[OrnamentManager.GetInstance()._ornamentsList[i].Length];
                
       
                for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
                {
                    if (j < OrnamentManager.GetInstance()._ornamentsList[i].Length)
                    {
                        //ornaBookBtn[j].gameObject.SetActive(true);
                        ornaBookBtn[j] = ornaBookBtns.GetComponentsInChildren<Button>()[j];
                        txtBtnOrnaName[j] = ornaBookBtns.GetComponentsInChildren<Text>()[j];
                    }
       
                    else
                        ornaBookBtn[j].gameObject.SetActive(false);
                }
            }
        }
         // 



        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
        {
            if (ornaRoom.GetComponent<OrnaRoom>().room[i].activeSelf == true)
            {
                for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
                {
                    int idx = j;

                    if (i == 0)
                    {
                        ornaBookBtn[j].gameObject.SetActive(true);
                        txtBtnOrnaName[j].text = OrnamentManager.GetInstance()._ornamentsList[i][j].ornamentName;
                        imgBtnOrnaImage[j].sprite = Resources.Load<Sprite>($"OrnaUI/{OrnamentManager.GetInstance()._ornamentsList[i][j].prefabName}");
                    }
                    else
                    {
                        imgBtnOrnaImage[j].sprite = Resources.Load<Sprite>($"Image/lock");
                        txtBtnOrnaName[j].text = $"???";
                        ornaBookBtn[j].onClick.AddListener(() => { Lock(idx); });
                    }

                    if (i == 1)
                    {
                        ornaBookBtn[j].gameObject.SetActive(true);
                        txtBtnOrnaName[j].text = OrnamentManager.GetInstance()._ornamentsList[i][j].ornamentName;
                        imgBtnOrnaImage[j].sprite = Resources.Load<Sprite>($"OrnaUI/{OrnamentManager.GetInstance()._ornamentsList[i][j].prefabName}");
                    }
                    else
                    {
                        imgBtnOrnaImage[j].sprite = Resources.Load<Sprite>($"Image/lock");
                        txtBtnOrnaName[j].text = $"???";
                        ornaBookBtn[j].onClick.AddListener(() => { Lock(idx); });
                    }

                    if (i == 2)
                    {
                        ornaBookBtn[j].gameObject.SetActive(true);
                        txtBtnOrnaName[j].text = OrnamentManager.GetInstance()._ornamentsList[i][j].ornamentName;
                        imgBtnOrnaImage[j].sprite = Resources.Load<Sprite>($"OrnaUI/{OrnamentManager.GetInstance()._ornamentsList[i][j].prefabName}");
                    }
                    else
                    { 
                        imgBtnOrnaImage[j].sprite = Resources.Load<Sprite>($"Image/lock");
                        txtBtnOrnaName[j].text = $"???";
                        ornaBookBtn[j].onClick.AddListener(() => { Lock(idx); });
                    }
                }
            }
        }

    }


    public void Lock(int num)
    {
        Debug.Log($"ĳ���� {num + 1}�� ������ ������ �� �����ϴ�");
    }
}
