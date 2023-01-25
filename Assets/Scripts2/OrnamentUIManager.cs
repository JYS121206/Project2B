using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrnamentUIManager : MonoBehaviour
{

    #region Singletone
    private static OrnamentUIManager instance;

    public static OrnamentUIManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@OrnamentUIManager");
            instance = go.AddComponent<OrnamentUIManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    [SerializeField]
    public Button fdasfasd;
    public Button fdasfasd2;

    public List<Button> _ornamentBtnList = new List<Button>();

    public List<GameObject> _ornamentInfoList = new List<GameObject>();

    public List<Button> _ornamentInfoCloseBtnList = new List<Button>();

    public List<Button> _ornamentInfoPickBtnList = new List<Button>();

    
}
