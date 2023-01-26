using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OrnamentManager : MonoBehaviour
{
    #region Singletone
    private static OrnamentManager instance;

    public static OrnamentManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@OrnamentManager");
            instance = go.AddComponent<OrnamentManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    //public void Awake()
    //{
    //    OrnamentList();
    //    Debug.Log($"이름: {_ornamentsList[1].ornamentName}");
    //}
    //public int ornamentsListIdx = 0;
    //
    //public List<Ornament[]> _ornamentsList = new List<Ornament[]>();
    //
    //public void OrnamentList()
    //{
    //    _ornamentsList = new List<Ornament[]>();
    //    { }
    //    _ornamentsList.Add(new Ornament("가구1", 100, false, 1, false));
    //    _ornamentsList.Add(new Ornament("가구2", 100, false, 1, false));
    //    _ornamentsList.Add(new Ornament("가구3", 100, false, 1, false));
    //    _ornamentsList.Add(new Ornament("가구4", 100, false, 1, false));
    //}
    //
    //public void SetOrnaList(int _ornamentsList)
    //{
    //    ornamentsListIdx = _ornamentsList;
    //}
    //
    //public List<Ornament> GetOrnaList()
    //{
    //    return _ornamentsList;
    //}
    //
    //private void Start()
    //{
    //    Debug.Log(GetOrnaList());
    //}

}
