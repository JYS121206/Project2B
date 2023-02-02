using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    #region Singletone
    private static CharacterManager instance;

    public static CharacterManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@CharacterManager");
            instance = go.AddComponent<CharacterManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    //public Dictionary<string, Character> characterList;
    public Character[] Character;
    public int bookmark = 0;
    public int Pick = 100;

    //public int characterListIdx = 0;

    private void Awake()
    {
        ChooseList();
        Debug.Log($"이름: {Character[1].characterName}");
    }

    public void ChooseList()
    {
        //characterList = new Dictionary<string, Character>();
        //characterList.Add("토끼1", new Character("토끼1", false));
        Character = new Character[]
            {
                //  Character( 소스이름  한글이름  가격  get? 수량 북마크?)
                new Character("Rabbit1", "미미",600, false, "미미", false),
                new Character("Rabbit2", "폰데링",500, false, "미미", false),
                new Character("Rabbit3", "설묘",200, false, "미미", false),
                new Character("Rabbit4", "나나", 400, false, "미미", false),
                new Character("RabbitNM", "찹쌀이", 10, false, "미미", false),
                new Character("RabbitSP", "스페셜 토끼", 5000, false, "미미", false)
            };
    }

    public void CountBookmark()
    {
        bookmark = 0;

        for (int i = 0; i < Character.Length; i++)
        {
            if(Character[i].isBookmark)
                bookmark++;
        }
    }
}
