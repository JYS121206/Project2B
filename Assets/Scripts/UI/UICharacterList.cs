using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterList : MonoBehaviour
{
    // UI프리팹 UICharacterList 적용되는 스크립트입니다.

    public GameObject UIProfileList;
    public GameObject UIProfile;
    public Button btnClose;

    public Button[] btnProfile;
    public Text[] txtProfile;
    public Image[] imgCharacter;
    public Image[] imgBookmark;

    public Button btnAll;
    public Button btnBookmark;

    public Image imgProfile;
    public Button btnGetBookmark;
    public Text txtName;
    public Text txtAbout;

    public Button btnPick;
    public Button btnToList;

    CharacterManager characterManager;

    public GameObject go;
    public GameObject curPick;

    void Start()
    {
        characterManager = CharacterManager.GetInstance();
        Debug.Log($"배열크기: {characterManager.Character.Length}");

        btnProfile = new Button[characterManager.Character.Length];
        txtProfile = new Text[characterManager.Character.Length];
        imgCharacter = new Image[characterManager.Character.Length];
        imgBookmark = new Image[characterManager.Character.Length];

        for (int i = 0; i < characterManager.Character.Length; i++)
        {
            btnProfile[i] = GetComponentsInChildren<Button>()[i];
            txtProfile[i] = GetComponentsInChildren<Text>()[i];
            imgCharacter[i] = btnProfile[i].GetComponentsInChildren<Image>()[2];
            imgBookmark[i] = btnProfile[i].GetComponentsInChildren<Image>()[3];
        }
        SetCharacterList();

        btnAll.onClick.AddListener(ShowAll);
        btnBookmark.onClick.AddListener(ShowBookmark);

        btnToList.onClick.AddListener(ToList);

        btnClose.onClick.AddListener(CloseCharacterList);
    }


    public void SetCharacterList()
    {
        CheckBookmark();

        for (int i = 0; i < characterManager.Character.Length; i++)
        {
            int idx = i;

            if (characterManager.Character[idx].getCharacter)
            {
                imgCharacter[i].sprite = Resources.Load<Sprite>($"Image/{characterManager.Character[i].characterName}");
                txtProfile[i].text = $"{characterManager.Character[i].characterName}";
                btnProfile[idx].onClick.RemoveAllListeners();
                btnProfile[idx].onClick.AddListener(() => { OpenProfile(idx); });
            }
            else
            {
                imgCharacter[i].sprite = Resources.Load<Sprite>($"Image/lock");
                txtProfile[i].text = $"???";
                btnProfile[idx].onClick.AddListener(() => { Lock(idx); });
            }
        }
    }

    public void Lock(int num)
    {
        Debug.Log($"캐릭터 {num+1}의 정보를 열람할 수 없습니다");
    }

    public void CheckBookmark()
    {
        for (int i = 0; i < characterManager.Character.Length; i++)
        {
            if (characterManager.Character[i].isBookmark)
                imgBookmark[i].gameObject.SetActive(true);
            else
                imgBookmark[i].gameObject.SetActive(false);
        }
    }

    public void CloseCharacterList()
    {
        ToList();
        ShowAll();
        gameObject.SetActive(false);
    }

    public void ShowAll()
    {
        for (int i = 0; i < btnProfile.Length; i++)
        {
            btnProfile[i].gameObject.SetActive(true);
        }
    }

    public void ShowBookmark()
    {
        for (int i = 0; i < btnProfile.Length; i++)
        {
            if(characterManager.Character[i].isBookmark)
                btnProfile[i].gameObject.SetActive(true);
            else
                btnProfile[i].gameObject.SetActive(false);
        }
    }

    public void OpenProfile(int num)
    {
        UIProfileList.SetActive(false);
        UIProfile.SetActive(true);
        SetProfile(num);
        Debug.Log($"{num}의 프로필 열람");
    }

    public void SetProfile(int num)
    {
        imgProfile.sprite = Resources.Load<Sprite>($"Image/{characterManager.Character[num].characterName}");
        txtName.text = $"{characterManager.Character[num].characterName}";
        txtAbout.text = $"캐릭터 설정 몰라";

        if(characterManager.Character[num].isBookmark)
            btnGetBookmark.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/bookmark2");
        else
            btnGetBookmark.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/bookmark1");

        btnGetBookmark.onClick.RemoveAllListeners();
        btnGetBookmark.onClick.AddListener(() => { SetBookmark(num); });
        btnPick.onClick.RemoveAllListeners();
        btnPick.onClick.AddListener(() => { PickThis(num); });
    }

    public void SetBookmark(int num)
    {
        if (characterManager.Character[num].isBookmark)
        {
            characterManager.Character[num].isBookmark = false;
            characterManager.bookmark--;
            Debug.Log($"현재 북마크 개수: {characterManager.bookmark}개");
            btnGetBookmark.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/bookmark1");
        }

        else
        {
            if (characterManager.bookmark >= 3)
            {
                Debug.Log($"북마크가 가득 찼습니다. 현재 북마크 개수: {characterManager.bookmark}개");
                return;
            }

            characterManager.Character[num].isBookmark = true;
            characterManager.bookmark++;
            Debug.Log($"현재 북마크 개수: {characterManager.bookmark}개");
            btnGetBookmark.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/bookmark2");
        }
    }

    public void PickThis(int num)
    {
        characterManager.Pick = num;
        Debug.Log($"대표 캐릭터: {characterManager.Character[num].characterName}");

        if (curPick)
        {
            Destroy(curPick.gameObject);
            curPick = null;
        }

        Object pickObj = Resources.Load($"GO3D/{characterManager.Character[characterManager.Pick].characterName}");
        GameObject pickCharacter = (GameObject)Instantiate(pickObj, go.transform);
        //pickCharacter.transform.SetParent(go.transform);

        curPick = pickCharacter;
    }


    public void ToList()
    {
        UIProfile.SetActive(false);
        UIProfileList.SetActive(true);

        CheckBookmark();

    }
}
