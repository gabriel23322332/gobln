using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsDealer : MonoBehaviour
{
    private int cardsIndex;
    private Cards[]cardsDeck;
    public GameObject[] goblins;
    
    // Start is called before the first frame update
    void Start()
    {

        cardsIndex = 0;
        cardsDeck = new Cards[]
#region
        {
            new Cards(1, Cards.Naipe.Castelo),
            new Cards(2, Cards.Naipe.Castelo),
            new Cards(3, Cards.Naipe.Castelo),
            new Cards(4, Cards.Naipe.Castelo),
            new Cards(1, Cards.Naipe.Cerveja),
            new Cards(2, Cards.Naipe.Cerveja),
            new Cards(3, Cards.Naipe.Cerveja),
            new Cards(4, Cards.Naipe.Cerveja),
            new Cards(1, Cards.Naipe.Espada),
            new Cards(2, Cards.Naipe.Espada),
            new Cards(3, Cards.Naipe.Espada),
            new Cards(4, Cards.Naipe.Espada),
            new Cards(1, Cards.Naipe.Dinheiro),
            new Cards(2, Cards.Naipe.Dinheiro),
            new Cards(3, Cards.Naipe.Dinheiro),
            new Cards(4, Cards.Naipe.Dinheiro),
            new Cards(0, Cards.Naipe.Coringa),
        };
        #endregion
        DealCards();
    }

    void DealCards()
    {
        GameObject goblinToDeal;
        Character goblinScript;
        
        for (int i =0; i< cardsDeck.Length; i++)
        {
            do
            {
                goblinToDeal = goblins[Random.Range(0, goblins.Length)];
                goblinScript = goblinToDeal.GetComponent<Character>();
            }
            while (goblinScript.handIsFull && i < cardsDeck.Length-1);

            Debug.Log("i: " + i);

            goblinScript.cardsHand[goblinScript.cardsHeld] = cardsDeck[i];
            goblinScript.cardsHeld++;

            if (goblinScript.cardsHeld == 4)
                goblinScript.handIsFull = true;
        }

      //Printar todas as cartas de suas respectivas mãos
      //"Goblin 0" = player
      for (int i = 0; i < 4; i++)
          for (int j = 0; j < 4; j++)
              Debug.Log("Goblin "+ i + ": " + goblins[i].GetComponent<Character>().cardsHand[j].cardNaipe + ", " + goblins[i].GetComponent<Character>().cardsHand[j].number);
    }
}
