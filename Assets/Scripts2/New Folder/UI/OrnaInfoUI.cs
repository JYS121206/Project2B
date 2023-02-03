using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrnaInfoUI : MonoBehaviour
{
    [SerializeField] private Text txtOrnasName;

    //[SerializeField] private GameObject gObjOrnaInfo;

    [SerializeField] private GameObject pick;

    [SerializeField] private Image ornaImage;

    public GameObject ornaUIfrofile;

    public GameObject ornaUIList;

    [SerializeField] private Button listClose;

    private GameObject ornaRoom;

    public Button[] btnOrnaPick;

    [SerializeField] private GameObject ornaRoomObjs;

    OrnaBookBtns ornaBookBtns;

    public Text txtAbout2;

    bool isInit = false;


    private void Awake()
    {
        ornaRoom = GameObject.FindGameObjectWithTag("OrnaRoom");
        

        
    }
    private void Start()
    {
        listClose.onClick.AddListener(CloseOrnaInfo); // 가구 설명 리스트 닫기

        
    }

    public void SetRoomData()  // 룸 데이터 세팅
    {
        if (isInit)
            return;
        
        var btns = pick.GetComponentsInChildren<Button>();
        btnOrnaPick = new Button[btns.Length];

        for (int i = 0; i < btns.Length; i++)
        {
            btnOrnaPick[i] = btns[i];
            btnOrnaPick[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < btnOrnaPick.Length; i++)
        {
            int btnOrnaPickidx = i;
            btnOrnaPick[btnOrnaPickidx].onClick.AddListener(() =>
            {
                OpenOrnaObj(btnOrnaPickidx);
            });
        }

        isInit = true;

    }

    public void LoadOrnaInfo(int ornaidx) // 도감 가구 설명창 열림
    {
        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
        {
            if (ornaRoom.GetComponent<OrnaRoom>().room[i].activeSelf == true)
            {
                ornaUIfrofile.gameObject.SetActive(true);
                ornaUIList.gameObject.SetActive(false);
                txtOrnasName.text = OrnamentManager.GetInstance()._ornamentsList[i][ornaidx].ornamentName;
                ornaImage.gameObject.SetActive(true);
                ornaImage.sprite = Resources.Load<Sprite>($"OrnaUI/{OrnamentManager.GetInstance()._ornamentsList[i][ornaidx].prefabName}");  // 이미지 로드
                btnOrnaPick[ornaidx].gameObject.SetActive(true);

                
                txtAbout2.text = $"{OrnamentManager.GetInstance()._ornamentsList[i][ornaidx].ornamentName} 겟! 멋진 가구!! made by 솔빈";
                
                //ornaRoomObjs.GetComponent<OrnaRoomObj>().LoadOrnaObj(ornaidx);
            }
        }
    }

    public void CloseOrnaInfo() // 도감 설명에서 버튼 리스트로
    {
        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
            if (ornaRoom.GetComponent<OrnaRoom>().room[i].activeSelf == true)
            {
                for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
                {
                    ornaImage.gameObject.SetActive(false);
                    btnOrnaPick[j].gameObject.SetActive(false);

                }
                // for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
                // {
                //     btnOrnaPick[j].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[i][j].pick);
                // }
            }
        ornaUIfrofile.gameObject.SetActive(false);
        ornaUIList.gameObject.SetActive(true);
    }

    public void OpenOrnaObj(int ornaPickidx)
    {
        ornaRoomObjs.GetComponent<OrnaRoomObj>().LoadOrnaObj(ornaPickidx);
    }
    

    
}
