using System.Collections;
using System.Collections.Generic;
using _Script.Oponents;
using UnityEngine;

public class GroupDistraction : MonoBehaviour
{
    public GoblinBehaviour[] goblins;
    public float distractionDuration = 5f;
    public float cooldownDuration = 15f;
    public float imageDuration = 1f;
    public SpriteRenderer imageObject;
    public Sprite distractionSprite;

    private float _currentCooldown = 0f;
    private float _imageTimer = 0f;
    private bool _onCooldown = false;
    private SpriteRenderer _renderer;

    void Start()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
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

    private void OnMouseDown()
    {
        if (_onCooldown) return;
        StartCoroutine(ShowImage());
    }

    private void DistractAll()
    {
        foreach (var goblin in goblins)
        {
            // Only distract goblins that are not distracted at the time
            if (!goblin.IsDistracted())
            {
                goblin.Distract(distractionDuration);
            }
        }
    }

    private IEnumerator ShowImage()
    {
        // Show distraction image
        imageObject.sprite = distractionSprite;
        imageObject.gameObject.SetActive(true);
        yield return new WaitForSeconds(imageDuration);
        imageObject.gameObject.SetActive(false);
        DistractAll();
        _onCooldown = true;
        _currentCooldown = cooldownDuration;
        Color c = _renderer.color;
        c.a = 0.1f;
        _renderer.color = c;
    }
}
