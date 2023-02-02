using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string characterName;
    public string korName;
    public int price;
    public bool getCharacter;
    public string about;
    public bool isBookmark;

    public Character(string characterName, string korName, int price, bool getCharacter, string about, bool isBookmark)
    {
        this.characterName = characterName;
        this.korName = korName;
        this.price = price;
        this.getCharacter = getCharacter;
        this.about = about;
        this.isBookmark = isBookmark;
    }

}
