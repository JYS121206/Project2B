using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrnaRoom : MonoBehaviour
{
    private GameObject[] room;

    private GameObject OrnaInfoUI;

    public GameObject btnChangeRooms;

    public Button[] btnChangeRoom;
    private void Awake()
    {

        OrnaInfoUI = GameObject.FindGameObjectWithTag("OrnaInfoUI");
        btnChangeRooms = GameObject.FindGameObjectWithTag("BtnChangeRooms");
        room = GameObject.FindGameObjectsWithTag("Room"); // ¹æ ¹è¿­
        btnChangeRoom = btnChangeRooms.GetComponentsInChildren<Button>();

        for (int i = 0; i < room.Length; i++) 
            room[i].gameObject.SetActive(false);

        room[0].gameObject.SetActive(true);


    }

    private void Start()
    {
       for (int i = 0; i < room.Length;i++)
       {
            int roomnum = i;
            btnChangeRoom[i].onClick.AddListener(() =>
            {
                ChangeRoom(roomnum);
            });
       }
    }


    public void ChangeRoom(int roomnum)
    {
        for (int i = 0; i < room.Length; i++)
        {
            if (room[i] == room[roomnum] && room[i].activeSelf == false)
                room[i].gameObject.SetActive(true);

            else if (room[i].activeSelf == true)
                room[i].gameObject.SetActive(false);
        }
    }
}
