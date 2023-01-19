using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MR_TestScene : MonoBehaviour
{
    public GameObject UIPopRUGet;
    public GameObject UIPopGetRB;
    
    public GameObject cube;

    public Button btnGet;
    public Button btnPass;
    public Button btnCloseRUGet;

    public Button btnConfirm;
    public Button btnContinue;
    public Button btnCloseGetRB;


    void Start()
    {

    }

    void Update()
    {
        if (cube == null)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonUp(0))
        {
            //UI뒤 오브젝트 클릭 못하게 하기
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log(hit.transform.gameObject);
                        UIPopRUGet.SetActive(true);
                    }
                }
            }
        }
    }

    public void CloseRUGet()
    {
        UIPopRUGet.SetActive(false);
    }

    public void OpenGetRB()
    {
        UIPopRUGet.SetActive(false);
        UIPopGetRB.SetActive(true);
    }

    public void CloseGetRB()
    {
        UIPopGetRB.SetActive(false);
    }
}
