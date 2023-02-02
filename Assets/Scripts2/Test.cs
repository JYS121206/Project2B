using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button btnTest;

    void Start()
    {
        btnTest.onClick.AddListener(SetTest);
    }

    public void SetTest()
    {
        var List = OrnamentManager.GetInstance().GetOrnaList();
        OrnamentManager.GetInstance().SetOrnaList(0);
        for (int i = 0; i < List.Length; i++)
        {
            List[i].getOrnament = true;
        }
        OrnamentManager.GetInstance().SetOrnaList(1);
        for (int i = 0; i < List.Length; i++)
        {
            List[i].getOrnament = true;
        }
        OrnamentManager.GetInstance().SetOrnaList(2);
        for (int i = 0; i < List.Length; i++)
        {
            List[i].getOrnament = true;
        }
    }
}
