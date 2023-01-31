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
            new Ornament("ħ�� ħ��", "BRBed" ,100,false ,1 ,false ),
            new Ornament("ħ�� ����", "BRCloset" ,100,false ,1 ,false ),
            new Ornament("ħ�� å����", "BRBookcase" ,100,false ,1 ,false ),
            new Ornament("ħ�� å��", "BRDesk" ,100,false ,1 ,false ),
            new Ornament("ħ�� �ٴ����", "BRRug" ,100,false ,1 ,false ),
            new Ornament("ħ�� ħ�뼭����", "BRBedTable"  ,100,false ,1 ,false ),
            new Ornament("ħ�� �����", "BRWalldecoration"  ,100,false ,1 ,false )
        });

        _ornamentsList.Add(new Ornament[]
        {
            new Ornament("�Ž� å��", "LRBookcase"  ,100,false ,1 ,false ),
            new Ornament("�Ž� ȭ��", "LRFlowerpot"  ,100,false ,1 ,false ),
            new Ornament("�Ž� â�����", "LRWindowdecoration"  ,100,false ,1 ,false ),
            new Ornament("�Ž� ����", "LRSopa"  ,100,false ,1 ,false ),
            new Ornament("�Ž� ���ļ���", "LRSopaTable"  ,100,false ,1 ,false ),
            new Ornament("�Ž� Ƽ ���̺�", "LRTeaTable"  ,100,false ,1 ,false ),
            new Ornament("�Ž� �� ���̺�", "LRTurntable"  ,100,false ,1 ,false )
        });

        _ornamentsList.Add(new Ornament[]
        {
            new Ornament("���� ĵ��������", "YaCanvasEasel"  ,100,false ,1 ,false ),
            new Ornament("���� ����", "YaChair"  ,100,false ,1 ,false ),
            new Ornament("���� ������", "YaLamp"  ,100,false ,1 ,false ),
            new Ornament("���� �����", "YaSteppingStone"  ,100,false ,1 ,false ),
            new Ornament("���� �׳�����", "YaSwingChair"  ,100,false ,1 ,false ),
            new Ornament("���� ���̺�", "YaTable"  ,100,false ,1 ,false )
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
