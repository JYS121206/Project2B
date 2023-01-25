using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterList1 : MonoBehaviour
{
    // UI프리팹 UICharacterList 적용되는 스크립트입니다.

    // 캐릭터 획득시 도감에 반영 O

    // 캐릭터 도감에서 대표 캐릭터를 픽했을 때 메인화면 캐릭터 오브젝트에 바뀐 대표 캐릭터 반영 O
    // 도감에서 대표 캐릭터를 픽하면 자동으로 북마크 목록에 추가, 북마크 이미지 활성화(노란별) O
    // 북마크가 2개 이하=> 기존 북마크 목록에 새로 픽한 캐릭터 추가 O
    // 북마크가 3개 이상=> 기존 대표 캐릭터에서 북마크 제거 후 새로 픽한 캐릭터 추가 O
    // 대표캐릭터는 북마크를 해제할 수 없도록 설정 O

    //북마크 카운트 세는 방법을 바꿔야 할 것 같다=> 포문으로?
    // ㄴ해결(포문) characterManager.CountBookmark();  O

    // 메인 북마크 리스트에서 픽했을 때 메인에 반영 O
    // 수정 고민 중인 코드: 209번줄 참고  O

    //==
    // 도감의 북마크만 보기 페이지 => 북마크 해제하고 리스트로 돌아갔을 때 UI 초기화 X
    //==


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

    CharacterManager1 characterManager;

    public GameObject go;
    public GameObject curPick;

    int lastBmk;
    bool showBmk = false;

    bool fstPick = false;

    public UITab uiTab;

    void Start()
    {
        //UI 오픈할 때 초기화하는 법 생각해보기
        showBmk = false;
        fstPick = false;

        characterManager = CharacterManager1.GetInstance();
        Debug.Log($"배열크기: {characterManager.Character.Count}");

        btnProfile = new Button[characterManager.Character.Count];
        txtProfile = new Text[characterManager.Character.Count];
        imgCharacter = new Image[characterManager.Character.Count];
        imgBookmark = new Image[characterManager.Character.Count];

        for (int i = 0; i < characterManager.Character.Count; i++)
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
        gameObject.SetActive(false);
    }


    public void SetCharacterList()
    {
        CheckBookmark();

        for (int i = 0; i < characterManager.Character.Count; i++)
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
        for (int i = 0; i < characterManager.Character.Count; i++)
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
        showBmk = false;
        for (int i = 0; i < btnProfile.Length; i++)
        {
            btnProfile[i].gameObject.SetActive(true);
        }
    }

    public void ShowBookmark()
    {
        showBmk = true;
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
            if (num == characterManager.Pick)
                return;

            characterManager.Character[num].isBookmark = false;
            characterManager.CountBookmark();
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
            lastBmk = num;
            characterManager.CountBookmark();
            Debug.Log($"현재 북마크 개수: {characterManager.bookmark}개");
            btnGetBookmark.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/bookmark2");
        }
    }

    public void PickThis(int num)
    {
        if (characterManager.bookmark >= 3)
        {
            if (!fstPick)
            {
                if (!characterManager.Character[num].isBookmark)
                {
                    Debug.Log($"북마크 최대 한도 초과 | 직전 북마크 캐릭터를 북마크 목록에서 제외합니다");
                    characterManager.Character[lastBmk].isBookmark = false;
                    characterManager.CountBookmark();
                }

            }
            else
            {
                if (!characterManager.Character[num].isBookmark)
                {
                    Debug.Log($"북마크 최대 한도 초과 | 기존 대표 캐릭터 {characterManager.Character[characterManager.Pick].characterName}를 북마크 목록 및 대표 캐릭터 대상에서 제외합니다.");
                    characterManager.Character[characterManager.Pick].isBookmark = false;
                    characterManager.CountBookmark();
                }
            }
        }

        if (!fstPick)
        {
            fstPick = true;
            uiTab.gameObject.SetActive(true);
        }

        SetPick(num);
        characterManager.Character[num].isBookmark = true;
        characterManager.CountBookmark();
        btnGetBookmark.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/bookmark2");
        Debug.Log($"현재 북마크 개수: {characterManager.bookmark}개");

    }

    public void SetPick(int num)
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

        if(showBmk)
            ShowBookmark();
    }

}
