using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesExample : MonoBehaviour
{
    // Start is called before the first frame update
    public int[] cardsHand;
    public int cardsHeld;
    public bool handIsFull;
    void Start()
    {
        cardsHand = new int[4];
        cardsHeld = 0;
        handIsFull = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
