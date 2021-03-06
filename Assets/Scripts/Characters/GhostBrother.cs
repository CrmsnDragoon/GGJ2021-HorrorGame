﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBrother : MonoBehaviour
{
  
    public AudioSource growl;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Global.Health--;
            StartCoroutine(frankGruntMoment());
          
        }
    }

    IEnumerator frankGruntMoment()
    {
        growl.Play();
        SubtitleController.Instance.ShowSubtitle("Frank's Brother: *Grunting*", 1);
        yield return new WaitForSeconds(1);
    }

}
