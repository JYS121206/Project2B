using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class OrnaBookBtns : MonoBehaviour
{
    public List <Button> _ornaBookBtns = new List <Button>();

    public GameObject OrnaInfoUI;


    private void Start()
    {
        for (int i = 0; i <= _ornaBookBtns.Count - 1; i++) 
        {
            int bookBtnsidx = i;
            _ornaBookBtns[bookBtnsidx].onClick.AddListener(() =>
            {
                OpenOrnaInfo(bookBtnsidx);
            });
            
        }
    }


    public void OpenOrnaInfo(int bookBtnsidx)
    {
        OrnamentManager.GetInstance().SetOrnaList(bookBtnsidx);
        OrnaInfoUI.GetComponent<OrnaInfoUI>().LaodOrnaInfo(bookBtnsidx);
    }
}
