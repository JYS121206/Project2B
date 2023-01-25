using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrnamentObjManager : MonoBehaviour
{
    #region Singletone
    private static OrnamentObjManager instance;

    public static OrnamentObjManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@OrnamentObjManager");
            instance = go.AddComponent<OrnamentObjManager>();

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

    public List<GameObject> _ornamentList = new List<GameObject>();

    public List<GameObject> _ornamentActivePickList = new List<GameObject>();
}
