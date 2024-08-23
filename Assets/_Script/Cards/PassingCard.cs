using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingCard : MonoBehaviour
{
    public GameObject[] anchorList;
    private GameObject passingCard;
    private int turnIndex;
    private float timer;
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
        if (passAnim)
        {
            timer += Time.deltaTime*1.5f;
            passingCard.transform.position = Vector2.Lerp(anchorList[turnIndex].transform.position, anchorList[turnIndex + 1].transform.position, timer);
            
            if (passingCard.transform.position.x == anchorList[turnIndex + 1].transform.position.x)
            {
                timer = 0;
                turnIndex++;
                passAnim = false;
            }
        }
    }

    public static void PassCard(/*Cards c*/)
    {
        passAnim = true;
        Debug.Log("Passing");
    }

    //jogador termina o turno, Pass card
    //animação da carta passada ativa
    //quando terminar
}
