using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsDealer : MonoBehaviour
{
    private int[][] cardsDeck;
    private Vector2Int cardToDeal;
    public GameObject[] players;
    private int playerToDeal;
    
    // Start is called before the first frame update
    void Start()
    {
        cardToDeal = new Vector2Int(0, 0);

        cardsDeck = new int[][]
        {
            new int[] {01,11,21,31}, //todas as cartas que terminarem em "x" serão do mesmo número
            new int[] {02,12,22,32}, //a casa decimal representa o naipe daquela carta
            new int[] {03,13,23,33}, //comparando os naipes (%10) a gente sabe quando podemos bater
            new int[] {04,14,24,34}  //associaremos os valores à cada carta na mão do player.
        };

        DealCards();
    }

    void DealCards()
    {
        //int deckLength = cardsDeck[1].Length * cardsDeck.GetLength(0);
        //Debug.Log(deckLength);

        for (int i =0; i< cardsDeck[1].Length; i++)
        {
            for(int j=0; j< cardsDeck.GetLength(0); j++)
            {
                //cardToDeal = new Vector2Int(i, j);
                playerToDeal = Random.Range(0, players.Length);
                if (players[playerToDeal].GetComponent<EnemiesExample>().handIsFull)
                {
                    //botar while(handIsFull) aqui
                }
                else
                players[playerToDeal].GetComponent<EnemiesExample>().cardsHand[players[playerToDeal].GetComponent<EnemiesExample>().cardsHeld] = cardsDeck[i][j];
            }
        }
    }
}
