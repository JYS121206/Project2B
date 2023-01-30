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

    CharacterManager1 characterManager;

    public UICharacterList1 UICharacterList;

    void Start()
    {
        
    }

    void Update()
    {
        TouchEvent();
    }

    public void TouchEvent()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            //UI뒤 오브젝트 클릭 못하게 하기
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("eeee");
                return;
            }
                


            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject);
                target = hit.transform.gameObject;
                UIPopRUGet.SetActive(true);
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
        GetRabbit(4);
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

    public void GetRabbit(int i)
    {
        characterManager.Character[i].getCharacter = true;
    }

    public void OpenUICharacterList()
    {
        UICharacterList.gameObject.SetActive(true);

        UICharacterList.SetCharacterList();
        UIPopGetRB.SetActive(false);
    }
}
