using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrnaRoomObj : MonoBehaviour
{
    [SerializeField] private GameObject objOrnaments;

    //[SerializeField] private Transform[] objOrnament;

    private GameObject ornaRoom;

    //[SerializeField] private GameObject[] roomOrnaList;
    public GameObject bROrnaList;
    public GameObject lROrnaList;
    public GameObject yaOrnaList;

    public GameObject[] bROrnament;
    public GameObject[] lROrnament;
    public GameObject[] yaOrnament;

    OrnaBookBtns ornaBookBtns;

    OrnamentManager ornamentManager;
    private void Awake()
    {
        ornaRoom = GameObject.FindGameObjectWithTag("OrnaRoom");

        bROrnament = new GameObject[OrnamentManager.GetInstance()._ornamentsList[0].Length];
        lROrnament = new GameObject[OrnamentManager.GetInstance()._ornamentsList[1].Length];
        yaOrnament = new GameObject[OrnamentManager.GetInstance()._ornamentsList[2].Length];
        Debug.Log($"으아아아아{bROrnament.Length}");
        
        bROrnament = GameObject.FindGameObjectsWithTag("BROrna");
        lROrnament = GameObject.FindGameObjectsWithTag("LROrna");
        yaOrnament = GameObject.FindGameObjectsWithTag("YaOrna");
        

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

       //if ()
        lROrnaList.gameObject.SetActive(false);
        yaOrnaList.gameObject.SetActive(false);

        bROrnaList.gameObject.SetActive(true);
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

    // private void Update()
    // {
    //     ResoLoadOrna();
    // }
    public void LoadOrnaObj(int ornaidx)
    {
        if (ornaRoom.GetComponent<OrnaRoom>().room[0].activeSelf == true && OrnamentManager.GetInstance()._ornamentsList[0][ornaidx].pick == false)
        {
            OrnamentManager.GetInstance()._ornamentsList[0][ornaidx].pick = true;
            bROrnament[ornaidx].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[0][ornaidx].pick);
        }
        else if (ornaRoom.GetComponent<OrnaRoom>().room[0].activeSelf == true && OrnamentManager.GetInstance()._ornamentsList[0][ornaidx].pick == true)
        {
            OrnamentManager.GetInstance()._ornamentsList[0][ornaidx].pick = false;
            bROrnament[ornaidx].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[0][ornaidx].pick);
        }

        if (ornaRoom.GetComponent<OrnaRoom>().room[1].activeSelf == true && OrnamentManager.GetInstance()._ornamentsList[1][ornaidx].pick == false)
        {
            OrnamentManager.GetInstance()._ornamentsList[1][ornaidx].pick = true;
            lROrnament[ornaidx].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[1][ornaidx].pick);
        }
        else if (ornaRoom.GetComponent<OrnaRoom>().room[1].activeSelf == true && OrnamentManager.GetInstance()._ornamentsList[1][ornaidx].pick == true)
        {
            OrnamentManager.GetInstance()._ornamentsList[1][ornaidx].pick = false;
            lROrnament[ornaidx].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[1][ornaidx].pick);
        }


        if (ornaRoom.GetComponent<OrnaRoom>().room[2].activeSelf == true && OrnamentManager.GetInstance()._ornamentsList[2][ornaidx].pick == false)
        {
            OrnamentManager.GetInstance()._ornamentsList[2][ornaidx].pick = true;
            yaOrnament[ornaidx].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[2][ornaidx].pick);
        }
        else if (ornaRoom.GetComponent<OrnaRoom>().room[2].activeSelf == true && OrnamentManager.GetInstance()._ornamentsList[2][ornaidx].pick == true)
        {
            OrnamentManager.GetInstance()._ornamentsList[2][ornaidx].pick = false;
            yaOrnament[ornaidx].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[2][ornaidx].pick);
        }  
    }


    #region
    public void ResoLoadOrna()
    {
       // for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList.Count; i++)
       // {
       //     for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[i].Length; j++)
       //     {
       //         if (i == 0)
       //         {
       //             if (OrnamentManager.GetInstance()._ornamentsList[i][j].getOrnament == true)
       //             {
       //                 bROrnament[j] = Resources.Load<GameObject>($"Ornaments/{OrnamentManager.GetInstance()._ornamentsList[i][j].prefabName}");
       //                 bROrnament[j].gameObject.SetActive(false);
       //             }
       //             else { }
       //         }
       //         else if (i == 1)
       //         {
       //             if (OrnamentManager.GetInstance()._ornamentsList[i][j].getOrnament == true)
       //             {
       //                 lROrnament[j] = Resources.Load<GameObject>($"Ornaments/{OrnamentManager.GetInstance()._ornamentsList[i][j].prefabName}");
       //                 lROrnament[j].gameObject.SetActive(false);
       //             }
       //             else { }
       //         }
       //         else if (i == 2)
       //         {
       //             if (OrnamentManager.GetInstance()._ornamentsList[i][j].getOrnament == true)
       //             {
       //                 yaOrnament[j] = Resources.Load<GameObject>($"Ornaments/{OrnamentManager.GetInstance()._ornamentsList[i][j].prefabName}");
       //                 yaOrnament[j].gameObject.SetActive(false);
       //             }
       //             else { }
       //         }
       //     }
       // }



        // ornaBookBtns.OrnaActive(num);
    }

    #endregion


    public void BuyOrna(string buyRoomnum , int buyOrnanum)
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
