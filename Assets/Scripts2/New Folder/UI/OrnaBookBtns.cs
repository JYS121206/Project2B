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
        ornaAllList.gameObject.SetActive(false);

        btnOrnaList.onClick.AddListener(OpenOrnaList);

        btnOrnaList2.onClick.AddListener(OpenOrnaList);

        ornaBookBtn = new Button[OrnamentManager.GetInstance()._ornamentsList[0].Length];
        txtBtnOrnaName = new Text[OrnamentManager.GetInstance()._ornamentsList[0].Length];

        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList[0].Length; i++)
        {
            ornaBookBtn[i] = ornaBookBtns.GetComponentsInChildren<Button>()[i];
            txtBtnOrnaName[i] = ornaBookBtns.GetComponentsInChildren<Text>()[i];
        }
    }
    private void Start()
    {
        

        Close.onClick.AddListener(CloseOrnaList);

        for (int i = 0; i < ornaBookBtn.Length; i++) 
        {
            int bookBtnsidx = i;

            ornaBookBtn[bookBtnsidx].onClick.AddListener(() =>
            {
                OpenOrnaInfo(bookBtnsidx);
            });
        }
    }

    void DeBugLog()
    {
        Debug.Log("유수종 나 버리고 카페간거 각오해 이 수모 백배로 돌려준다!");
    }
    public void OpenOrnaInfo(int bookBtnsidx)
    {
        //OrnamentManager.GetInstance().SetOrnaList(bookBtnsidx);
        OrnaInfoUI.GetComponent<OrnaInfoUI>().LoadOrnaInfo(bookBtnsidx);
    }

    public void OpenOrnaList()
    {
        ornaAllList.gameObject.SetActive(true);
        for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[0].Length; j++)
        {
            txtBtnOrnaName[j].text = OrnamentManager.GetInstance()._ornamentsList[0][j].ornamentName;
        }
    }

    public void CloseOrnaList()
    {
        ornaAllList.gameObject.SetActive(false);
    }
}
