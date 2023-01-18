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

    //public int characterListIdx = 0;

    private void Awake()
    {
        ChooseList();
        Debug.Log($"ÀÌ¸§: {Character[1].characterName}");
    }

    public void ChooseList()
    {
        //characterList = new Dictionary<string, Character>();
        //characterList.Add("Åä³¢1", new Character("Åä³¢1", false));
        Character = new Character[]
            {
                new Character("Åä³¢1", 600, false, 0),
                new Character("Åä³¢2", 500, false, 0),
                new Character("Åä³¢3", 200, false, 0),
                new Character("Åä³¢4", 400, false, 0),
                new Character("Åä³¢5", 800, false, 0),
                new Character("Âý½ÒÅä³¢", 10, false, 0),
                new Character("½ºÆä¼ÈÅä³¢", 5000, false, 0)
            };
    }
}
