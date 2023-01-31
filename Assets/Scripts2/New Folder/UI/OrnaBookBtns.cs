using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class OrnaBookBtns : MonoBehaviour
{
    [SerializeField] private GameObject ornaBookBtns;

    [SerializeField] private Button btnOrnaList;

    [SerializeField] private Button btnOrnaList2;

    [SerializeField] private GameObject ornaAllList;

    [SerializeField] private Button Close;

    private GameObject ornaRoom;

    private GameObject OrnaInfoUI;

    public Button[] ornaBookBtn;

    private Text[] txtBtnOrnaName;

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
       




        Close.onClick.AddListener(CloseOrnaList); // 도감 닫기 버튼클릭

        // for (int i = 0; i < ornaBookBtn.Length; i++) // 도감 가구 설명열기 버튼클릭
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
        OrnaBookBtn();

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
        OrnaInfoUI.GetComponent<OrnaInfoUI>().LoadOrnaInfo(bookBtnsidx);
    }


    
    public void OpenOrnaList() // 도감 열기
    {
        
        ornaAllList.gameObject.SetActive(true);

        // for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
        // {
        //     ornaBookBtn[j].gameObject.SetActive(true);
        //     txtBtnOrnaName[j].text = OrnamentManager.GetInstance()._ornamentsList[i][j].ornamentName;
        // }
    }

    public void CloseOrnaList() // 도감 닫기
    {
        ornaAllList.gameObject.SetActive(false);
    }
    
    public void OrnaBookBtn()
    {    // 가구 리스트 버튼 배열 / 룸에 따라 배열 갱신
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
                    ornaBookBtn[j].gameObject.SetActive(true);
                    txtBtnOrnaName[j].text = OrnamentManager.GetInstance()._ornamentsList[i][j].ornamentName;
                }
            }
        }

    }
}
