using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    OrnamentObjManager ornamentObjManager;
    static int rand = 2; //Random.Range(0, OrnamentObjManager.GetInstance()._ornementList.Count);
    void Start()
    {
        //int rand = OrnamentObjManager.GetInstance()._ornamentList.Count;

        Debug.Log(OrnamentObjManager.GetInstance()._ornamentList.Count);

        if (OrnamentObjManager.GetInstance()._ornamentList[rand].gameObject.activeSelf == true)
        {
            //OrnamentManager.GetInstance()._ornament[rand].getOrnament = true;
            OrnamentUIManager.GetInstance()._ornamentBtnList[rand].gameObject.SetActive(true);
        }

        OrnamentUIManager.GetInstance()._ornamentBtnList[rand].onClick.AddListener(OrnamentInfoOpen);

        OrnamentUIManager.GetInstance()._ornamentInfoCloseBtnList[rand].onClick.AddListener(OrnamentInfoClose);

        OrnamentUIManager.GetInstance()._ornamentInfoPickBtnList[rand].onClick.AddListener(OrnamentInfoPick);
    }

    public void OrnamentInfoOpen()
    {
        OrnamentUIManager.GetInstance()._ornamentInfoList[rand].gameObject.SetActive(true);
    }

    public void OrnamentInfoClose()
    {
        OrnamentUIManager.GetInstance()._ornamentInfoList[rand].gameObject.SetActive(false);
    }

    public void OrnamentInfoPick()
    {
        OrnamentObjManager.GetInstance()._ornamentActivePickList[rand].gameObject.SetActive(true);
    }
}
