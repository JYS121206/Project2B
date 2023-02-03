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
        listClose.onClick.AddListener(CloseOrnaInfo); // ���� ���� ����Ʈ �ݱ�

        
    }

    public void SetRoomData()  // �� ������ ����
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

    public void LoadOrnaInfo(int ornaidx) // ���� ���� ����â ����
    {
        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
        {
            if (ornaRoom.GetComponent<OrnaRoom>().room[i].activeSelf == true)
            {
                ornaUIfrofile.gameObject.SetActive(true);
                ornaUIList.gameObject.SetActive(false);
                txtOrnasName.text = OrnamentManager.GetInstance()._ornamentsList[i][ornaidx].ornamentName;
                ornaImage.gameObject.SetActive(true);
                ornaImage.sprite = Resources.Load<Sprite>($"OrnaUI/{OrnamentManager.GetInstance()._ornamentsList[i][ornaidx].prefabName}");  // �̹��� �ε�
                btnOrnaPick[ornaidx].gameObject.SetActive(true);

                
                txtAbout2.text = $"{OrnamentManager.GetInstance()._ornamentsList[i][ornaidx].ornamentName} ��! ���� ����!! made by �ֺ�";
                
                //ornaRoomObjs.GetComponent<OrnaRoomObj>().LoadOrnaObj(ornaidx);
            }
        }
    }

    public void CloseOrnaInfo() // ���� ������ ��ư ����Ʈ��
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
