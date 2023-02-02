using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager1 : MonoBehaviour
{
    #region Singletone
    private static CharacterManager1 instance;

    public static CharacterManager1 GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@CharacterManager1");
            instance = go.AddComponent<CharacterManager1>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    //public Dictionary<string, Character> characterList;
    public List<Character> Character;
    public int bookmark = 0;
    public int Pick = 100;

    public bool fstPick;
    public bool Pick1st;

    //public int characterListIdx = 0;

    private void Awake()
    {
        ChooseList();
        Debug.Log($"�̸�: {Character[1].characterName}");
    }

    public void ChooseList()
    {
        Character = new List<Character>();
        //                Character( �̸�   ����  get? ���� �ϸ�ũ?)
        Character.Add(new Character("Rabbit1", "�̹�", 600, false, "�ֺ��� ĳ����\n������ �ܹ� �Ӹ� �䳢�Դϴ�", false));
        Character.Add(new Character("Rabbit2", "������", 500, false, "ȣ���� ĳ����\n�Ӹ��� �������� ���ҽ��ϴ�", false));
        Character.Add(new Character("Rabbit3", "����", 200, false, "ȣ���� ĳ����\n�Ѻ��� �Ծ����ϴ�", false));
        Character.Add(new Character("Rabbit4", "����", 400, false, "�ֺ��� ĳ����\n������ ���� ���Դϴ�", false));
        Character.Add(new Character("RabbitNM", "������", 10, false, "���Ҷ����� ������� �䳢", false));
        Character.Add(new Character("RabbitSP", "ť��", 5000, false, "����� �䳢\n��¥ ��ü�� �ƹ��� �𸥴�!", false));
    }

    public void CountBookmark()
    {
        bookmark = 0;

        for (int i = 0; i < Character.Count; i++)
        {
            if(Character[i].isBookmark)
                bookmark++;
        }
    }
}
