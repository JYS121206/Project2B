using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    public GameObject[] boards;

    void Start()
    {
        for (int i = 0; i < boards.Length; i++)
        {
            boards[i] = GetComponentsInChildren<SpriteRenderer>()[i].gameObject;
        }
    }
}
