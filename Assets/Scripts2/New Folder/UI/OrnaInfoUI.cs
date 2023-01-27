using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrnaInfoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text[] txtOrnasName;

    [SerializeField] private GameObject[] gObjOrnaInfo;

    [SerializeField] private Button Close;

    [SerializeField] private Button[] btnOrnaPick;

    //[SerializeField] private TMP_Text[] txtOrnasInfo;

    int ornaidx;


    Ornament[] _ornaList;

    private void Awake()
    {
        txtOrnasName = new TMP_Text[OrnamentManager.GetInstance()._ornamentsList[0].Length-1];
        btnOrnaPick = new Button[OrnamentManager.GetInstance()._ornamentsList[0].Length-1];
        Debug.Log(OrnamentManager.GetInstance()._ornamentsList[0][1].ornamentName);
    }
    private void Start()
    {
        Close.onClick.AddListener(CloseOrnaInfo);
    }

    public void LaodOrnaInfo(int ornaidx)
    {
        txtOrnasName[ornaidx].text = OrnamentManager.GetInstance()._ornamentsList[0][ornaidx].ornamentName;
        gObjOrnaInfo[0].gameObject.SetActive(true);
    }

    public void CloseOrnaInfo()
    {
        gObjOrnaInfo[0].gameObject.SetActive(false);
    }



}
