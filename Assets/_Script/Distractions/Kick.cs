using System;
using System.Collections;
using System.Collections.Generic;
using _Script.Oponents;
using UnityEngine;
using UnityEngine.UIElements;

public class Kick : MonoBehaviour
{
    public GoblinBehaviour[] goblins;
    // Start is called before the first frame update

    private void OnMouseDown()
    {
        foreach (var goblin in goblins)
        {
            goblin.SetAvailable();
        }
    }
}
