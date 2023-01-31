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
        Debug.Log($"¿Ã∏ß: {Character[1].characterName}");
    }

    public void ChooseList()
    {
        //characterList = new Dictionary<string, Character>();
        //characterList.Add("≈‰≥¢1", new Character("≈‰≥¢1", false));
        Character = new Character[]
            {
                //  Character( ¿Ã∏ß   ∞°∞›  get? ºˆ∑Æ ∫œ∏∂≈©?)
                new Character("Rabbit1", 600, false, 0, false),
                new Character("Rabbit2", 500, false, 0, false),
                new Character("Rabbit3", 200, false, 0, false),
                new Character("Rabbit4", 400, false, 0, false),
                new Character("RabbitNM", 10, false, 0, false),
                new Character("RabbitSP", 5000, false, 0, false)
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
