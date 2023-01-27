using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GetRabbitMode : MonoBehaviour
{
    public GameObject UIPopRUGet;
    public GameObject UIPopGetRB;

    public Button btnGet;
    public Button btnPass;
    public Button btnCloseRUGet;

    public Button btnConfirm;
    public Button btnContinue;
    public Button btnCloseGetRB;

    public List<GameObject> rabbitList = new List<GameObject>();
    GameObject curRabbit;
    GameObject target;

    void Start()
    {
        
    }

    void Update()
    {
        GetRabbit();
    }

    public void GetRabbit()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            //UI�� ������Ʈ Ŭ�� ���ϰ� �ϱ�
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            else
            {
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.transform.gameObject);
                    target = hit.transform.gameObject;
                    UIPopRUGet.SetActive(true);
                }
            }
        }
    }

    public void CloseRUGet()
    {
        UIPopRUGet.SetActive(false);

        Destroy(target, 1f);
    }

    public void OpenGetRB()
    {
        UIPopRUGet.SetActive(false);
        UIPopGetRB.SetActive(true);
    }

    public void CloseGetRB()
    {
        UIPopGetRB.SetActive(false);
        Destroy(target);
    }

    public void SpawnRabbit()
    {
        int rabbitIdx = Random.Range(0, rabbitList.Count);

        //Instantiate ������ü ,            ��ġ�� ,               ȸ����
        curRabbit = Instantiate(rabbitList[rabbitIdx], new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
