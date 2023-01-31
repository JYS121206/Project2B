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

    private GameObject OrnaInfoUI;

    public Button[] ornaBookBtn;

    private Text[] txtBtnOrnaName;

    private void Awake()
    {
        OrnaInfoUI = GameObject.FindGameObjectWithTag("OrnaInfoUI");

        ornaAllList.gameObject.SetActive(false);

        btnOrnaList.onClick.AddListener(OpenOrnaList);
        btnOrnaList2.onClick.AddListener(OpenOrnaList);

        ornaBookBtn = new Button[OrnamentManager.GetInstance()._ornamentsList[0].Length];
        txtBtnOrnaName = new Text[OrnamentManager.GetInstance()._ornamentsList[0].Length];

    }
    private void Start()
    {


        for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[0].Length; j++)
        {
            ornaBookBtn[j] = ornaBookBtns.GetComponentsInChildren<Button>()[j];
            txtBtnOrnaName[j] = ornaBookBtns.GetComponentsInChildren<Text>()[j];
        }

        Close.onClick.AddListener(CloseOrnaList); // ���� �ݱ� ��ưŬ��

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
        
        for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[0].Length; j++)
        {
            ornaBookBtn[j].gameObject.SetActive(true);
            txtBtnOrnaName[j].text = OrnamentManager.GetInstance()._ornamentsList[0][j].ornamentName;
        }
    }

    public void CloseOrnaList() // ���� �ݱ�
    {
        ornaAllList.gameObject.SetActive(false);
    }
}
