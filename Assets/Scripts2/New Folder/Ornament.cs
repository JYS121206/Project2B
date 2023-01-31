using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ornament
{
    public string ornamentName;
    public string prefabName;
    public int price;
    public bool getOrnament;
    public int amount;
    public bool pick;

    public Ornament(string ornamentName, string prefabName, int price, bool getOrnament, int amount, bool pick)
    {
        this.ornamentName = ornamentName;
        this.prefabName = prefabName;
        this.price = price;
        this.getOrnament = getOrnament;
        this.amount = amount;
        this.pick = pick;
    }
}

