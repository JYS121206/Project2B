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
            new Ornament("침실 침대", "BRBed" ,100,false ,1 ,false ),
            new Ornament("침실 옷장", "BRCloset" ,100,false ,1 ,false ),
            new Ornament("침실 책선반", "BRBookcase" ,100,false ,1 ,false ),
            new Ornament("침실 책상", "BRDesk" ,100,false ,1 ,false ),
            new Ornament("침실 바닥장식", "BRRug" ,100,false ,1 ,false ),
            new Ornament("침실 침대서랍장", "BRBedTable"  ,100,false ,1 ,false ),
            new Ornament("침실 벽장식", "BRWalldecoration"  ,100,false ,1 ,false )
        });

        _ornamentsList.Add(new Ornament[]
        {
            new Ornament("거실 책장", "LRBookcase"  ,100,false ,1 ,false ),
            new Ornament("거실 화분", "LRFlowerpot"  ,100,false ,1 ,false ),
            new Ornament("거실 창가장식", "LRWindowdecoration"  ,100,false ,1 ,false ),
            new Ornament("거실 소파", "LRSopa"  ,100,false ,1 ,false ),
            new Ornament("거실 소파선반", "LRSopaTable"  ,100,false ,1 ,false ),
            new Ornament("거실 티 테이블", "LRTeaTable"  ,100,false ,1 ,false ),
            new Ornament("거실 턴 테이블", "LRTurntable"  ,100,false ,1 ,false )
        });

        _ornamentsList.Add(new Ornament[]
        {
            new Ornament("정원 캔버스이젤", "YaCanvasEasel"  ,100,false ,1 ,false ),
            new Ornament("정원 의자", "YaChair"  ,100,false ,1 ,false ),
            new Ornament("정원 벽조명", "YaLamp"  ,100,false ,1 ,false ),
            new Ornament("정원 디딤석", "YaSteppingStone"  ,100,false ,1 ,false ),
            new Ornament("정원 그네의자", "YaSwingChair"  ,100,false ,1 ,false ),
            new Ornament("정원 테이블", "YaTable"  ,100,false ,1 ,false )
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

}
