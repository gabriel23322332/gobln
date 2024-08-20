using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards
{
    public enum Naipe {Espada, Castelo, Cerveja, Dinheiro, Coringa};
    public int number;
    public Naipe cardNaipe;

    private Texture2D[] cardSprites;
   
    public Cards()
    {
        number = 0;
        cardNaipe = Naipe.Coringa;
    }
}
