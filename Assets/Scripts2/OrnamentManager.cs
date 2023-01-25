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


    public Ornament[] _ornament;
    //public List<Ornament> _ornamentsList = new List<Ornament>();

    public int ornament;

    public void OrnamentList()
    {
        _ornament = new Ornament[]
        {
            new Ornament("가구1", 100, false, 1, false),
            new Ornament("가구2", 100, false, 1, false),
            new Ornament("가구3", 100, false, 1, false),
            new Ornament("가구4", 100, false, 1, false)
        };
    }




        //List<Ornament> _ornamentsList = new List<Ornament>();
        //_ornamentsList.Add("가구1", 100, false, 1, false);



    

    public void Awake()
    {
        ornament = Random.Range(0, 4);

        Debug.Log($"이름: {_ornament[1].ornamentName}");
    }


}
