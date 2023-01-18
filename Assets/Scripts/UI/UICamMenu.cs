using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICamMenu : MonoBehaviour
{
    public Button btnPreScene;
    public Button btnSet;
    public Button btnChangeMode;
    public Button btnPrintSc;

    public Button btnOpenList;
    public Button btnCloseList;
    public GameObject ListGroup;

    bool camMode;

    void Start()
    {
        camMode = true;
        btnPrintSc.gameObject.SetActive(false);
        ListGroup.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ChangeMode()
    {
        if (btnPrintSc == null && ListGroup == null)
            return;

        if (camMode)
        {
            btnPrintSc.gameObject.SetActive(false);
            ListGroup.SetActive(false);
            camMode = true;
        }
        else
        {
            btnPrintSc.gameObject.SetActive(true);
            ListGroup.SetActive(true);
            camMode = false;
        }
    }

    public void OpenList()
    {
        if (ListGroup == null)
            return;

        ListGroup.SetActive(true);
        btnOpenList.gameObject.SetActive(false);
    }

    /// <summary>
    /// Ä³¸¯ÅÍ ºÏ¸¶Å© UI ´Ý±â
    /// </summary>
    public void CloseList()
    {
        if (ListGroup == null)
            return;

        ListGroup.SetActive(false);
        btnOpenList.gameObject.SetActive(true);
    }
}
