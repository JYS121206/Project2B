using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabBox : MonoBehaviour
{
    GameObject CurrentTouch;
    public UIMainMenu1 uiMainMenu1;
    public UICharacterList1 uiCharacterList1;
    void Start()
    {
        
    }

    void Update()
    {
        if (CharacterManager1.GetInstance().Pick1st)
        {
            TabTab();
        }
    }

    public void TabTab()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if (hit.collider != null)
            {
                CurrentTouch = hit.transform.gameObject;
                GameManager.GetInstance().GetCoin1(uiMainMenu1);
            }
        }
    }

}
