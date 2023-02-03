using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    #region Singletone
    private static RoomManager instance;

    public static RoomManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@RoomManager");
            instance = go.AddComponent<RoomManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    private void Awake()
    {
        //instance = this;
        //DontDestroyOnLoad(this);
        RommCheckList();
    }

    #endregion

    public List<Room[]> _roomscheck = new List<Room[]>();



    public void RommCheckList()
    {
        _roomscheck = new List<Room[]>();

        _roomscheck.Add(new Room[]
        {
            new Room(true),
            new Room(false),
            new Room(false)
        }); 
    }



}
