using System;
using UnityEditor.Animations;
using UnityEngine;

namespace _Script.Oponents
{
  public class GoblinBehaviour : MonoBehaviour
  {
    private bool _distracted = false;
    private float _distractedDuration;
    private Animator _animator;

    private void Start()
    {
      _animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
      if (_distracted && _distractedDuration > 0)
      {
        _distractedDuration -= Time.deltaTime;
      }
      else
      {
        _distracted = false;
        _animator.SetBool("Distracted", false);
      }
    }

    public void Distract(float duration, Sprite sprite)
    {
      if (_distracted) return;
      _distracted = true;
      _distractedDuration = duration;
      _animator.SetBool("Distracted", true);
    }

    public bool IsDistracted()
    {
      return _distracted;
    }


    public void SetAvailable()
    {
      if (_distracted) return;
      _animator.SetBool("Available", true);
    }
  }
}