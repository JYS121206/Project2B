using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singletone
    private static GameManager instance;

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@GameManager");
            instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    public float curCoin = 0; //플레이어 재화
    public float coin = 30;
    public float fullExp = 30;
    public float curExp = 0;
    public int hitCount = 0;

    void Start()
    {
        curCoin = 0; 
        fullExp = 30; 
        curExp = 0;
    }
    public void GetCoin(UIMainMenu uIMainMenu)
    {

        if (curExp >= fullExp)
        {
            curCoin += coin;
            Debug.Log($"Coin +{coin} !");
            fullExp = fullExp * 1.1f;
            coin *= 1.1f;
            curExp = 0;
            hitCount = 0;

            uIMainMenu.SetCoin();
        }
        curExp++;
        hitCount++;
        Debug.Log($"{hitCount}번째 클릭!");
    }
    public void GetCoin1(UIMainMenu1 uIMainMenu)
    {

        if (curExp >= fullExp)
        {
            curCoin += coin;
            Debug.Log($"Coin +{coin} !");
            fullExp = fullExp * 1.1f;
            coin *= 1.1f;
            curExp = 0;
            hitCount = 0;

            uIMainMenu.SetCoin();
        }
        curExp++;
        hitCount++;
        Debug.Log($"{hitCount}번째 클릭!");
    }
}
