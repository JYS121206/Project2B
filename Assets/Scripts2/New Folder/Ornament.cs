using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ornament
{
    public string ornamentName;
    public int price;
    public bool getOrnament;
    public int amount;
    public bool pick;

    public Ornament(string ornamentName, int price, bool getOrnament, int amount, bool pick)
    {
        this.ornamentName = ornamentName;
        this.price = price;
        this.getOrnament = getOrnament;
        this.amount = amount;
        this.pick = pick;
    }
}

