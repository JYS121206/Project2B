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
        Debug.Log($"�̸�: {Character[1].characterName}");
    }

    public void ChooseList()
    {
        //characterList = new Dictionary<string, Character>();
        //characterList.Add("�䳢1", new Character("�䳢1", false));
        Character = new Character[]
            {
                new Character("�䳢1", 600, false, 0),
                new Character("�䳢2", 500, false, 0),
                new Character("�䳢3", 200, false, 0),
                new Character("�䳢4", 400, false, 0),
                new Character("�䳢5", 800, false, 0),
                new Character("�����䳢", 10, false, 0),
                new Character("������䳢", 5000, false, 0)
            };
    }
}
