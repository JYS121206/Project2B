using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrnaInfoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text txtOrnasName;

    [SerializeField] private GameObject gObjOrnaInfo;

    [SerializeField] private GameObject pick;

    [SerializeField] private GameObject ornaImges;

    [SerializeField] private Button Close;

    private Button[] btnOrnaPick;

    private Image[] ornaImage;

    public GameObject ornaObjs;
    

    //int ornaidx;


    //Ornament[] _ornaList;

    private void Awake()
    {
        btnOrnaPick = new Button[OrnamentManager.GetInstance()._ornamentsList[0].Length];
        ornaImage = new Image[OrnamentManager.GetInstance()._ornamentsList[0].Length];
        for (int i = 0; i < OrnamentManager.GetInstance()._ornamentsList[0].Length; i++)
        {
            btnOrnaPick[i] = pick.GetComponentsInChildren<Button>()[i];
            ornaImage[i] = ornaImges.GetComponentsInChildren<Image>()[i];
        }
        for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[0].Length; j++)
        {
            ornaImage[j].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[0][j].getOrnament);
            btnOrnaPick[j].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[0][j].pick);
            ornaImage[j].sprite = Resources.Load<Sprite>($"YSJ/{OrnamentManager.GetInstance()._ornamentsList[0][j].ornamentName}");
        }
    }
    private void Start()
    {
        for (int i = 0; i < btnOrnaPick.Length; i++)
        {
            int btnOrnaPickidx = i;
            btnOrnaPick[btnOrnaPickidx].onClick.AddListener(() =>
            {
                OpenOrnaObj(btnOrnaPickidx);
            });
        }
            Close.onClick.AddListener(CloseOrnaInfo);
    }

    public void LoadOrnaInfo(int ornaidx)
    {
        gObjOrnaInfo.gameObject.SetActive(true);
        txtOrnasName.text = OrnamentManager.GetInstance()._ornamentsList[0][ornaidx].ornamentName;
        ornaImage[ornaidx].gameObject.SetActive(true);
        btnOrnaPick[ornaidx].gameObject.SetActive(true);
    }

    public void CloseOrnaInfo()
    {
        gObjOrnaInfo.gameObject.SetActive(false);
        for (int j = 0; j < OrnamentManager.GetInstance()._ornamentsList[0].Length; j++)
        {
            ornaImage[j].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[0][j].getOrnament);
            btnOrnaPick[j].gameObject.SetActive(OrnamentManager.GetInstance()._ornamentsList[0][j].pick);
        }
    }

    public void OpenOrnaObj(int ornaPickidx)
    {
        ornaObjs.GetComponent<OrnaRoomObj>().LoadOrnaObj(ornaPickidx);
    }


}
