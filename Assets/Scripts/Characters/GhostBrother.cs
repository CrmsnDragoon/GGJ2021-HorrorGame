using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBrother : MonoBehaviour
{
  
    public AudioSource growl;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            growl.Play();
            Global.Health--;
        }
    }

}
