using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards 
{
    public enum Naipe
    {
        Espada =1,
        Castelo =2,
        Cerveja =3,
        Dinheiro =4,
        Coringa =0
    };
    public int number;
    public Naipe cardNaipe;
    public Cards(int n, Naipe p )
    {
        number = n;
        cardNaipe = p;
    }
}
