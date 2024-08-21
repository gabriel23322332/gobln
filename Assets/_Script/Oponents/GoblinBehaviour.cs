using UnityEngine;

namespace _Script.Oponents
{
  public class GoblinBehaviour : MonoBehaviour
  {
    private bool distracted = false;
    private float distractedDuration;

    public void Distract(float duration)
    {
      distracted = true;
      distractedDuration = duration;
    }

    private void Update()
    {
      if (distracted && distractedDuration > 0)
      {
        distractedDuration -= Time.deltaTime;
      }
      else
      {
        distracted = false;
      }
    }
  }
}