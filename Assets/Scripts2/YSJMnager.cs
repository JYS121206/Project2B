using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YSJMnager : MonoBehaviour
{
    public List<Button> ornamentbtns = new List<Button>();

    //public int n = Random.Range(0, TestManager.GetInstance().ornamentObjs.Count);
    void Start()
    {
        //Debug.Log(n);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (TestManager.GetInstance().ornamentObjs[n].activeSelf == true)
    //     {
    //         //TestManager.GetInstance().OrnamentbtnsCall(0);
    //         ornamentbtns[0].gameObject.SetActive(true);
    //     }
    // 
    //     else if (TestManager.GetInstance().ornamentObjs[0].activeSelf == false&& ornamentbtns[0].gameObject.activeSelf == (true))
    //     {
    //         //TestManager.GetInstance().OrnamentbtnsCall(0);
    //         ornamentbtns[0].gameObject.SetActive(false);
    //     }
    // }
}
