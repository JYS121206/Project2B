using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GetRabbitMode : MonoBehaviour
{
    public LayerMask Rabbit;
    public GameObject UIPopRUGet;
    public GameObject UIPopGetRB;

    public Button btnGet;
    public Button btnPass;

    public Button btnConfirm;
    public Button btnContinue;

    //public List<GameObject> rabbitList = new List<GameObject>();
    GameObject curRabbit;
    GameObject target;

    CharacterManager1 characterManager;

    public UICharacterList1 UICharacterList;

    bool isOpne = false;

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        characterManager = CharacterManager1.GetInstance();
    }

    void Update()
    {
        TouchEvent();
    }

    public void TouchEvent()
    {
        if (Input.touchCount > 0)
        {
            if (Camera.main == null)
                Debug.Log("Camera.main is null");

            //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (EventSystem.current == null)
                Debug.Log("EventSystem.current is null");

            //UI뒤 오브젝트 클릭 못하게 하기
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("eeee");
                return;
            }
                
            if (Physics.Raycast(ray, out hit, Rabbit))
            {
                if (isOpne == false)
                {
                    Debug.Log("Hit : " + hit.transform.gameObject);
                    target = hit.transform.gameObject;

                    UIPopRUGet.SetActive(true);
                    isOpne = true;
                }

                else
                    return;
            }
        }
    }

    public void CloseRUGet()
    {
        UIPopRUGet.SetActive(false);
        isOpne = false;
        target.SetActive(false);
    }

    public void OpenGetRB()
    {
        Debug.Log("OpenGetRB - 1");
        UIPopRUGet.SetActive(false);
        target.SetActive(false);
        GetRabbit();
        Debug.Log("OpenGetRB - 2");
        UIPopGetRB.SetActive(true);
        isOpne = false;
    }

    public void CloseGetRB()
    {
        UIPopGetRB.SetActive(false);
        target.SetActive(false);
    }

    //public void SpawnRabbit()
    //{
    //    int rabbitIdx = 4;

    //    //Instantiate 생성객체 ,            위치값 ,               회전값
    //    curRabbit = Instantiate(rabbitList[rabbitIdx], new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    //}

    public void GetRabbit()
    {
        //characterManager.Character[i].getCharacter = true;
        string name;
        name = hit.transform.name;
        int x;

        for (int i = 0; i < characterManager.Character.Count; i++)
        {
            if (characterManager.Character[i].characterName == name)
            {
                x = i;
                characterManager.Character[x].getCharacter = true;
            }
        }
    }

    public void OpenUICharacterList()
    {
        UICharacterList.gameObject.SetActive(true);

        UICharacterList.SetCharacterList();
        UIPopGetRB.SetActive(false);
    }
}
