using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    UIMainMenu uIMainMenu;
    OrnamentObjManager ornamentObjManager;

    private int idx;
    public void Start()
    {
        Debug.Log(OrnamentObjManager.GetInstance()._ornamentActivePickList.Count);
        GetOrnament();
        OrnamentUIManager.GetInstance().goMain.onClick.AddListener(GoMain);
        OrnamentUIManager.GetInstance().goMain.onClick.AddListener(GoMain);
        //uIMainMenu.btnGoYSJ.onClick.AddListener(GoOrnamentBook);
        for (int i = 0; i <= OrnamentObjManager.GetInstance()._ornamentList.Count - 1; i++)
        {
            idx = i;
            OrnamentUIManager.GetInstance()._ornamentBtnList[idx].onClick.AddListener(OrnamentInfoOpen);
            OrnamentUIManager.GetInstance()._ornamentInfoCloseBtnList[idx].onClick.AddListener(OrnamentInfoClose);
            OrnamentUIManager.GetInstance()._ornamentInfoPickBtnList[idx].onClick.AddListener(OrnamentInfoPick);
        }



    }

    public void GoOrnamentBook()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.YSJ);
    }
    public void GoMain()
    {

        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }

    public void GetOrnament()
    {
        for (int i = 0; i <= OrnamentObjManager.GetInstance()._ornamentList.Count - 1; i++)
            if (OrnamentObjManager.GetInstance()._ornamentList[i].gameObject.activeSelf == true)
            {
                OrnamentUIManager.GetInstance()._ornamentBtnList[i].gameObject.SetActive(true);
            }
    }
    public void OrnamentInfoOpen()
    {
        OrnamentUIManager.GetInstance()._ornamentInfoList[idx].gameObject.SetActive(true);
    }

    public void OrnamentInfoClose()
    {
        OrnamentUIManager.GetInstance()._ornamentInfoList[idx].gameObject.SetActive(false);
    }

    public void OrnamentInfoPick()
    {
        OrnamentObjManager.GetInstance()._ornamentActivePickList[idx].gameObject.SetActive(true);
    }

    
}
