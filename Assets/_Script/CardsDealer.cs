using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsDealer : MonoBehaviour
{
    private int[][] cardsDeck;
    public GameObject[] goblins;
    
    // Start is called before the first frame update
    void Start()
    {
        cardsDeck = new int[][]
        {
            new int[] {01,11,21,31}, //todas as cartas que terminarem em "x" serão do mesmo número
            new int[] {02,12,22,32}, //a casa decimal representa o naipe daquela carta
            new int[] {03,13,23,33}, //comparando os naipes (%10) a gente sabe quando podemos bater
            new int[] {04,14,24,34}  //associaremos os valores à cada carta na mão do goblin.
        };

        DealCards();
    }

    void DealCards()
    {
        //int deckLength = cardsDeck[1].Length * cardsDeck.GetLength(0);
        //Debug.Log(deckLength);
        GameObject goblinToDeal;
        EnemiesExample goblinScript;

        for (int i =0; i< cardsDeck[0].Length; i++)
        {
            for(int j=0; j< cardsDeck.GetLength(0); j++)
            {
                goblinToDeal = goblins[Random.Range(0, goblins.Length)];
                goblinScript = goblinToDeal.GetComponent<EnemiesExample>();

                while (goblinScript.handIsFull)
                {
                    goblinToDeal = goblins[Random.Range(0, goblins.Length)];
                    goblinScript = goblinToDeal.GetComponent<EnemiesExample>();
                }

                Debug.Log("i:" + i + ", j: " + j);
                goblinScript.cardsHand[goblinScript.cardsHeld] = cardsDeck[i][j];
                goblinScript.cardsHeld++;

                if (goblinScript.cardsHeld == 4)
                    goblinScript.handIsFull = true;
            }
        }

       ////Printar todas as cartas em suas respectivas mãos
       //for (int i = 0; i < 4; i++)
       //    for (int j = 0; j < 4; j++)
       //        Debug.Log("Goblin "+ i + ":" + goblins[i].GetComponent<EnemiesExample>().cardsHand[j] + ", ");
    }
}
