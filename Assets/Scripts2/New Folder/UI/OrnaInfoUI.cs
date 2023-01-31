using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrnaInfoUI : MonoBehaviour
{
    [SerializeField] private Text txtOrnasName;

    [SerializeField] private GameObject gObjOrnaInfo;

    [SerializeField] private GameObject pick;

    [SerializeField] private Image ornaImage;

    [SerializeField] private GameObject ornaUIfrofile;

    [SerializeField] private GameObject ornaUIList;

    [SerializeField] private Button listClose;

    public GameObject ornaRoom;

    private Button[] btnOrnaPick;

    private GameObject ornaObjs;
    

    //int ornaidx;


    //Ornament[] _ornaList;

    private void Awake()
    {
        ornaRoom = GameObject.FindGameObjectWithTag("OrnaRoom");
        btnOrnaPick = new Button[OrnamentManager.GetInstance()._ornamentsList[0].Length]; // �ȹ�ư �迭
       
        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList[0].Length; i++)
        {
            btnOrnaPick[i] = pick.GetComponentsInChildren<Button>()[i];  // �ȹ�ư �迭
        }

        for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[0].Length; j++)
        {
            btnOrnaPick[j].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[0][j].pick); // �ȹ�ư Ȱ��ȭ
        }
    }
    private void Start()
    {
        listClose.onClick.AddListener(CloseOrnaInfo); // ���� ���� ����Ʈ �ݱ�

        for (int i = 0; i < btnOrnaPick.Length; i++)
        {
            int btnOrnaPickidx = i;
            btnOrnaPick[btnOrnaPickidx].onClick.AddListener(() =>
            {
                OpenOrnaObj(btnOrnaPickidx);
            });
        }
    }

    public void LoadOrnaInfo(int ornaidx) // ���� ���� ����â ����
    {
        ornaUIfrofile.gameObject.SetActive(true);
        ornaUIList.gameObject.SetActive(false);
        txtOrnasName.text = OrnamentManager.GetInstance()._ornamentsList[0][ornaidx].ornamentName;
        ornaImage.gameObject.SetActive(true);
        ornaImage.sprite = Resources.Load<Sprite>($"YSJ/{OrnamentManager.GetInstance()._ornamentsList[0][ornaidx].prefabName}");  // �̹��� �ε�
        btnOrnaPick[ornaidx].gameObject.SetActive(true);
       
    }

    public void CloseOrnaInfo() // 
    {
        // gObjOrnaInfo.gameObject.SetActive(false);
        for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[0].Length; j++)
        {
            ornaImage.gameObject.SetActive(false);
            btnOrnaPick[j].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[0][j].pick);
        }
        for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[0].Length; j++)
        {
            btnOrnaPick[j].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[0][j].pick);
        }

        ornaUIfrofile.gameObject.SetActive(false);
        ornaUIList.gameObject.SetActive(true);
    }

    public void OpenOrnaObj(int ornaPickidx)
    {
        ornaObjs.GetComponent<OrnaRoomObj>().LoadOrnaObj(ornaPickidx);
    }
    
}
