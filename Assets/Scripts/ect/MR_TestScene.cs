using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    Ray ray;
    RaycastHit hit;


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

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            //UI�� ������Ʈ Ŭ�� ���ϰ� �ϱ�
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
                        Debug.Log(hit.transform.name + "�� ��Ÿ����.");
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
        Debug.Log("111");
        GetRabbitTest();
        Debug.Log("222");
        UIPopGetRB.SetActive(true);

    }

    public void CloseGetRB()
    {
        UIPopGetRB.SetActive(false);
        Destroy(target);
    }

    public void SpawnRabbit()
    {
        int rabbitIdx = Random.Range(0, characterManagerT.Character.Count);

        //Instantiate ������ü ,            ��ġ�� ,               ȸ����
        curRabbit = Instantiate(rabbitList[rabbitIdx], new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    public void GetRabbitTest()
    {
        string name;
        name = hit.transform.name;
        int x;

        for (int i = 0; i < characterManagerT.Character.Count; i++)
        {
            Debug.Log("��������");

            if (characterManagerT.Character[i].characterName + "(Clone)" == name)
            {
                x = i;
                characterManagerT.Character[x].getCharacter = true;
                Debug.Log(x + "��° ĳ���͸� ȹ���Ͽ����ϴ�.");
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
