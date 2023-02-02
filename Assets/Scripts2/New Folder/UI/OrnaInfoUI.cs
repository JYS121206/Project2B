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

    [SerializeField] private GameObject ornaUIfrofile;

    [SerializeField] private GameObject ornaUIList;

    [SerializeField] private Button listClose;

    private GameObject ornaRoom;

    private Button[] btnOrnaPick;

    [SerializeField] private GameObject ornaRoomObjs;


    bool isInit = false;

    //int ornaidx;


    //Ornament[] _ornaList;

    private void Awake()
    {
        ornaRoom = GameObject.FindGameObjectWithTag("OrnaRoom");
        

        
    }
    private void Start()
    {
        listClose.onClick.AddListener(CloseOrnaInfo); // 가구 설명 리스트 닫기
    }

    public void SetRoomData()
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

        //for (int k = 0; k < OrnamentManager.GetInstance()._ornamentsList.Count; k++)
        //{
        //    if (ornaRoom.GetComponent<OrnaRoom>().room[k].activeSelf == true)
        //    {
        //        btnOrnaPick = new Button[OrnamentManager.GetInstance()._ornamentsList[k].Length];  // 픽버튼 배열
        //        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList[k].Length; i++)
        //        {
        //            var btns = pick.GetComponentsInChildren<Button>();
        //            btnOrnaPick[i] = btns[i];  // 픽버튼 배열
        //        }

        //        for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[k].Length; j++)
        //        {
        //            btnOrnaPick[j].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[0][j].pick); // 픽버튼 활성화
        //        }
        //    }
        //}
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

                ornaRoomObjs.GetComponent<OrnaRoomObj>().LoadOrnaObj(ornaidx);
            }
        }
    }

    public void CloseOrnaInfo() // 
    {
        // gObjOrnaInfo.gameObject.SetActive(false);
        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
            if (ornaRoom.GetComponent<OrnaRoom>().room[i].activeSelf == true)
            {
                for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
                {
                    ornaImage.gameObject.SetActive(false);
                    btnOrnaPick[j].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[i][j].pick);
                }
                for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
                {
                    btnOrnaPick[j].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[i][j].pick);
                }
                ornaUIfrofile.gameObject.SetActive(false);
                ornaUIList.gameObject.SetActive(true);
            }
        //ornaUIfrofile.gameObject.SetActive(false);
        //ornaUIList.gameObject.SetActive(true);
    }

    public void OpenOrnaObj(int ornaPickidx)
    {
        ornaRoomObjs.GetComponent<OrnaRoomObj>().LoadOrnaObj(ornaPickidx);
    }
    

    
}
