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
    private void Awake()
    {
        //instance = this;
        //DontDestroyOnLoad(this);
        OrnamentList();
        Debug.Log(_ornamentsList[0][3].ornamentName);
    }

    #endregion

    
    public int ornamentsListIdx = 0;
    
    public List<Ornament[]> _ornamentsList = new List<Ornament[]>();
    
    public void OrnamentList()
    {
        _ornamentsList = new List<Ornament[]>();
        
        _ornamentsList.Add(new Ornament[]
        {
            new Ornament("啊备1" ,100,false ,1 ,false ),
            new Ornament("啊备2" ,100,false ,1 ,false ),
            new Ornament("啊备3" ,100,false ,1 ,false ),
            new Ornament("啊备4" ,100,false ,1 ,false )
        });

        _ornamentsList.Add(new Ornament[]
        {
            new Ornament("啊备1" ,100,false ,1 ,false ),
            new Ornament("啊备2" ,100,false ,1 ,false ),
            new Ornament("啊备3" ,100,false ,1 ,false ),
            new Ornament("啊备4" ,100,false ,1 ,false )
        });



    }
    
    public void SetOrnaList(int _ornamentsList)
    {
        ornamentsListIdx = _ornamentsList;
    }
    
    public Ornament[] GetOrnaList()
    {
        return _ornamentsList[ornamentsListIdx];
    }
    
    private void Start()
    {
        
    }

}
