using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrnaRoomObj : MonoBehaviour
{
    [SerializeField] private GameObject objOrnaments;

    [SerializeField] private Transform[] objOrnament;


    private void Awake()
    {
        objOrnament = new Transform[OrnamentManager.GetInstance()._ornamentsList[0].Length];
        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList[0].Length; i++)
        {
            objOrnament[i] = objOrnaments.GetComponentsInChildren<Transform>()[i];
        }
        for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[0].Length; j++)
        {
            objOrnament[j].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[0][j].pick);
        }
    }


    public void LoadOrnaObj(int ornaidx)
    {
        if (objOrnament[ornaidx].gameObject.activeSelf == false)
            objOrnament[ornaidx].gameObject.SetActive(true);
        else if (objOrnament[ornaidx].gameObject.activeSelf == true)
            objOrnament[ornaidx].gameObject.SetActive(false);
    }
}
