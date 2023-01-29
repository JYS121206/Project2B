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
    public GameObject getRabbitMode;
    public GameObject setRabbitMode;

    bool camMode;

    void Start()
    {
        camMode = true;
        btnPrintSc.gameObject.SetActive(false);
        ListGroup.SetActive(false);
        btnOpenList.gameObject.SetActive(false);
        setRabbitMode.SetActive(false);

        btnChangeMode.onClick.AddListener(ChangeMode);
        btnOpenList.onClick.AddListener(OpenList);
        btnCloseList.onClick.AddListener(CloseList);

        btnPreScene.onClick.AddListener(() => { ScenesManager.GetInstance().ChangeScene(Scene.Main); });

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
            btnOpenList.gameObject.SetActive(false);
            camMode = false;

        }
        else
        {
            btnPrintSc.gameObject.SetActive(true);
            ListGroup.SetActive(false);
            btnOpenList.gameObject.SetActive(true);
            camMode = true;
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
