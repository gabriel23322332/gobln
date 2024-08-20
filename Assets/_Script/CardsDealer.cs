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
        cardsDeck = new Cards[17];
        cardsIndex = 0;

        for(int i =0; i<4; i++) //define o naipe
        {
            Cards card = new Cards();
            
            for (int j = 0; j < 4; j++) //define o numero
            {
                card.number = j;

                switch(i)
                {
                    case 0:
                        card.cardNaipe = Cards.Naipe.Espada;
                        break;
                    case 1:
                        card.cardNaipe = Cards.Naipe.Castelo;
                        break;
                    case 2:
                        card.cardNaipe = Cards.Naipe.Cerveja;
                        break;
                    case 3:
                        card.cardNaipe = Cards.Naipe.Dinheiro;
                        break;
                }
                //Debug.Log(cardsIndex);
                cardsDeck[cardsIndex] = card;
                cardsIndex++;
            }

        }

        Cards joker = new Cards();
        joker.number = 0;
        joker.cardNaipe = Cards.Naipe.Coringa;
        cardsDeck[cardsIndex] = joker;

        DealCards();
    }

    void DealCards()
    {
        //int deckLength = cardsDeck[1].Length * cardsDeck.GetLength(0);
        //Debug.Log(deckLength);
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

      //Printar todas as cartas em suas respectivas mãos
      //for (int i = 0; i < 4; i++)
      //    for (int j = 0; j < 4; j++)
      //        Debug.Log("Goblin "+ i + ": " + goblins[i].GetComponent<Character>().cardsHand[j].cardNaipe + ", " + goblins[i].GetComponent<Character>().cardsHand[j].number);
    }
}
