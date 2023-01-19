using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string characterName;
    public int price;
    public bool getCharacter;
    public int amount;
    public bool isBookmark;

    public Character(string characterName, int price, bool getCharacter, int amount, bool isBookmark)
    {
        this.characterName = characterName;
        this.price = price;
        this.getCharacter = getCharacter;
        this.amount = amount;
        this.isBookmark = isBookmark;
    }

}
