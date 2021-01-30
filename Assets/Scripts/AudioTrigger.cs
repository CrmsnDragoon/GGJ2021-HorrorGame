using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource soundTrigger;

    private bool soundPlayed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (soundPlayed == true)
        {
            return;
        }
        soundTrigger.Play();
        soundPlayed = true;
    }

    public void ResetTrigger()
    {
        soundPlayed = false;
    }
}
