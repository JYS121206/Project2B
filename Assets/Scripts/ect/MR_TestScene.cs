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

    public List<GameObject> rabbitList = new List<GameObject>();

    GameObject curRabbit;
    GameObject target;

    CharacterManager1 characterManagerT;
    public UICharacterList1 UICharacterList;

    void Start()
    {
        characterManagerT = CharacterManager1.GetInstance();
    }

    void Update()
    {
        GetRabbitMode();
    }

    public void GetRabbitMode()
    {
        if (rabbitList == null)
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
                        target = hit.transform.gameObject;
                        UIPopRUGet.SetActive(true);
                    }
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
        GetRabbitTest(4);
        UIPopGetRB.SetActive(true);
        
    }

    public void CloseGetRB()
    {
        UIPopGetRB.SetActive(false);
        Destroy(target);
    }

    public void SpawnRabbit()
    {
        int rabbitIdx = 4;

        //Instantiate 생성객체 ,            위치값 ,               회전값
        curRabbit = Instantiate(rabbitList[rabbitIdx], new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    public void GetRabbitTest(int i)
    {
        characterManagerT.Character[i].getCharacter = true;
    }

    public void OpenUICharacterList()
    {
        UICharacterList.gameObject.SetActive(true);

        UICharacterList.SetCharacterList();
        UIPopGetRB.SetActive(false);
    }
}
