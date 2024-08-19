using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsDealer : MonoBehaviour
{
    private int[][] cardsDeck;
    public GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {

        cardsDeck = new int[][]
        {
            new int[] {01,11,21,31}, //todas as cartas que terminarem em "x" serão do mesmo número
            new int[] {02,12,22,32}, //a casa decimal representa o naipe daquela carta
            new int[] {03,13,23,33}, //comparando os naipes (%10) a gente sabe quando podemos bater
            new int[] {04,14,24,34}  //associaremos os valores à cada carta na mão do player.
        };

        ShuffleCards();
    }

    void ShuffleCards()
    {
            
    }
}
