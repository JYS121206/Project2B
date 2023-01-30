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
        Debug.Log($"¿Ã∏ß: {Character[1].characterName}");
    }

    public void ChooseList()
    {
        Character = new List<Character>();
        //                Character( ¿Ã∏ß   ∞°∞›  get? ºˆ∑Æ ∫œ∏∂≈©?)
        Character.Add(new Character("≈‰≥¢1", 600, false, 0, false));
        Character.Add(new Character("≈‰≥¢2", 500, false, 0, false));
        Character.Add(new Character("≈‰≥¢3", 200, false, 0, false));
        Character.Add(new Character("≈‰≥¢4", 400, false, 0, false));
        Character.Add(new Character("¬˝Ω“≈‰≥¢", 10, false, 0, false));
        Character.Add(new Character("Ω∫∆‰º»≈‰≥¢", 5000, false, 0, false));
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
