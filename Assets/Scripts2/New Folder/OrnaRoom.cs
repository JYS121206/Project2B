using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrnaRoom : MonoBehaviour
{
    public GameObject[] room;

    private GameObject OrnaInfoUI;

    [SerializeField] private GameObject btnChangeRooms;

    [SerializeField] private GameObject ornaRoomObj;

    private Button[] btnChangeRoom;
    private void Awake()
    {
        OrnaInfoUI = GameObject.FindGameObjectWithTag("OrnaInfoUI");
        //btnChangeRooms = GameObject.FindGameObjectWithTag("BtnChangeRooms");
        room = GameObject.FindGameObjectsWithTag("Room"); // 방 배열        

        btnChangeRoom = btnChangeRooms.GetComponentsInChildren<Button>();

        for (int i = 0; i < room.Length; i++) 
            room[i].gameObject.SetActive(false);

        room[0].gameObject.SetActive(true);


    }

    private void Start()
    {
       for (int i = 0; i < room.Length;i++)  // 룸 번호 클릭
       {
            int roomnum = i;
            btnChangeRoom[i].onClick.AddListener(() =>
            {
                ChangeRoom(roomnum);
            });
       }
    }


    public void ChangeRoom(int roomnum)  // 룸 온 오프
    {
        for (int i = 0; i < room.Length; i++)
        {
            if (room[i] == room[roomnum] && room[i].activeSelf == false)
            {
                room[i].gameObject.SetActive(true);
                if (i == 0)
                    ornaRoomObj.GetComponent<OrnaRoomObj>().BROrnaListTrue();
                else if (i == 1)
                    ornaRoomObj.GetComponent<OrnaRoomObj>().LROrnaListTrue();
                else if (i == 2)
                    ornaRoomObj.GetComponent<OrnaRoomObj>().YaOrnaListTrue();
            }
            else if (room[i] == room[roomnum] && room[i].activeSelf == true)
            {

            }

            else
            {
                room[i].gameObject.SetActive(false);
                if (i == 0)
                    ornaRoomObj.GetComponent<OrnaRoomObj>().BROrnaListFalse();
                else if (i == 1)
                    ornaRoomObj.GetComponent<OrnaRoomObj>().LROrnaListFalse();
                else if (i == 2)
                    ornaRoomObj.GetComponent<OrnaRoomObj>().YaOrnaListFalse();
            }
        }

        //OrnaInfoUI.GetComponent<OrnaBookBtns>().OrnaBookBtn(roomnum);
    }
}
