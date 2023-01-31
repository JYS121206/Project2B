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
            new Ornament("침대" ,100,false ,1 ,false ),
            new Ornament("옷장" ,100,false ,1 ,false ),
            new Ornament("책선반" ,100,false ,1 ,false ),
            new Ornament("책상" ,100,false ,1 ,false ),
            new Ornament("바닥장식" ,100,false ,1 ,false ),
            new Ornament("침상서랍장" ,100,false ,1 ,false ),
            new Ornament("벽장식" ,100,false ,1 ,false )
        });

        _ornamentsList.Add(new Ornament[]
        {
            new Ornament("책장" ,100,false ,1 ,false ),
            new Ornament("화분" ,100,false ,1 ,false ),
            new Ornament("창가장식" ,100,false ,1 ,false ),
            new Ornament("소파" ,100,false ,1 ,false ),
            new Ornament("소파선반" ,100,false ,1 ,false ),
            new Ornament("티테이블" ,100,false ,1 ,false ),
            new Ornament("턴테이블" ,100,false ,1 ,false )
        });

        _ornamentsList.Add(new Ornament[]
        {
            new Ornament("캔버스이젤" ,100,false ,1 ,false ),
            new Ornament("의자" ,100,false ,1 ,false ),
            new Ornament("벽조명" ,100,false ,1 ,false ),
            new Ornament("디딤석" ,100,false ,1 ,false ),
            new Ornament("그네의자" ,100,false ,1 ,false ),
            new Ornament("테이블" ,100,false ,1 ,false )
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
