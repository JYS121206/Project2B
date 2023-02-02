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
        Debug.Log($"이름: {Character[1].characterName}");
    }

    public void ChooseList()
    {
        Character = new List<Character>();
        //                Character( 이름   가격  get? 설명 북마크?)
        Character.Add(new Character("Rabbit1", "미미", 600, false, "솔빈이 캐릭터\n검은색 단발 머리 토끼입니다", false));
        Character.Add(new Character("Rabbit2", "폰데링", 500, false, "호영이 캐릭터\n머리를 양쪽으로 땋았습니다", false));
        Character.Add(new Character("Rabbit3", "설묘", 200, false, "호영이 캐릭터\n한복을 입었습니다", false));
        Character.Add(new Character("Rabbit4", "나나", 400, false, "솔빈이 캐릭터\n베레모를 착용 중입니다", false));
        Character.Add(new Character("RabbitNM", "찹쌀이", 10, false, "찹쌀떡으로 만들어진 토끼", false));
        Character.Add(new Character("RabbitSP", "큐브", 5000, false, "스페셜 토끼\n진짜 정체는 아무도 모른다!", false));
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
