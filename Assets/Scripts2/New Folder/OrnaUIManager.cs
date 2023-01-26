using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OrnaUIManger : MonoBehaviour
{
    #region Singletone
    private static OrnaUIManger instance = null;

    public static OrnaUIManger GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@OrnaUIManger");
            instance = go.AddComponent<OrnaUIManger>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    #region UI Control

    public void SetEventSystem()
    {
        if (FindObjectOfType<EventSystem>() == false)
        {
            GameObject go = new GameObject("@EventSystem");
            go.AddComponent<EventSystem>();
            go.AddComponent<StandaloneInputModule>();
        }
    }

    //      "UIPopup"    uiObject      
    //      "UIIntro"    uiObject      
    //      "UIEnding"   uiObject     
    //      "UIMainMenu" uiObject   <-
    Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();

    public void OpenUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == false)
        {
            Object uiObj = Resources.Load("YSJ/" + uiName);    // 1 리소스를 로드                
            GameObject go = (GameObject)Instantiate(uiObj); // 2 실제로 생성

            uiList.Add(uiName, go);
        }
        else
            uiList[uiName].SetActive(true);
    }

    public void CloseUI(string uiName)
    {
        if (uiList.ContainsKey(uiName))
            uiList[uiName].SetActive(false);
    }

    public GameObject GetUI(string uiName)
    {
        if (uiList.ContainsKey(uiName))
            return uiList[uiName];

        return null;
    }

    public void ClearList()
    {
        uiList.Clear();
    }
    #endregion
}