using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrnaRoomObj : MonoBehaviour
{
    [SerializeField] private GameObject objOrnaments;

    //[SerializeField] private Transform[] objOrnament;

    private GameObject ornaRoom;

    //[SerializeField] private GameObject[] roomOrnaList;
    [SerializeField] private GameObject bROrnaList;
    [SerializeField] private GameObject lROrnaList;
    [SerializeField] private GameObject yaOrnaList;

    [SerializeField] private GameObject[] bROrnament;
    [SerializeField] private GameObject[] lROrnament;
    [SerializeField] private GameObject[] yaOrnament;
    private void Awake()
    {
        ornaRoom = GameObject.FindGameObjectWithTag("OrnaRoom");

   
        bROrnament = new GameObject[OrnamentManager.GetInstance()._ornamentsList[0].Length];
        lROrnament = new GameObject[OrnamentManager.GetInstance()._ornamentsList[1].Length];
        yaOrnament = new GameObject[OrnamentManager.GetInstance()._ornamentsList[2].Length];

        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
        {
            bROrnament = GameObject.FindGameObjectsWithTag("BROrna");
            lROrnament = GameObject.FindGameObjectsWithTag("LROrna");
            yaOrnament = GameObject.FindGameObjectsWithTag("YaOrna");
        }

        for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList.Count; j++)
        {
            for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList[j].Length; i++)
            {
                if (j == 0)
                bROrnament[i].gameObject.SetActive(false);
                else if (j == 1)
                lROrnament[i].gameObject.SetActive(false);
                else if (j == 2)
                yaOrnament[i].gameObject.SetActive(false);
            }
        }

        bROrnaList.gameObject.SetActive(false);
        lROrnaList.gameObject.SetActive(false);
        yaOrnaList.gameObject.SetActive(false);
    }

    private void Start()
    {
        /////////////////// 샵 구매 버튼 작용 //////////////////////

        // for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
        // {
        //     
        //     for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
        //     {
        //         int buyRoomnum = i;
        //         int buyOrnanum = j;
        //         shopitem[buyRoomnum][buyOrnanum].onClick.AddListener(() =>
        //         {
        //             ResoLoadOrna(buyRoomnum , buyOrnanum);
        //         });
        //     }
        // }

        ////////////////////////////////////////////////////////////

       



    }

     // private void Update()
     // {
     //    
     // }

    public void LoadOrnaObj(int ornaidx)
    {
        if (ornaRoom.GetComponent<OrnaRoom>().room[0].activeSelf == true && bROrnament[ornaidx].activeSelf == false)
               bROrnament[ornaidx].gameObject.SetActive(true);
        else  if(ornaRoom.GetComponent<OrnaRoom>().room[0].activeSelf == true && bROrnament[ornaidx].activeSelf == true)
                bROrnament[ornaidx].gameObject.SetActive(false);
        

        if (ornaRoom.GetComponent<OrnaRoom>().room[1].activeSelf == true && lROrnament[ornaidx].activeSelf == false)
                lROrnament[ornaidx].gameObject.SetActive(true);
        else if (ornaRoom.GetComponent<OrnaRoom>().room[1].activeSelf == true && lROrnament[ornaidx].activeSelf == true)
                lROrnament[ornaidx].gameObject.SetActive(false);
        

        if (ornaRoom.GetComponent<OrnaRoom>().room[2].activeSelf == true && yaOrnament[ornaidx].activeSelf == false)
                yaOrnament[ornaidx].gameObject.SetActive(true);
        else if (ornaRoom.GetComponent<OrnaRoom>().room[2].activeSelf == true && yaOrnament[ornaidx].activeSelf == true)
                yaOrnament[ornaidx].gameObject.SetActive(false);
        
    }

    public void ResoLoadOrna(int buyRoomnum, int buyOrnanum)
    {
        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList[i].Length; i++)
        {
            if (buyRoomnum == 0)
            {
                bROrnaList.GetComponentsInChildren<GameObject>()[i] = Resources.Load<GameObject>($"Ornaments/{OrnamentManager.GetInstance()._ornamentsList[buyRoomnum][buyOrnanum].prefabName}");
                bROrnament[i].gameObject.SetActive(false);
            }
            else if (buyRoomnum == 1)
            {
                lROrnaList.GetComponentsInChildren<GameObject>()[i] = Resources.Load<GameObject>($"Ornaments/{OrnamentManager.GetInstance()._ornamentsList[buyRoomnum][buyOrnanum].prefabName}");
                lROrnament[i].gameObject.SetActive(false);
            }
            else if (buyRoomnum == 2)
            {
                yaOrnaList.GetComponentsInChildren<GameObject>()[i] = Resources.Load<GameObject>($"Ornaments/{OrnamentManager.GetInstance()._ornamentsList[buyRoomnum][buyOrnanum].prefabName}");
                yaOrnament[i].gameObject.SetActive(false);
            }
        }
    }

    public void BuyOrna(int buyRoomnum , int buyOrnanum)
    {
        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
        {
            
        }
    }

    public void BROrnaListFalse()
    {
        bROrnaList.gameObject.SetActive(false);
    }
    public void LROrnaListFalse()
    {
        lROrnaList.gameObject.SetActive(false);
    }
    public void YaOrnaListFalse()
    {
        yaOrnaList.gameObject.SetActive(false);
    }



    public void BROrnaListTrue()
    {
        bROrnaList.gameObject.SetActive(true);
    }
    public void LROrnaListTrue()
    {
        lROrnaList.gameObject.SetActive(true);
    }
    public void YaOrnaListTrue()
    {
        yaOrnaList.gameObject.SetActive(true);
    }

}
