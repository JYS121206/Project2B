using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterList1 : MonoBehaviour
{
    // UI������ UICharacterList ����Ǵ� ��ũ��Ʈ�Դϴ�.

    // ĳ���� ȹ��� ������ �ݿ� O

    // ĳ���� �������� ��ǥ ĳ���͸� ������ �� ����ȭ�� ĳ���� ������Ʈ�� �ٲ� ��ǥ ĳ���� �ݿ� O
    // �������� ��ǥ ĳ���͸� ���ϸ� �ڵ����� �ϸ�ũ ��Ͽ� �߰�, �ϸ�ũ �̹��� Ȱ��ȭ(�����) O
    // �ϸ�ũ�� 2�� ����=> ���� �ϸ�ũ ��Ͽ� ���� ���� ĳ���� �߰� O
    // �ϸ�ũ�� 3�� �̻�=> ���� ��ǥ ĳ���Ϳ��� �ϸ�ũ ���� �� ���� ���� ĳ���� �߰� O
    // ��ǥĳ���ʹ� �ϸ�ũ�� ������ �� ������ ���� O

    //�ϸ�ũ ī��Ʈ ���� ����� �ٲ�� �� �� ����=> ��������?
    // ���ذ�(����) characterManager.CountBookmark();  O

    // ���� �ϸ�ũ ����Ʈ���� ������ �� ���ο� �ݿ� O
    // ���� ��� ���� �ڵ�: 209���� ����  O

    //==
    // ������ �ϸ�ũ�� ���� ������ => �ϸ�ũ �����ϰ� ����Ʈ�� ���ư��� �� UI �ʱ�ȭ X
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
        //UI ������ �� �ʱ�ȭ�ϴ� �� �����غ���
        showBmk = false;
        fstPick = false;

        characterManager = CharacterManager1.GetInstance();
        Debug.Log($"�迭ũ��: {characterManager.Character.Count}");

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
        Debug.Log($"ĳ���� {num+1}�� ������ ������ �� �����ϴ�");
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
        Debug.Log($"{num}�� ������ ����");
    }

    public void SetProfile(int num)
    {
        imgProfile.sprite = Resources.Load<Sprite>($"Image/{characterManager.Character[num].characterName}");
        txtName.text = $"{characterManager.Character[num].characterName}";
        txtAbout.text = $"ĳ���� ���� ����";

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
            Debug.Log($"���� �ϸ�ũ ����: {characterManager.bookmark}��");
            btnGetBookmark.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/bookmark1");
        }

        else
        {
            if (characterManager.bookmark >= 3)
            {
                Debug.Log($"�ϸ�ũ�� ���� á���ϴ�. ���� �ϸ�ũ ����: {characterManager.bookmark}��");
                return;
            }

            characterManager.Character[num].isBookmark = true;
            lastBmk = num;
            characterManager.CountBookmark();
            Debug.Log($"���� �ϸ�ũ ����: {characterManager.bookmark}��");
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
                    Debug.Log($"�ϸ�ũ �ִ� �ѵ� �ʰ� | ���� �ϸ�ũ ĳ���͸� �ϸ�ũ ��Ͽ��� �����մϴ�");
                    characterManager.Character[lastBmk].isBookmark = false;
                    characterManager.CountBookmark();
                }

            }
            else
            {
                if (!characterManager.Character[num].isBookmark)
                {
                    Debug.Log($"�ϸ�ũ �ִ� �ѵ� �ʰ� | ���� ��ǥ ĳ���� {characterManager.Character[characterManager.Pick].characterName}�� �ϸ�ũ ��� �� ��ǥ ĳ���� ��󿡼� �����մϴ�.");
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
        Debug.Log($"���� �ϸ�ũ ����: {characterManager.bookmark}��");

    }

    public void SetPick(int num)
    {
        characterManager.Pick = num;
        Debug.Log($"��ǥ ĳ����: {characterManager.Character[num].characterName}");

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
