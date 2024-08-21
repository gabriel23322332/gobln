using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingCard : MonoBehaviour
{
    public GameObject[] anchorList;
    private GameObject passingCard;
    private int turnIndex;
    private int timer;
    private static bool passAnim;
    
    void Start()
    {
        passingCard = transform.GetChild(0).gameObject;
        passAnim = false;
        turnIndex = 0;
        timer = 0;
        //0 = right anchor
        //1 = right goblin
        //2 = middle goblin
        //3 = left goblin
        //4 = left anchor
        
    }

    // Update is called once per frame
    void Update()
    {
        if(passAnim)
        {
            passingCard.transform.position = Vector2.Lerp(anchorList[turnIndex].transform.position, anchorList[turnIndex + 1].transform.position, 1);
            if (passingCard.transform.position.x <= anchorList[turnIndex + 1].transform.position.x * 0.95)
            {
                timer = 0;

                passAnim = false;
            }
        }
    }

    public static void PassCard(Cards c)
    {
        passAnim = true;

    }

    //jogdor termina o turno, Pass card
    //animação da carta passada ativa
    //quando terminar
}
