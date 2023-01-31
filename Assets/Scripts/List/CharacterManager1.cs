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
        //                Character( 이름   가격  get? 수량 북마크?)
        Character.Add(new Character("Rabbit1", 600, false, 0, false));
        Character.Add(new Character("Rabbit2", 500, false, 0, false));
        Character.Add(new Character("Rabbit3", 200, false, 0, false));
        Character.Add(new Character("Rabbit4", 400, false, 0, false));
        Character.Add(new Character("RabbitNM", 10, false, 0, false));
        Character.Add(new Character("RabbitSP", 5000, false, 0, false));
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
