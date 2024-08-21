using System;
using System.Collections;
using System.Collections.Generic;
using _Script.Oponents;
using UnityEngine;
using UnityEngine.UIElements;

public class Kick : MonoBehaviour
{
    public GoblinBehaviour[] goblins;
    public float distractionDuration = 5f;
    public float cooldownDuration = 15f;

    private float _currentCooldown = 0f;
    private bool _active = false;
    private bool _onCooldown = false;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_active)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                foreach (var goblin in goblins)
                {
                    if (hit.collider == goblin.GetComponent<Collider2D>())
                    {
                        Debug.Log("Collided");
                        _active = false;
                        ToggleAllAvailable();
                        goblin.Distract(distractionDuration);
                        _onCooldown = true;
                        _currentCooldown = cooldownDuration;
                        Color c = _renderer.color;
                        c.a = 0.1f;
                        _renderer.color = c;
                    }
                }
            }
        }

        if (_onCooldown && _currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }
        else
        {
            _onCooldown = false;
            Color c = _renderer.color;
            c.a = 1f;
            _renderer.color = c;
        }
    }
    // Start is called before the first frame update

    private void OnMouseDown()
    {
        if (_onCooldown) return;
        _active = true;
        ToggleAllAvailable();
    }

    private void ToggleAllAvailable()
    {
        foreach (var goblin in goblins)
        {
            goblin.ToggleAvailable();
        }
    }
}
